using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Saloon4kBLL;
using Resources;

namespace Saloon4K.Moderator
{
    public partial class PointsManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
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

            var rep = new PointsRepository();
            var list = rep.GetAllPoints();
            if (list.Count > 0)
            {
                rptContent.DataSource = list;
                rptContent.DataBind();
            }
            else
            {
                rptContent.DataSource = list;
                rptContent.DataBind();
            }
            var pRep = new PointsRepository();
            var pList = pRep.GetAllPoints();
            if (pList.Count > 0)
            {
                ddlPointsFor.DataSource = pList;
                ddlPointsFor.DataTextField = "PointsFor";
                ddlPointsFor.DataValueField = "PointsFor";
                ddlPointsFor.DataBind();
                Utilities.Helper.SetPleaseSelect(ref ddlPointsFor);
            }
        }

        protected void rptContent_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                var rep = new PointsRepository();
                if (e.CommandName == "Edit")
                {
                    var point = rep.GetPointById(Convert.ToInt32(e.CommandArgument));
                    if (point != null)
                    {
                        var pRep = new PointsRepository();
                        var pList = pRep.GetAllPoints();
                        if (pList.Count > 0)
                        {
                            ddlPointsFor.DataSource = pList;
                            ddlPointsFor.DataTextField = "PointsFor";
                            ddlPointsFor.DataValueField = "PointsFor";
                            ddlPointsFor.DataBind();
                            Utilities.Helper.SetPleaseSelect(ref ddlPointsFor);
                        }
                        txtPoints.Text = point.PointsCount.ToString();
                        ddlPointsFor.SelectedValue = point.PointsFor;
                        hfPointId.Value = point.PointsId.ToString();
                    }
                }
                else if (e.CommandName == "Delete")
                {
                    rep.DeletePoint(Convert.ToInt32(e.CommandArgument));
                    InitializePage();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ManagePoints()
        {
            var point = new Point();
            point.PointsCount = Convert.ToInt32(txtPoints.Text.Trim());
            point.PointsFor = ddlPointsFor.SelectedValue;
            var rep = new PointsRepository();
            if (hfPointId.Value != "0")
            {

                point.PointsId = Convert.ToInt32(hfPointId.Value);
                rep.UpdatePoints(point);
            }
            else
            {
                rep.InsertPoints(point);
            }
            divMessage.Visible = true;
            divMessage.InnerHtml = Common.RecordSave;
            divMessage.Attributes.Add("class", Common.success);
            txtPoints.Text = "";
            ddlPointsFor.SelectedValue = "0";
            InitializePage();
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManagePoints();
            }
            catch (Exception ex)
            {

            }
        }

    }
}