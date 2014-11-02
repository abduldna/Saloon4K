using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Saloon4kBLL;
using Resources;

namespace Saloon4K
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
                txtPassword.Attributes["type"] = "password";
                if (!IsPostBack)
                {
                    if (Request.Browser.Cookies)
                    {
                        var httpCookie = Request.Cookies["countryCookies"];
                        if (httpCookie != null)
                        {
                            var country = httpCookie.Value;
                            lblCountry.Text = Utilities.Helper.GetCountryNameToShow(country);
                            if (UserSession.Current.IsUserAuthenticated)
                            {
                                var p = UserSession.Current.UserProfile;
                                int totalPoints = Utilities.Helper.GetUserPoints(p.UserId);
                                divPoints.Visible = true;
                                divPoints.InnerHtml = "Points:&nbsp;" + totalPoints;
                                lnklogin.Visible = false;
                                lnkProfile.Visible = true;
                                lnkProfile.InnerHtml = p.FirstName + " " + p.LastName;
                                lnkLogout.Visible = true;
                                lnkRegister.Visible = false;
                            }
                            else
                            {
                                lnklogin.Visible = true;
                                lnkProfile.Visible = false;
                                lnkLogout.Visible = false;
                                lnkRegister.Visible = true;
                            }
                            ShowAdds();
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx", false);
                        }
                    }
                    else
                    {
                        if (Session["Country"] == null)
                        {
                            Response.Redirect("~/Default.aspx", false);

                        }
                        else
                        {
                            lblCountry.Text = Utilities.Helper.GetCountryNameToShow(Session["Country"].ToString());
                            if (UserSession.Current.IsUserAuthenticated)
                            {
                                var p = UserSession.Current.UserProfile;
                                int totalPoints = Utilities.Helper.GetUserPoints(p.UserId);
                                divPoints.Visible = true;
                                divPoints.InnerHtml = "Points:&nbsp;" + totalPoints;
                                lnklogin.Visible = false;
                                lnkProfile.Visible = true;
                                lnkProfile.InnerHtml = p.FirstName + " " + p.LastName;
                                lnkLogout.Visible = true;
                                lnkRegister.Visible = false;
                            }
                            else
                            {
                                lnklogin.Visible = true;
                                lnkProfile.Visible = false;
                                lnkLogout.Visible = false;
                                lnkRegister.Visible = true;
                            }
                            ShowAdds();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Login()
        {
            string response = Utilities.Helper.AuthenticateUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (response == "GOOD")
            {
                Profile p = UserSession.Current.UserProfile;
                divPoints.Visible = true;
                divPoints.InnerHtml = "Points:&nbsp;" + Saloon4kBLL.Utilities.Helper.GetUserPoints(p.UserId);
                lnklogin.Visible = false;
                lnkProfile.Visible = true;
                lnkLogout.Visible = true;
                lnkProfile.InnerHtml = p.FirstName + " " + p.LastName;
                lnkRegister.Visible = false;
                Response.Redirect("~/Home.aspx", false);
            }
            else
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = "Invalid username password.";
                divMessage.Attributes.Add("class", "msgError");
            }
        }

        public void ShowAdds()
        {
            var rep = new AddsManagementRepository();
            var addBanner = new AddsManagement();
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                addBanner = rep.GetBannerAdd(AddPosition.One, AddAlignment.Top, AddPosition.Two, AddAlignment.Top, AddPosition.Three, AddAlignment.Top, false, p.Country);
            }
            else
            {
                if (Request.Browser.Cookies)
                {
                    var httpCookie = Request.Cookies["countryCookies"];
                    if (httpCookie != null)
                    {
                        addBanner = rep.GetBannerAdd(AddPosition.One, AddAlignment.Top, AddPosition.Two, AddAlignment.Top, AddPosition.Three, AddAlignment.Top, true, httpCookie.Value);
                    }
                }
                else
                {
                    addBanner = rep.GetBannerAdd(AddPosition.One, AddAlignment.Top, AddPosition.Two, AddAlignment.Top, AddPosition.Three, AddAlignment.Top, true, Session["Country"].ToString());
                }

            }
            if (addBanner != null)
            {
                if (!string.IsNullOrEmpty(addBanner.Image1))
                {
                    bannerImage1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addBanner.Image1;
                    bannerImage1hf.Value = addBanner.UserId + "," + addBanner.AddsManagementId + "," + addBanner.PageName;
                }
                else
                {
                    bannerImage1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner.jpg";
                }
                if (!string.IsNullOrEmpty(addBanner.Image2))
                {
                    bannerImage2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addBanner.Image2;
                    bannerImage2hf.Value = addBanner.UserId + "," + addBanner.AddsManagementId + "," + addBanner.PageName;
                }
                else
                {
                    bannerImage2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner.jpg";
                }
                if (!string.IsNullOrEmpty(addBanner.Image3))
                {
                    bannerImage3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addBanner.Image3;
                    bannerImage3hf.Value = addBanner.UserId + "," + addBanner.AddsManagementId + "," + addBanner.PageName;
                }
                else
                {
                    bannerImage3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner.jpg";
                }
            }
            else
            {
                bannerImage1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner.jpg";
                bannerImage2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner.jpg";
                bannerImage3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner.jpg";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                Login();
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            try
            {
                UserSession.Current.UserProfile = null;
                UserSession.Current.IsUserAuthenticated = false;
                HttpContext.Current.Session.Abandon();
                Response.Redirect("~/Home.aspx", false);
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
            }
        }

        protected void lnkNewsletter_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowDivNewsletter", "ShowDivNewsletter();", true);
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnNewsletter_Click(object sender, EventArgs e)
        {
            try
            {
                var letter = new Newsletter
                    {
                        Address = txtAddress.Text.Trim(),
                        City = txtCity.Text.Trim(),
                        Country = txtCountry.Text.Trim().Replace(" ", ""),
                        Email = txtEmail.Text.Trim()
                    };
                var rep = new NewslettersRepository();
                rep.InsertNewsletter(letter);
                Response.Redirect("~/Confirmation.aspx", false);

            }
            catch (Exception ex)
            {

            }
        }
    }
}