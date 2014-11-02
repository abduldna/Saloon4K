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
                    InitializePage(null, null, true);
                    Utilities.Helper.BindChartTypesWithDropDown(ref ddlChartType);
                    Utilities.Helper.BindCountries(ref ddlCountry);
                    Utilities.Helper.SetPleaseSelect(ref ddlCountry);
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
                divChart.Visible = true;
                ChartDealsHistory.DataSource = list;
                ChartDealsHistory.DataBind();
                ChartDealsHistory.AntiAliasing = AntiAliasingStyles.Graphics;
                ChartDealsHistory.Series["History"].XValueMember = "AddedDate";
                ChartDealsHistory.Series["History"].XValueType = ChartValueType.Date;
                ChartDealsHistory.Series["History"].YValueMembers = "Count";
                ChartDealsHistory.Series["History"].YValueType = ChartValueType.Int32;
                ChartDealsHistory.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = Color.White;
                ChartDealsHistory.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = Color.White;
            }
            else
            {
                divChart.Visible = false;
                divMessage.Visible = true;
                divMessage.InnerHtml = Common.NoDataIsAvailable;
                divMessage.Attributes.Add("class", Common.error);
            }
        }

        protected void ddlChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Utilities.Helper.BindChartType(ref ddlChartType, ref ChartDealsHistory, "History");
                if (ddlCountry.SelectedValue != "0")
                {
                    InitializePage(ddlCountry.SelectedValue, ddlMonth.SelectedValue, false);
                }
                else
                {
                    InitializePage(null, null, true);
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
                Utilities.Helper.BindChartType(ref ddlChartType, ref ChartDealsHistory, "History");
                if (ddlCountry.SelectedValue != "0")
                {
                    InitializePage(ddlCountry.SelectedValue, ddlMonth.SelectedValue, false);
                }
                else
                {
                    InitializePage(null, null, true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}