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
    public partial class DashboardNewsLettersAnalytics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

        protected void InitializePage(string country, string month, bool isNull)
        {
            var rep = new AdminDashboardRepository();
            List<ListGetNewsLettersForDashboard> list;
            if (isNull)
            {
                list = rep.GetNewsLettersForAdmin(null, null);
            }
            else
            {
                list = rep.GetNewsLettersForAdmin(country, month);
            }
            if (list.Count > 0)
            {
                divChart.Visible = true;
                ChartNewslettersHistory.DataSource = list;
                ChartNewslettersHistory.DataBind();
                ChartNewslettersHistory.AntiAliasing = AntiAliasingStyles.Graphics;
                ChartNewslettersHistory.Series["History"].XValueMember = ("Address");
                ChartNewslettersHistory.Series["History"].XValueType = ChartValueType.String;
                ChartNewslettersHistory.Series["History"].YValueMembers = "Count";
                ChartNewslettersHistory.Series["History"].YValueType = ChartValueType.Int32;
                ChartNewslettersHistory.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = Color.White;
                ChartNewslettersHistory.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = Color.White;
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
                Utilities.Helper.BindChartType(ref ddlChartType, ref ChartNewslettersHistory, "History");
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
                Utilities.Helper.BindChartType(ref ddlChartType, ref ChartNewslettersHistory, "History");
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