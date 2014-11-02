using System;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Resources;
using Saloon4kBLL;

namespace Saloon4K
{
    public partial class Deals : Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var masterPage = Master;
            if (masterPage == null) return;
            var lnkDeals = (HtmlAnchor)masterPage.FindControl("lnkDeals");
            lnkDeals.Attributes.Add("class", "active");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
                divBookingMessage.Visible = false;
                if (!IsPostBack)
                {
                    InitializePage(false);
                    ShowAddSingle();
                    ShowPopUpAdds();
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
            }
        }

        protected void InitializePage(bool isFeatured)
        {
            var rep = new DealsRepository();
            if (isFeatured == false)
            {
                if (Request.Browser.Cookies)
                {
                    var httpCookie = Request.Cookies["countryCookies"];
                    if (httpCookie != null)
                    {
                        var dealsList = rep.GetAllDeals(httpCookie.Value);
                        if (dealsList.Count > 0)
                        {
                            rptDealsofthday.DataSource = dealsList;
                            rptDealsofthday.DataBind();
                        }
                        else
                        {
                            rptDealsofthday.DataSource = null;
                            rptDealsofthday.DataBind();
                        }
                    }
                }
                else
                {
                    if (Session["Country"] != null)
                    {
                        var dealsList = rep.GetAllDeals(Session["Country"].ToString());
                        if (dealsList.Count > 0)
                        {
                            rptDealsofthday.DataSource = dealsList;
                            rptDealsofthday.DataBind();
                        }
                        else
                        {
                            rptDealsofthday.DataSource = null;
                            rptDealsofthday.DataBind();
                        }
                    }
                }

            }
            else
            {

                if (Request.Browser.Cookies)
                {
                    var httpCookie = Request.Cookies["countryCookies"];
                    if (httpCookie != null)
                    {
                        var dealsList = rep.GetAllFeaturedDeals(httpCookie.Value);
                        if (dealsList.Count > 0)
                        {
                            rptDealsofthday.DataSource = dealsList;
                            rptDealsofthday.DataBind();
                        }
                        else
                        {
                            rptDealsofthday.DataSource = null;
                            rptDealsofthday.DataBind();
                        }
                    }
                }
                else
                {
                    if (Session["Country"] != null)
                    {
                        var dealsList = rep.GetAllFeaturedDeals(Session["Country"].ToString());
                        if (dealsList.Count > 0)
                        {
                            rptDealsofthday.DataSource = dealsList;
                            rptDealsofthday.DataBind();
                        }
                        else
                        {
                            rptDealsofthday.DataSource = null;
                            rptDealsofthday.DataBind();
                        }
                    }

                }

            }
        }

        protected void rptDealsofthday_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            try
            {
                var hfImage = (HiddenField)e.Item.FindControl("hfImage");
                var imgImage = (Image)e.Item.FindControl("imgImage");
                if (!string.IsNullOrEmpty(hfImage.Value))
                {
                    imgImage.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + @"Uploads/Deals/" + hfImage.Value;
                }
                else
                {
                    imgImage.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + @"images/NoImage.png";
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
            }
        }

        protected void rptDealsofthday_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Read")
                {
                    if (UserSession.Current.IsUserAuthenticated)
                    {
                        var p = UserSession.Current.UserProfile;
                        if (p.Role != Common.Admin)
                        {
                            btnBook.Visible = true;
                            if (Utilities.Helper.GetUserPoints(p.UserId) > 100)
                            {
                                divPoints.Visible = true;
                                Utilities.Helper.BindPoints(ref ddlPoints, Utilities.Helper.GetUserPoints(UserSession.Current.UserProfile.UserId));
                            }
                        }
                        hfUserId.Value = p.UserId.ToString();
                        hfDealId.Value = e.CommandArgument.ToString();
                        hfSalonId.Value = ((HiddenField)e.Item.FindControl("hfSalonIdRepeater")).Value;
                    }
                    var dealRep = new DealsRepository();
                    var deal = dealRep.GetDealById(Convert.ToInt32(e.CommandArgument));
                    if (deal != null)
                    {
                        lblName.InnerHtml = deal.Name;
                        lblactualPrice.InnerHtml = deal.ActualPrice.ToString();
                        lbldiscountedPrice.InnerHtml = deal.DiscountedPrice.ToString();
                        lblAddress.InnerHtml = deal.AreaOfDeal;
                        if (!string.IsNullOrEmpty(deal.Image) && deal.Image != "N/A")
                        {
                            imgDealImage.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + @"Uploads/Deals/" + deal.Image;
                        }
                        else
                        {
                            imgDealImage.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + @"images/NoImage.png";
                        }
                        var favCount = dealRep.GetFavouriteDealsCount(deal.DealId);
                        lblFavourite.InnerHtml = favCount.Count.ToString();
                        var bookedCount = dealRep.GetBookedDealsCount(deal.DealId);
                        lblBooked.InnerHtml = bookedCount.Count.ToString();
                        //Get deal salon details
                        var sRep = new SaloonsRepository();
                        var salon = sRep.GetSaloonById(Convert.ToInt32(deal.SaloonId));
                        if (salon != null)
                        {
                            lblSaloonDescription.InnerText = salon.Description.Length > 135 ? salon.Description.Substring(0, 135) : salon.Description;
                            lblSaloonEmail.InnerText = salon.Email;
                            lblSaloonName.InnerText = salon.Name;
                            lblSaloonPhone.InnerText = salon.Phone;
                        }

                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowPopUp", "ShowPopUp();", true);
                    }
                }
                else if (e.CommandName == "Favourite")
                {
                    if (UserSession.Current.IsUserAuthenticated)
                    {
                        var rep = new UserFavouriteAndBookedDealsRepository();
                        var p = UserSession.Current.UserProfile;
                        if (p.Role != Common.Admin)
                        {
                            var isFavourite = rep.GetUserFavouriteDealById(Convert.ToInt32(p.UserId), Convert.ToInt32(e.CommandArgument));
                            if (isFavourite == null)
                            {
                                var favouriteDeal = new UserFavouriteAndBookedDeal
                                {
                                    DealId = Convert.ToInt32(e.CommandArgument),
                                    IsFavourite = true,
                                    UserId = Convert.ToInt32(p.UserId)
                                };
                                rep.InsertFavouriteOrBookedDeal(favouriteDeal);
                                UsersRepository.InsertUserPoints(p.UserId, Utilities.Helper.GetPoints(Common.DealFavourite));
                                var masterPage = Master;
                                if (masterPage != null)
                                {
                                    var divPointsTotal = (HtmlGenericControl)masterPage.FindControl("divPoints");
                                    divPointsTotal.Visible = true;
                                    divPointsTotal.InnerHtml = "Points:&nbsp;" + Utilities.Helper.GetUserPoints(p.UserId);
                                }
                                divMessage.Visible = true;
                                divMessage.InnerHtml = Common.DealIsFavourite;
                                divMessage.Attributes.Add("class", " msgSuccess");
                            }
                            else
                            {
                                divMessage.Visible = true;
                                divMessage.InnerHtml = Common.AlreadyFavouriteDeal;
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

        protected void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                var rep = new UserFavouriteAndBookedDealsRepository();
                if (!string.IsNullOrEmpty(hfUserId.Value) && !string.IsNullOrEmpty(hfDealId.Value))
                {
                    var voucher = Utilities.Helper.GetVoucherCode();
                    var isBooked = rep.GetUserBookedDealById(Convert.ToInt32(hfUserId.Value), Convert.ToInt32(hfDealId.Value));
                    if (isBooked == null)
                    {
                        var bookedDeal = new UserFavouriteAndBookedDeal();
                        bookedDeal.DealId = Convert.ToInt32(hfDealId.Value);
                        bookedDeal.IsBooked = true;
                        bookedDeal.UserId = Convert.ToInt32(hfUserId.Value);
                        bookedDeal.SalonId = Convert.ToInt32(hfSalonId.Value);
                        bookedDeal.Status = DealSalonStatus.Pending;
                        if (!string.IsNullOrEmpty(ddlPoints.SelectedValue) && Convert.ToInt32(ddlPoints.SelectedValue) >= 100)
                        {
                            bookedDeal.Points = Convert.ToInt32(ddlPoints.SelectedValue);
                            bookedDeal.Voucher = voucher;
                        }
                        rep.InsertFavouriteOrBookedDeal(bookedDeal);
                        UsersRepository.InsertUserPoints(Convert.ToInt32(hfUserId.Value), Utilities.Helper.GetPoints(Common.DealBooked));
                        if (!string.IsNullOrEmpty(ddlPoints.SelectedValue) && Convert.ToInt32(ddlPoints.SelectedValue) >= 100)
                        {
                            var userVoucer = new UserVoucher();
                            userVoucer.UserId = Convert.ToInt32(hfUserId.Value);
                            userVoucer.Voucher = voucher;
                            userVoucer.EntityId = Convert.ToInt32(hfDealId.Value);
                            userVoucer.EntityType = Common.DEAL;
                            userVoucer.GeneratedDate = DateTime.Now.Date;
                            userVoucer.Points = Convert.ToInt32(Convert.ToInt32(ddlPoints.SelectedValue));
                            UserVouchersRepository.InsertUserVoucher(userVoucer);
                            UsersRepository.DeleteUserPoints(Convert.ToInt32(hfUserId.Value), Convert.ToInt32(ddlPoints.SelectedValue));
                        }
                        var masterPage = Master;
                        if (masterPage != null)
                        {
                            var upPoints = (UpdatePanel)masterPage.FindControl("upPoints");
                            var divPointsAdded = (HtmlGenericControl)masterPage.FindControl("divPoints");
                            divPointsAdded.Visible = true;
                            divPointsAdded.InnerHtml = "Points:&nbsp;" + Utilities.Helper.GetUserPoints(Convert.ToInt32(hfUserId.Value));
                            upPoints.Update();
                        }
                        SendEmail(lblName.InnerText.Trim(), lblactualPrice.InnerText.Trim(), lbldiscountedPrice.InnerText.Trim(), lblSaloonName.InnerText.Trim(), lblSaloonEmail.InnerText.Trim(), lblAddress.InnerText.Trim());
                        btnBook.Visible = false;
                        divBookingMessage.Visible = true;
                        divBookingMessage.InnerHtml = Common.DealIsBooked;
                        divBookingMessage.Attributes.Add("class", " msgSuccess marginbottomZero");
                    }
                    else
                    {
                        divBookingMessage.Visible = true;
                        divBookingMessage.InnerHtml = Common.AlreadyBookedDeal;
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
                divBookingMessage.Visible = true;
                divBookingMessage.InnerHtml = ex.Message;
                divBookingMessage.Attributes.Add("class", "msgError");
            }
        }

        protected void btnFeatured_Click(object sender, EventArgs e)
        {
            try
            {
                InitializePage(true);
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");

            }
        }

        public static bool SendEmail(string dealName, string actualPrice, string discountedPrice, string dealSalon, string salonEmail, string dealAddress)
        {
            var p = new Profile();
            if (UserSession.Current.IsUserAuthenticated)
            {
                p = UserSession.Current.UserProfile;
            }
            var mm = new MailMessage(p.Username, salonEmail, p.FirstName + " " + p.LastName + " has sent you a booking request.", MailBody(dealName, actualPrice, discountedPrice, dealSalon, dealAddress))
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

        public static string MailBody(string dealName, string actualPrice, string discountedPrice, string dealSalon, string dealAddress)
        {
            string body = "";
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplates/DealBookings.html"));
                body = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                body = body.Replace("<name>", p.FirstName + " " + p.LastName);
                body = body.Replace("<phone>", p.Phone);
                body = body.Replace("<email>", p.Username);
                body = body.Replace("<address>", p.Address);
                body = body.Replace("<city>", p.City);
                body = body.Replace("<country>", p.Country);
                body = body.Replace("<dname>", dealName);
                body = body.Replace("<ap>", actualPrice);
                body = body.Replace("<dp>", discountedPrice);
                body = body.Replace("<ds>", dealSalon);
                body = body.Replace("<daddress>", dealAddress);
            }
            return body;
        }

        protected void ShowAddSingle()
        {
            var rep = new AddsManagementRepository();
            var addSingle = new AddsManagement();
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                addSingle = rep.GetSingleAdd(AddPosition.One, AddAlignment.Right, Common.DEAL, false, p.Country);
            }
            else
            {
                if (Request.Browser.Cookies)
                {
                    var httpCookie = Request.Cookies["countryCookies"];
                    if (httpCookie != null)
                    {
                        addSingle = rep.GetSingleAdd(AddPosition.One, AddAlignment.Right, Common.DEAL, true, httpCookie.Value);
                    }
                }
                else
                {
                    addSingle = rep.GetSingleAdd(AddPosition.One, AddAlignment.Right, Common.DEAL, true, Session["Country"].ToString());
                }

            }
            if (addSingle != null)
            {
                if (!string.IsNullOrEmpty(addSingle.Image1))
                {
                    SingleImageRight.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle.Image1;
                    SingleImageRighthf.Value = addSingle.UserId + "," + addSingle.AddsManagementId + "," + addSingle.PageName;
                }
                else
                {
                    SingleImageRight.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner_verticle.jpg";
                }
            }
            else
            {
                SingleImageRight.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner_verticle.jpg";
            }
        }

        protected void ShowPopUpAdds()
        {
            var rep = new AddsManagementRepository();
            var addSingle1 = new AddsManagement();
            var addSingle2 = new AddsManagement();
            var addSingle3 = new AddsManagement();
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                addSingle1 = rep.GetSingleAdd(AddPosition.One, AddAlignment.Left, Common.POPUP, false, p.Country);
                addSingle2 = rep.GetSingleAdd(AddPosition.Two, AddAlignment.Left, Common.POPUP, false, p.Country);
                addSingle3 = rep.GetSingleAdd(AddPosition.Three, AddAlignment.Left, Common.POPUP, false, p.Country);
            }
            else
            {

                if (Request.Browser.Cookies)
                {
                    var httpCookie = Request.Cookies["countryCookies"];
                    if (httpCookie != null)
                    {
                        addSingle1 = rep.GetSingleAdd(AddPosition.One, AddAlignment.Left, Common.POPUP, true, httpCookie.Value);
                        addSingle2 = rep.GetSingleAdd(AddPosition.Two, AddAlignment.Left, Common.POPUP, true, httpCookie.Value);
                        addSingle3 = rep.GetSingleAdd(AddPosition.Three, AddAlignment.Left, Common.POPUP, true, httpCookie.Value);
                    }
                }
                else
                {
                    addSingle1 = rep.GetSingleAdd(AddPosition.One, AddAlignment.Left, Common.POPUP, true, Session["Country"].ToString());
                    addSingle2 = rep.GetSingleAdd(AddPosition.Two, AddAlignment.Left, Common.POPUP, true, Session["Country"].ToString());
                    addSingle3 = rep.GetSingleAdd(AddPosition.Three, AddAlignment.Left, Common.POPUP, true, Session["Country"].ToString());
                }

            }
            if (addSingle1 != null)
            {
                if (!string.IsNullOrEmpty(addSingle1.Image1))
                {
                    imgPopUp1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle1.Image1;
                    imgPopUp1hf.Value = addSingle1.UserId + "," + addSingle1.AddsManagementId + "," + addSingle1.PageName;
                }
                else
                {
                    imgPopUp1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner_verticle.jpg";
                }
            }
            else
            {
                imgPopUp1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner_verticle.jpg";
            }

            if (addSingle2 != null)
            {
                if (!string.IsNullOrEmpty(addSingle2.Image1))
                {
                    imgPopUp2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle2.Image1;
                    imgPopUp2hf.Value = addSingle2.UserId + "," + addSingle2.AddsManagementId + "," + addSingle2.PageName;
                }
                else
                {
                    imgPopUp2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner_verticle.jpg";
                }
            }
            else
            {
                imgPopUp2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner_verticle.jpg";
            }

            if (addSingle3 != null)
            {
                if (!string.IsNullOrEmpty(addSingle3.Image1))
                {
                    imgPopUp3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle3.Image1;
                    imgPopUp3hf.Value = addSingle3.UserId + "," + addSingle3.AddsManagementId + "," + addSingle3.PageName;
                }
                else
                {
                    imgPopUp3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner_verticle.jpg";
                }
            }
            else
            {
                imgPopUp3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner_verticle.jpg";
            }
        }

        protected void lnkReadMore_Click(object sender, EventArgs e)
        {
            try
            {
                var lnkReadMore = (LinkButton)sender;
                var hfDealIdRepeater = (HiddenField)lnkReadMore.Parent.FindControl("hfDealIdRepeater");
                var hfSalonIdRepeater = (HiddenField)lnkReadMore.Parent.FindControl("hfSalonIdRepeater");
                if (UserSession.Current.IsUserAuthenticated)
                {
                    var p = UserSession.Current.UserProfile;
                    if (p.Role != Common.Admin)
                    {
                        btnBook.Visible = true;
                        if (Utilities.Helper.GetUserPoints(p.UserId) > 100)
                        {
                            divPoints.Visible = true;
                            Utilities.Helper.BindPoints(ref ddlPoints, Utilities.Helper.GetUserPoints(UserSession.Current.UserProfile.UserId));
                        }
                    }
                    hfUserId.Value = p.UserId.ToString();
                    hfDealId.Value = hfDealIdRepeater.Value;
                    hfSalonId.Value = hfSalonIdRepeater.Value;
                }
                //Get deal details
                var dealRep = new DealsRepository();
                var deal = dealRep.GetDealById(Convert.ToInt32(hfDealIdRepeater.Value));
                if (deal != null)
                {
                    lblName.InnerHtml = deal.Name;
                    lblactualPrice.InnerHtml = deal.ActualPrice.ToString() + "AED";
                    lbldiscountedPrice.InnerText = deal.DiscountedPrice.ToString() + "AED"; ;
                    lblAddress.InnerText = deal.AreaOfDeal;
                    if (!string.IsNullOrEmpty(deal.Image) && deal.Image != "N/A")
                    {
                        imgDealImage.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + @"Uploads/Deals/" + deal.Image;
                    }
                    else
                    {
                        imgDealImage.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + @"images/NoImage.png";
                    }
                    var favCount = dealRep.GetFavouriteDealsCount(deal.DealId);
                    lblFavourite.InnerHtml = favCount.Count.ToString();
                    var bookedCount = dealRep.GetBookedDealsCount(deal.DealId);
                    lblBooked.InnerHtml = bookedCount.Count.ToString();
                    //Get deal salon details
                    var sRep = new SaloonsRepository();
                    var salon = sRep.GetSaloonById(Convert.ToInt32(deal.SaloonId));
                    if (salon != null)
                    {
                        lblSaloonDescription.InnerText = salon.Description.Length > 135 ? salon.Description.Substring(0, 135) : salon.Description;
                        lblSaloonEmail.InnerText = salon.Email;
                        lblSaloonName.InnerText = salon.Name;
                        lblSaloonPhone.InnerText = salon.Phone;
                    }

                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowPopUp", "ShowPopUp();", true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}