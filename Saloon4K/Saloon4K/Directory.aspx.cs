using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Saloon4kBLL;
using System.Configuration;
using Resources;

namespace Saloon4K
{
    public partial class Directory : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var masterPage = Master;
            if (masterPage == null) return;
            var lnkDirectory = (HtmlAnchor)masterPage.FindControl("lnkDirectory");
            lnkDirectory.Attributes.Add("class", "active");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
                if (!IsPostBack)
                {
                    InitializePage();
                    ShowAddSingle();
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");

            }
        }

        protected void InitializePage()
        {
            var rep = new CategoriesRepository();
            var list = rep.GetAllCategories();
            if (list.Count > 0)
            {
                rptCategories.DataSource = list;
                rptCategories.DataBind();
            }
            else
            {
                rptCategories.DataSource = null;
                rptCategories.DataBind();
            }
        }

        protected void rptCategories_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Details")
                {
                    var lblName = (Label)e.Item.FindControl("lblName");
                    Response.Redirect("~/DirectorySaloons.aspx?CID=" + Utilities.Helper.Encrypt(e.CommandArgument.ToString()) + "&DName=" + Utilities.Helper.Encrypt(lblName.Text));
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");

            }
        }

        protected void ShowAddSingle()
        {
            var rep = new AddsManagementRepository();
            var addSingle1=new AddsManagement();
            var addSingle2=new AddsManagement();
            var addSingle3=new AddsManagement();
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                addSingle1 = rep.GetSingleAdd(AddPosition.One, AddAlignment.Left, Common.DIRECTORY, false, p.Country);
                addSingle2 = rep.GetSingleAdd(AddPosition.Two, AddAlignment.Left, Common.DIRECTORY, false, p.Country);
                addSingle3 = rep.GetSingleAdd(AddPosition.Three, AddAlignment.Left, Common.DIRECTORY, false, p.Country);
            }
            else
            {

                if (Request.Browser.Cookies)
                {
                    var httpCookie = Request.Cookies["countryCookies"];
                    if (httpCookie != null)
                    {
                        addSingle1 = rep.GetSingleAdd(AddPosition.One, AddAlignment.Left, Common.DIRECTORY, true, httpCookie.Value);
                        addSingle2 = rep.GetSingleAdd(AddPosition.Two, AddAlignment.Left, Common.DIRECTORY, true, httpCookie.Value);
                        addSingle3 = rep.GetSingleAdd(AddPosition.Three, AddAlignment.Left, Common.DIRECTORY, true, httpCookie.Value);
                    }
                }
                else
                {
                    addSingle1 = rep.GetSingleAdd(AddPosition.One, AddAlignment.Left, Common.DIRECTORY, true, Session["Country"].ToString());
                    addSingle2 = rep.GetSingleAdd(AddPosition.Two, AddAlignment.Left, Common.DIRECTORY, true, Session["Country"].ToString());
                    addSingle3 = rep.GetSingleAdd(AddPosition.Three, AddAlignment.Left, Common.DIRECTORY, true, Session["Country"].ToString());
                }

            }
            if (addSingle1 != null)
            {
                if (!string.IsNullOrEmpty(addSingle1.Image1))
                {
                    imgLeft1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle1.Image1;
                    imgLeft1hf.Value = addSingle1.UserId + "," + addSingle1.AddsManagementId + "," + addSingle1.PageName;
                }
                else
                {
                    imgLeft1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
                }
            }
            else
            {
                imgLeft1.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
            }

            if (addSingle2 != null)
            {
                if (!string.IsNullOrEmpty(addSingle2.Image1))
                {
                    imgLeft2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle2.Image1;
                    imgLeft2hf.Value = addSingle2.UserId + "," + addSingle2.AddsManagementId + "," + addSingle2.PageName;
                }
                else
                {
                    imgLeft2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
                }
            }
            else
            {
                imgLeft2.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
            }

            if (addSingle3 != null)
            {
                if (!string.IsNullOrEmpty(addSingle3.Image1))
                {
                    imgLeft3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle3.Image1;
                    imgLeft3hf.Value = addSingle3.UserId + "," + addSingle3.AddsManagementId + "," + addSingle3.PageName;
                }
                else
                {
                    imgLeft3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
                }
            }
            else
            {
                imgLeft3.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/AddSquare.png";
            }
        }
    }
}