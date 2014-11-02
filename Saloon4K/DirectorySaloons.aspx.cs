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
using Resources;

namespace Saloon4K
{
    public partial class DirectorySaloons : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    InitializePage();
                    ShowAddSingle();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void InitializePage()
        {

            if (Request.Browser.Cookies)
            {
                var httpCookie = Request.Cookies["countryCookies"];
                if (httpCookie != null)
                {
                    divDirectoryName.InnerHtml = Utilities.Helper.Decrypt(Request.QueryString["DName"]);
                    var rep = new SaloonsRepository();

                    var list = rep.GetAllSaloonsByCategoryId(Convert.ToInt32(Utilities.Helper.Decrypt(Request.QueryString["CID"])), httpCookie.Value);
                    if (list.Count > 0)
                    {
                        rptSaloons.DataSource = list;
                        rptSaloons.DataBind();
                    }
                    else
                    {
                        divMessage.Visible = true;
                        divMessage.InnerHtml = "No salon have been added in this directory!";
                        divMessage.Attributes.Add("class", Common.error);
                        rptSaloons.DataSource = null;
                        rptSaloons.DataBind();
                    }

                }
            }
            else
            {
                divDirectoryName.InnerHtml = Utilities.Helper.Decrypt(Request.QueryString["DName"]);
                var rep = new SaloonsRepository();
                if (!string.IsNullOrEmpty(Session["Country"].ToString()))
                {

                    var list = rep.GetAllSaloonsByCategoryId(Convert.ToInt32(Utilities.Helper.Decrypt(Request.QueryString["CID"])), Session["Country"].ToString());
                    if (list.Count > 0)
                    {
                        rptSaloons.DataSource = list;
                        rptSaloons.DataBind();
                    }
                    else
                    {
                        divMessage.Visible = true;
                        divMessage.InnerHtml = "No salon have been added in this directory!";
                        divMessage.Attributes.Add("class", Common.error);
                        rptSaloons.DataSource = null;
                        rptSaloons.DataBind();
                    }
                }
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
                        var p = UserSession.Current.UserProfile;
                        if (p.Role != Common.Admin)
                        {
                            btnBookPhone.Visible = true;
                            btnBookEmail.Visible = true;
                            if (Utilities.Helper.GetUserPoints(p.UserId) > 100)
                            {
                                divPoints.Visible = true;
                                Utilities.Helper.BindPoints(ref ddlPoints, Utilities.Helper.GetUserPoints(UserSession.Current.UserProfile.UserId));
                            }
                        }
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
                        hfSaloonCountry.Value = saloon.Country;
                        hfSaloonPhone.Value = saloon.Phone;
                        lblDescription.InnerHtml = "<b>Description:</b>&nbsp;" + saloon.Description;
                        lblPhone.Text = saloon.Phone;
                        lblSaloonEmail.Text = saloon.Email;

                        var bookedCount = rep.GetBookedSalonsCount(saloon.SaloonId);
                        lblBooked.InnerHtml = bookedCount.Count.ToString();
                        var interestedCount = rep.GetInterestedSalonsCount(saloon.SaloonId);
                        lblInterested.InnerHtml = interestedCount.Count.ToString();
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowPopUp", "ShowPopUp();", true);
                    }
                }
                else if (e.CommandName == "Interested")
                {
                    if (UserSession.Current.IsUserAuthenticated)
                    {
                        var rep = new UserBookedAndInterestedSaloonsRepository();
                        var p = UserSession.Current.UserProfile;
                        if (p.Role != Common.Admin)
                        {
                            var isInterested = rep.GetUserInterestedSaloonById(Convert.ToInt32(p.UserId), Convert.ToInt32(e.CommandArgument));
                            if (isInterested == null)
                            {
                                var interestedSalon = new UserBookedInterestedSaloon();
                                interestedSalon.SaloonId = Convert.ToInt32(e.CommandArgument);
                                interestedSalon.UserId = p.UserId;
                                rep.InsertInterestedSaloon(interestedSalon);
                                UsersRepository.InsertUserPoints(p.UserId, Utilities.Helper.GetPoints(Common.SaloonInterested));
                                var masterPage = Master;
                                if (masterPage != null)
                                {
                                    var divPointsTotal = (HtmlGenericControl)masterPage.FindControl("divPoints");
                                    divPointsTotal.Visible = true;
                                    divPointsTotal.InnerHtml = "Points:&nbsp;" + Utilities.Helper.GetUserPoints(p.UserId);
                                }
                                divMessage.Visible = true;
                                divMessage.InnerHtml = Common.SalonIsInterested;
                                divMessage.Attributes.Add("class", " msgSuccess");
                            }
                            else
                            {
                                divMessage.Visible = true;
                                divMessage.InnerHtml = Common.AlreadyInterested;
                                divMessage.Attributes.Add("class", " msgError");
                            }
                        }
                        else
                        {
                            divMessage.Visible = true;
                            divMessage.InnerHtml = Common.AdminNotAllowedForThisOperation;
                            divMessage.Attributes.Add("class", " msgError");
                        }

                    }
                    else
                    {
                        divMessage.Visible = true;
                        divMessage.InnerHtml = Common.LoginToCompleteAction;
                        divMessage.Attributes.Add("class", "msgError");

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
                var rep = new UserBookedAndInterestedSaloonsRepository();
                if (!string.IsNullOrEmpty(hfUserId.Value) && !string.IsNullOrEmpty(hfSaloonId.Value))
                {
                    var voucher = Utilities.Helper.GetVoucherCode();
                    var isBooked = rep.GetUserBookedSaloonById(Convert.ToInt32(hfUserId.Value), Convert.ToInt32(hfSaloonId.Value));
                    if (isBooked == null)
                    {
                        var p = UserSession.Current.UserProfile;
                        SendEmail(lblSaloonName.InnerText.Trim(), hfSaloonAddress.Value, hfSaloonCity.Value, hfSaloonCountry.Value, hfSaloonPhone.Value, txtBookingDate.Text.Trim(), txtBookingTime.Text.Trim(), lblSaloonEmail.Text.Trim());
                        var entity = new UserBookedInterestedSaloon();
                        entity.BookingDate = Convert.ToDateTime(txtBookingDate.Text.Trim());
                        entity.BookingTime = txtBookingTime.Text.Trim();
                        entity.SaloonId = Convert.ToInt32(hfSaloonId.Value);
                        entity.UserId = p.UserId;
                        entity.Status = DealSalonStatus.Pending;
                        if (!string.IsNullOrEmpty(ddlPoints.SelectedValue) && Convert.ToInt32(ddlPoints.SelectedValue) >= 100)
                        {
                            entity.Points = Convert.ToInt32(ddlPoints.SelectedValue);
                            entity.Voucher = voucher;
                        }
                        rep.InsertBookedSaloon(entity);
                        UsersRepository.InsertUserPoints(p.UserId, Utilities.Helper.GetPoints(Common.SaloonBooked));
                        if (!string.IsNullOrEmpty(ddlPoints.SelectedValue) && Convert.ToInt32(ddlPoints.SelectedValue) >= 100)
                        {
                            var userVoucer = new UserVoucher();
                            userVoucer.UserId = Convert.ToInt32(hfUserId.Value);
                            userVoucer.Voucher = voucher;
                            userVoucer.EntityId = Convert.ToInt32(hfSaloonId.Value);
                            userVoucer.EntityType = Common.DEAL;
                            userVoucer.GeneratedDate = DateTime.Now.Date;
                            userVoucer.Points = Convert.ToInt32(Convert.ToInt32(ddlPoints.SelectedValue));
                            UserVouchersRepository.InsertUserVoucher(userVoucer);
                            UsersRepository.DeleteUserPoints(Convert.ToInt32(hfUserId.Value), Convert.ToInt32(ddlPoints.SelectedValue));
                        }
                        var masterPage = Master;
                        if (masterPage != null)
                        {
                            var divPointsTotal = (HtmlGenericControl)masterPage.FindControl("divPoints");
                            divPointsTotal.Visible = true;
                            divPointsTotal.InnerHtml = "Points:&nbsp;" + Utilities.Helper.GetUserPoints(p.UserId);
                        }
                        Response.Redirect("~/SalonBookingConfirmed.aspx", false);
                    }
                    else
                    {
                        divBookingMessage.Visible = true;
                        divBookingMessage.InnerHtml = Common.SalonAlreadyBooked;
                        divBookingMessage.Attributes.Add("class", " msgError marginbottomZero");
                    }
                }
                else
                {
                    divBookingMessage.Visible = true;
                    divBookingMessage.InnerHtml = Common.LoginToCompleteAction;
                    divBookingMessage.Attributes.Add("class", " msgError marginbottomZero");
                }

            }
            catch (Exception ex)
            {

            }
        }

