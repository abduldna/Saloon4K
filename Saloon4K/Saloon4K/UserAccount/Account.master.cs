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

namespace Saloon4K.UserAccount
{
    public partial class Account : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var masterPage = Master;
            if (masterPage != null)
            {
                var lnkMySaloon4K = (HtmlAnchor)masterPage.FindControl("lnkMySaloon4K");
                if (lnkMyAvatar != null)
                {
                    lnkMySaloon4K.Attributes.Add("class", "active");
                }
                var divSlider = (HtmlGenericControl)masterPage.FindControl("divSlider");
                if (divSlider != null)
                {
                    divSlider.Visible = false;
                }
            }
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
            AddsManagement addSingle;
            if (UserSession.Current.IsUserAuthenticated)
            {
                var p = UserSession.Current.UserProfile;
                addSingle = rep.GetSingleAdd(AddPosition.One, AddAlignment.Right, Common.MySALON4K, false, p.Country);
            }
            else
            {
                addSingle = rep.GetSingleAdd(AddPosition.One, AddAlignment.Right, Common.MySALON4K, true, Session["Country"].ToString());
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