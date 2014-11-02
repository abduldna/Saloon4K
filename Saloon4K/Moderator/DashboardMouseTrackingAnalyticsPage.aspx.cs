using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Resources;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class DashboardMouseTrackingAnalyticsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
                if (!IsPostBack)
                {
                    if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
                    {
                        InitializePage(null, null, true);
                        Utilities.Helper.BindCountries(ref ddlCountry);
                        Utilities.Helper.SetPleaseSelect(ref ddlCountry);
                    }
                    else
                    {
                        Response.Redirect("~/Moderator/Default.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void InitializePage(string country, string month, bool isNull)
        {
            var rep = new AdminDashboardRepository();
            List<ListGetDealsGraphForAdmin> list;
            if (isNull)
            {
                list = rep.GetDealsGraphForAdmin(null, null);
            }
            else
            {
                list = rep.GetDealsGraphForAdmin(country, month);
            }
            if (list.Count > 0)
            {

            }
            else
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = Common.NoDataIsAvailable;
                divMessage.Attributes.Add("class", Common.error);
            }
        }

        protected void ddlChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var rep = new AdminDashboardRepository();
                List<GetUserLikeAddsList> list;
                list = rep.GetUserAddList(ddlCountry.SelectedValue);

                if (list.Count() > 0)
                {
                    rptAdds.DataSource = list;
                    rptAdds.DataBind();

                }
                else
                {
                    rptAdds.DataSource = list;
                    rptAdds.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}