        public static bool SendEmail(string saloonName, string saloonAddress, string saloonCity, string saloonCountry, string saloonPhone, string bookingDate, string bookingTime, string saloonEmail)
        {
            var p = new Profile();
            if (UserSession.Current.IsUserAuthenticated)
            {
                p = UserSession.Current.UserProfile;
            }
            var mm = new MailMessage(p.Username, saloonEmail, p.FirstName + " " + p.LastName + " has sent you a message.", MailBody(saloonName, saloonAddress, saloonCity, saloonCountry, saloonPhone, bookingDate, bookingTime, saloonEmail))
            {
                IsBodyHtml = true
            };
            try
            {
                var smtp = new SmtpClient();
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

        public static string MailBody(string saloonName, string saloonAddress, string saloonCity, string saloonCountry, string saloonPhone, string bookingDate, string bookingTime, string saloonEmail)
        {
            string body = "";
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplates/SaloonBookings.html"));
                body = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                body = body.Replace("<name>", p.FirstName + " " + p.LastName);
                body = body.Replace("<address>", p.Address);
                body = body.Replace("<city>", p.City);
                body = body.Replace("<country>", p.Country);
                body = body.Replace("<phone>", p.Phone);
                body = body.Replace("<sname>", saloonName);
                body = body.Replace("<saddress>", saloonAddress);
                body = body.Replace("<scity>", saloonCity);
                body = body.Replace("<scountry>", saloonCountry);
                body = body.Replace("<sphone>", saloonPhone);
                body = body.Replace("<bdate>", bookingDate);
                body = body.Replace("<btime>", bookingTime);
                body = body.Replace("<semail>", saloonEmail);

            }
            return body;
        }

        protected void btnAnswered_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        protected void ShowAddSingle()
        {
            var rep = new AddsManagementRepository();
            var addSingle1 = new AddsManagement();
            var addSingle2 = new AddsManagement();
            var addSingle3 = new AddsManagement();
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                addSingle1 = rep.GetSingleAdd(AddPosition.One, AddAlignment.Left, Common.DIRECTORY, false, p.Country);
                addSingle2 = rep.GetSingleAdd(AddPosition.Two, AddAlignment.Left, Common.DIRECTORY, false, p.Country);
                addSingle3 = rep.GetSingleAdd(AddPosition.Three, AddAlignment.Left, Common.DIRECTORY, false, p.Country);
            }
            else
            {

                if (Request.Browser.Cookies)
                {
                    var httpCookie = Request.Cookies["countryCookies"];
                    if (httpCookie != null)
                    {
                        addSingle1 = rep.GetSingleAdd(AddPosition.One, AddAlignment.Left, Common.DIRECTORY, true, httpCookie.Value);
                        addSingle2 = rep.GetSingleAdd(AddPosition.Two, AddAlignment.Left, Common.DIRECTORY, true, httpCookie.Value);
                        addSingle3 = rep.GetSingleAdd(AddPosition.Three, AddAlignment.Left, Common.DIRECTORY, true, httpCookie.Value);
                    }
                }
                else
                {
                    addSingle1 = rep.GetSingleAdd(AddPosition.One, AddAlignment.Left, Common.DIRECTORY, true, Session["Country"].ToString());
                    addSingle2 = rep.GetSingleAdd(AddPosition.Two, AddAlignment.Left, Common.DIRECTORY, true, Session["Country"].ToString());
                    addSingle3 = rep.GetSingleAdd(AddPosition.Three, AddAlignment.Left, Common.DIRECTORY, true, Session["Country"].ToString());
                }

            }
            if (addSingle1 != null)
            {
                if (!string.IsNullOrEmpty(addSingle1.Image1))
                {
                    imgLeft1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle1.Image1;
                    imgLeft1hf.Value = addSingle1.UserId + "," + addSingle1.AddsManagementId + "," + addSingle1.PageName;
                }
                else
                {
                    imgLeft1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
                }
            }
            else
            {
                imgLeft1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
            }

            if (addSingle2 != null)
            {
                if (!string.IsNullOrEmpty(addSingle2.Image1))
                {
                    imgLeft2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle2.Image1;
                    imgLeft2hf.Value = addSingle2.UserId + "," + addSingle2.AddsManagementId + "," + addSingle2.PageName;
                }
                else
                {
                    imgLeft2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
                }
            }
            else
            {
                imgLeft2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
            }

            if (addSingle3 != null)
            {
                if (!string.IsNullOrEmpty(addSingle3.Image1))
                {
                    imgLeft3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle3.Image1;
                    imgLeft3hf.Value = addSingle3.UserId + "," + addSingle3.AddsManagementId + "," + addSingle3.PageName;
                }
                else
                {
                    imgLeft3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
                }
            }
            else
            {
                imgLeft3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
            }
        }
    }
}