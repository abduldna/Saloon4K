using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Resources;
using Saloon4kBLL;

namespace Saloon4K.UserAccount
{
    public partial class DealsBookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
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
                var rep = new UserFavouriteAndBookedDealsRepository();
                var list = rep.GetAllBookedDeals_ByUserId(p.UserId);
                if (list.Count > 0)
                {
                    rptBookedDeals.DataSource = list;
                    rptBookedDeals.DataBind();
                }
                else
                {
                    rptBookedDeals.DataSource = null;
                    rptBookedDeals.DataBind();
                    divMessage.Visible = true;
                    divMessage.InnerHtml = "You have currently no booked items.";
                    divMessage.Attributes.Add("class", "msgError");

                }
            }
            else
            {
                Response.Redirect("~/Home.aspx", false);
            }
        }

        protected void rptBookedDeals_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                var hfImage = (HiddenField)e.Item.FindControl("hfImage");
                var imgImageDeal = (Image)e.Item.FindControl("imgImageDeal");
                if (!string.IsNullOrEmpty(hfImage.Value))
                {
                    imgImageDeal.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + @"Uploads/Deals/" + hfImage.Value;
                }
                else
                {
                    imgImageDeal.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + @"images/NoImage.png";
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
            }
        }

        protected void rptBookedDeals_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    var hfDealId = (HiddenField)e.Item.FindControl("hfDealId");
                    var hfUserId = (HiddenField)e.Item.FindControl("hfUserId");
                    Utilities.Helper.DeleteUserPoints(Convert.ToInt32(hfUserId.Value), Common.DealBooked, Convert.ToInt32(hfDealId.Value), Utilities.Helper.GetPoints(Common.DealBooked));
                    var upPoints = (UpdatePanel)this.Master.Master.FindControl("upPoints");
                    var divPoints = (HtmlGenericControl)this.Master.Master.FindControl("divPoints");
                    divPoints.Visible = true;
                    divPoints.InnerHtml = "Points:&nbsp;" + Utilities.Helper.GetUserPoints(Convert.ToInt32(hfUserId.Value));
                    upPoints.Update();
                    var rep = new UserFavouriteAndBookedDealsRepository();
                    rep.DeleteUserBookedDeal(Convert.ToInt32(hfUserId.Value), Convert.ToInt32(hfDealId.Value));
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
    }
}