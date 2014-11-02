using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class SalonBookings : System.Web.UI.Page
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
                var rep = new UserBookedAndInterestedSaloonsRepository();
                var list = new List<UserBookedInterestedSaloon>();
                if (SystemManagerSession.Current.SystemManagerProfile.Role == "Manager")
                {
                    list = rep.GetAllSalonsForBooking(SystemManagerSession.Current.SystemManagerProfile.SalonId);
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
                    UserBookedAndInterestedSaloonsRepository.ChangeSalonBookingStatus(Convert.ToInt32(e.CommandArgument));
                    InitializePage();
                }
            }
            catch (Exception ex)
            {

            }
        }        
    }
}