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
    public partial class MyVouchers : System.Web.UI.Page
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
                var list = UserVouchersRepository.GetAllUserVouchersByUserId(p.UserId);
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
                    divMessage.InnerHtml = "You have currently no Vouchers.";
                    divMessage.Attributes.Add("class", "msgError");

                }
            }
            else
            {
                Response.Redirect("~/Home.aspx", false);
            }
        }

        protected void rptBookedDeals_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    
                    UserVouchersRepository.DeleteUserVoucher(Convert.ToInt32(e.CommandArgument));
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