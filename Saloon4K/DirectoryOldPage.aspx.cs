using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Saloon4kBLL;

namespace Saloon4K
{
    public partial class DirectoryOldPage : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var masterPage = Master;
            if (masterPage == null) return;
            var lnkDirectory = (HtmlAnchor)masterPage.FindControl("lnkDirectory");
            lnkDirectory.Attributes.Add("class", "active");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
                btnBookEmail.Visible = false;
                btnBookPhone.Visible = false;
                if (!IsPostBack)
                {
                    InitializePage();
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");

            }
        }

        protected void InitializePage()
        {
            var rep = new CategoriesRepository();
            var list = rep.GetAllCategories();
            if (list.Count > 0)
            {
                rptCategories.DataSource = list;
                rptCategories.DataBind();
            }
            else
            {
                rptCategories.DataSource = null;
                rptCategories.DataBind();
            }
        }

        protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                var hfCategoryId = (HiddenField)e.Item.FindControl("hfCategoryId");
                var rptSaloons = (Repeater)e.Item.FindControl("rptSaloons");
                var rep = new SaloonsRepository();
                var list = rep.GetAllSaloonsByCategoryId(Convert.ToInt32(hfCategoryId.Value), Session["Country"].ToString());
                if (list.Count > 0)
                {
                    rptSaloons.DataSource = list;
                    rptSaloons.DataBind();
                }
                else
                {
                    rptSaloons.DataSource = null;
                    rptSaloons.DataBind();
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
            }
        }

        protected void rptCategories_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");

            }
        }

        protected void rptSaloons_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "View")
                {
                    if (UserSession.Current.IsUserAuthenticated)
                    {
                        btnBookPhone.Visible = true;
                        btnBookEmail.Visible = true;
                        var p = UserSession.Current.UserProfile;
                        hfUserId.Value = p.UserId.ToString();
                        hfSaloonId.Value = e.CommandArgument.ToString();
                    }
                    var rep = new SaloonsRepository();
                    var saloon = rep.GetSaloonById(Convert.ToInt32(e.CommandArgument));
                    if (saloon != null)
                    {
                        if (!string.IsNullOrEmpty(saloon.Image1) && saloon.Image1 != "N/A")
                        {
                            imgSaloonImage1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Saloons/" + saloon.Image1;
                        }
                        else
                        {
                            imgSaloonImage1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/NoImage.png";
                        }

                        if (!string.IsNullOrEmpty(saloon.Image2) && saloon.Image2 != "N/A")
                        {
                            imgSaloonImage2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Saloons/" + saloon.Image2;
                        }
                        else
                        {
                            imgSaloonImage2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/NoImage.png";
                        }

                        if (!string.IsNullOrEmpty(saloon.Image3) && saloon.Image3 != "N/A")
                        {
                            imgSaloonImage3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Saloons/" + saloon.Image3;
                        }
                        else
                        {
                            imgSaloonImage3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/NoImage.png";
                        }
                        lblSaloonName.InnerHtml = saloon.Name;
                        lblAddress.InnerHtml = "<b>Address:</b>&nbsp;" + saloon.Address;
                        hfSaloonAddress.Value = saloon.Address;
                        hfSaloonCity.Value = saloon.City;
                        hfSaloonState.Value = saloon.State;
                        hfSaloonPhone.Value = saloon.Phone;
                        lblDescription.InnerHtml = "<b>Description:</b>&nbsp;" + saloon.Description;
                        divPhone.InnerHtml = saloon.Phone;
                        lblSaloonEmail.Text = saloon.Email;
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowPopUp", "ShowPopUp();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");

            }
        }

        protected void btnBookNow_Click(object sender, EventArgs e)
        {
            try
            {
                SendEmail(lblSaloonName.InnerText.Trim(), hfSaloonAddress.Value, hfSaloonCity.Value, hfSaloonState.Value, hfSaloonPhone.Value, txtBookingDate.Text.Trim(), txtBookingTime.Text.Trim(), lblSaloonEmail.Text.Trim());
                Response.Redirect("~/BookingConfirmation.aspx", false);
            }
            catch (Exception ex)
            {

            }
        }

        public static bool SendEmail(string saloonName, string saloonAddress, string saloonCity, string saloonState, string saloonPhone, string bookingDate, string bookingTime, string saloonEmail)
        {
            var p = new Profile();
            if (UserSession.Current.IsUserAuthenticated)
            {
                p = UserSession.Current.UserProfile;
            }
            var mm = new MailMessage(p.Username, saloonEmail, p.FirstName + " " + p.LastName + " has sent you a message.", MailBody(saloonName, saloonAddress, saloonCity, saloonState, saloonPhone, bookingDate, bookingTime, saloonEmail))
            {
                IsBodyHtml = true
            };
            try
            {
                var smtp = new SmtpClient { EnableSsl = true };
                smtp.Send(mm);
                mm.Dispose();
                smtp.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string MailBody(string saloonName, string saloonAddress, string saloonCity, string saloonState, string saloonPhone, string bookingDate, string bookingTime, string saloonEmail)
        {
            string body = "";
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                var reader = new StreamReader(ConfigurationManager.AppSettings["SiteRoot"] + @"EmailTemplates\SaloonBookings.html");
                body = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                body = body.Replace("<name>", p.FirstName + " " + p.LastName);
                body = body.Replace("<address>", p.Address);
                body = body.Replace("<city>", p.City);
                body = body.Replace("<state>", p.State);
                body = body.Replace("<phone>", p.Phone);
                body = body.Replace("<sname>", saloonName);
                body = body.Replace("<saddress>", saloonAddress);
                body = body.Replace("<scity>", saloonCity);
                body = body.Replace("<sstate>", saloonState);
                body = body.Replace("<sphone>", saloonPhone);

                body = body.Replace("<bdate>", bookingDate);
                body = body.Replace("<btime>", bookingTime);
                body = body.Replace("<semail>", saloonEmail);

            }
            return body;
        }
    }
}