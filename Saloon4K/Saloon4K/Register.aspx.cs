using System;
using System.Web.UI;
using Resources;
using Saloon4kBLL;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Web.UI.HtmlControls;

namespace Saloon4K
{
    public partial class Register : Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var masterPage = Master;
            if (masterPage == null) return;
            var divSlider = (HtmlGenericControl)masterPage.FindControl("divSlider");
            if (divSlider != null)
            {
                divSlider.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
                if (!IsPostBack)
                {
                    Utilities.Helper.BindCountries(ref ddlCountry);
                    Utilities.Helper.SetPleaseSelect(ref ddlCountry);
                    txtPassword.Attributes["type"] = "password";
                    txtConfirmPassword.Attributes["type"] = "password";
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected int RegisterIntermediateUser()
        {
            var inUser = new IntermediateUser
                {
                    About = txtAbout.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Avatar = "",
                    City = txtCity.Text.Trim(),
                    Facebook = txtFacebookAccount.Text.Trim(),
                    Firstname = txtFirstname.Text.Trim(),
                    Lastname = txtLastname.Text.Trim(),
                    Latitude = "",
                    Longitude = "",
                    Password = Utilities.Helper.Encrypt(txtPassword.Text.Trim()),
                    Phone = txtPhone.Text.Trim(),
                    State = "",
                    Username = txtUsername.Text.Trim(),
                    Country = ddlCountry.SelectedValue
                };
            var inRep = new IntermediateUsersRepository();
            var id = inRep.InsertIntermediateUser(inUser);
            return id;
        }

        protected void SendEmail(int userId)
        {
            var mm = new MailMessage(ConfigurationManager.AppSettings["ADMIN_EMAIL"], txtUsername.Text.Trim(), "Account Created Successfuly", MailBody(userId))
            {
                IsBodyHtml = true
            };
            try
            {
                var smtp = new SmtpClient();
                smtp.Send(mm);
                mm.Dispose();
                smtp.Dispose();
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
            }
        }

        protected string MailBody(int userId)
        {

            var reader = new StreamReader(Server.MapPath("~/EmailTemplates/AccountConfirmation.html"));
            var body = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            body = body.Replace("<link>", ConfigurationManager.AppSettings["SiteUrl"] + "Confirmation.aspx?ID=" + Utilities.Helper.Encrypt(userId.ToString()));
            return body;
        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Utilities.IsSingle(txtUsername.Text.Trim()))
                {
                    Session["isSingle"] = true;
                }
                else
                {
                    Session["isSingle"] = false;
                    divMessage.InnerHtml = Common.DuplicateUsername;
                    divMessage.Attributes.Add("class", "msgError");
                    divMessage.Visible = true;

                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
            }
        }

        protected void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    divMessage.InnerHtml = Common.PasswordNotSame;
                    divMessage.Attributes.Add("class", "msgError");
                    divMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
            }
        }

        protected void ClearFields()
        {
            txtAbout.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtConfirmPassword.Text = "";
            txtFacebookAccount.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtUsername.Text = "";
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(Session["isSingle"]))
                {
                    var response = RegisterIntermediateUser();
                    if (response != 0)
                    {
                        SendEmail(response);
                        ClearFields();
                        Response.Redirect("~/Confirmation.aspx", false);
                    }
                }
                else
                {
                    divMessage.InnerHtml = Common.DuplicateUsername;
                    divMessage.Attributes.Add("class", "msgError");
                    divMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");

            }
        }
    }
}