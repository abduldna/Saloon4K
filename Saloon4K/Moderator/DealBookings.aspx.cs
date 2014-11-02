using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Resources;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class DealBookings : System.Web.UI.Page
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
            if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
            {
                var rep = new UserFavouriteAndBookedDealsRepository();
                var list = new List<UserFavouriteAndBookedDeal>();
                if (SystemManagerSession.Current.SystemManagerProfile.Role == "Manager")
                {
                    list = rep.GetAllDealsForBooking(SystemManagerSession.Current.SystemManagerProfile.SalonId);
                }
                if (list.Count > 0)
                {
                    rptDeals.DataSource = list;
                    rptDeals.DataBind();
                }
                else
                {
                    rptDeals.DataSource = list;
                    rptDeals.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/Moderator/Default.aspx", false);
            }
        }
        protected void rptDeals_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Confirm")
                {
                    UserFavouriteAndBookedDealsRepository.ChangeDealStatus(Convert.ToInt32(e.CommandArgument));
                    InitializePage();
                }
            }
            catch (Exception ex)
            {

            }
        }        
    }
}