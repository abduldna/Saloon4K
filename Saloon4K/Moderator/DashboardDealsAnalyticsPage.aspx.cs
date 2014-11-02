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
    public partial class DashboardDealsAnalyticsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
                divMessageMostUsed.Visible = false;
                if (!IsPostBack)
                {
                    if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
                    {
                        InitializePage(null, null, true);
                        Utilities.Helper.BindChartTypesWithDropDown(ref ddlChartType);
                        Utilities.Helper.BindCountries(ref ddlCountry);
                        Utilities.Helper.SetPleaseSelect(ref ddlCountry);

                        Utilities.Helper.BindChartTypesWithDropDown(ref ddlChartTypeMostUsed);
                        Utilities.Helper.BindCountries(ref ddlCountryMostUsed);
                        Utilities.Helper.SetPleaseSelect(ref ddlCountryMostUsed);
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

        protected void btnSearchMostUsed_Click(object sender, EventArgs e)
        {
            try
            {
                Utilities.Helper.BindChartType(ref ddlChartTypeMostUsed, ref ChartMostUsed, "History");
                BindMostVisitedChart();
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlChartTypeMostUsed_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Utilities.Helper.BindChartType(ref ddlChartTypeMostUsed, ref ChartMostUsed, "History");
                BindMostVisitedChart();
            }
            catch (Exception ex)
            {

            }
        }

        protected void BindMostVisitedChart()
        {
            var sRep = new DealsRepository();
            var list = sRep.GetAllDealsByCountryAndMonth(ddlCountryMostUsed.SelectedValue, Convert.ToInt32(ddlMonthMostUsed.SelectedValue));
            if (list.Count > 0)
            {
                if (rdbMostBooked.Checked)
                {
                    foreach (var item in list)
                    {
                        var yValue = sRep.GetBookedDealsCount(item.DealId);
                        if (yValue.Count != null)
                        {
                            ChartMostUsed.Series["History"].Points.AddXY(item.Name, yValue.Count);
                        }
                    }
                    ChartMostUsed.AntiAliasing = AntiAliasingStyles.Graphics;
                    ChartMostUsed.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = Color.White;
                    ChartMostUsed.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = Color.White;
                }
                else if (rdbMostInterested.Checked)
                {
                    foreach (var item in list)
                    {
                        var yValue = sRep.GetFavouriteDealsCount(item.DealId);
                        if (yValue.Count != null)
                        {
                            ChartMostUsed.Series["History"].Points.AddXY(item.Name, yValue.Count);
                        }
                    }
                    ChartMostUsed.AntiAliasing = AntiAliasingStyles.Graphics;
                    ChartMostUsed.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = Color.White;
                    ChartMostUsed.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = Color.White;
                }
            }
            else
            {
                divChart.Visible = false;
                divMessage.Visible = true;
                divMessage.InnerHtml = Common.NoDataIsAvailable;
                divMessage.Attributes.Add("class", Common.error);
            }
        }
    }
}