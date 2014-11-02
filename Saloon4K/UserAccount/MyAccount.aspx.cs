using System;
using System.Web;
using System.Web.UI;
using Resources;
using Saloon4kBLL;

namespace Saloon4K.UserAccount
{
    public partial class MyAccount : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {                    
                    txtPassword.Attributes["type"] = "password";
                    txtConfirmPassword.Attributes["type"] = "password";
                    Utilities.Helper.BindCountries(ref ddlCountry);
                    Utilities.Helper.SetPleaseSelect(ref ddlCountry);
                    InitializePage();
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void InitializePage()
        {
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                txtUsername.Text = p.Username;
                hfUserId.Value = p.UserId.ToString();
                txtFirstname.Text = p.FirstName;
                txtLastname.Text = p.LastName;                
                txtAddress.Text = p.Address;
                txtCity.Text = p.City;                
                txtPhone.Text = p.Phone;
                txtFacebookAccount.Text = p.FaceBookAccount;
                txtAbout.Text = p.About;
                ddlCountry.SelectedValue = p.Country;
            }
            else
            {
                Response.Redirect("~/Home.aspx", false);
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
                if (UserSession.Current.IsUserAuthenticated && hfUserId.Value != "0")
                {
                    var user = new User
                        {
                            UserId = Convert.ToInt32(hfUserId.Value),
                            About = txtAbout.Text.Trim(),
                            Address = txtAddress.Text.Trim(),
                            City = txtCity.Text.Trim(),
                            Facebook = txtFacebookAccount.Text.Trim(),
                            Firstname = txtFirstname.Text.Trim(),
                            Lastname = txtLastname.Text.Trim(),                            
                            Password = Utilities.Helper.Encrypt(txtPassword.Text.Trim()),
                            Phone = txtPhone.Text.Trim(),                            
                            Username = txtUsername.Text.Trim(),
                            Country = ddlCountry.SelectedValue
                        };
                    var rep = new UsersRepository();
                    var scopeid = rep.UpdateUser(user);
                    ClearFields();
                    if (!string.IsNullOrEmpty(scopeid.ToString()) && scopeid != 0)
                    {
                        UserSession.Current.UserProfile = null;
                        UserSession.Current.IsUserAuthenticated = false;                        
                        Response.Redirect("~/Home.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
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