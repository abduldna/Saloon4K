using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Resources;
using Saloon4kBLL;

namespace Saloon4K
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var masterPage = Master;
            if (masterPage == null) return;
            var lnkAboutUs = (HtmlAnchor)masterPage.FindControl("lnkAboutUs");
            lnkAboutUs.Attributes.Add("class", "active");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ShowAddSingle();
                }
            }
            catch (Exception ex)
            {
                    
            }
        }

        protected void ShowAddSingle()
        {
            var rep = new AddsManagementRepository();
            var addSingle=new AddsManagement();
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                addSingle = rep.GetSingleAdd(AddPosition.One, AddAlignment.Right, Common.MySALON4K, false, p.Country);
            }
            else
            {
                if (Request.Browser.Cookies)
                {
                    var httpCookie = Request.Cookies["countryCookies"];
                    if (httpCookie != null)
                    {
                        addSingle = rep.GetSingleAdd(AddPosition.One, AddAlignment.Right, Common.MySALON4K, true, httpCookie.Value);
                    }
                }
                else
                {
                    addSingle = rep.GetSingleAdd(AddPosition.One, AddAlignment.Right, Common.MySALON4K, true, Session["Country"].ToString());
                }
                
            }
            if (addSingle != null)
            {
                if (!string.IsNullOrEmpty(addSingle.Image1))
                {
                    SingleImageRight.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Adds/" + addSingle.Image1;
                    SingleImageRighthf.Value = addSingle.UserId + "," + addSingle.AddsManagementId + "," + addSingle.PageName;
                }
                else
                {
                    SingleImageRight.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner_verticle.jpg";
                }
            }
            else
            {
                SingleImageRight.ImageUrl = ConfigurationManager.AppSettings["SiteUrl"] + "images/noBanner_verticle.jpg";
            }
        }
    }
}