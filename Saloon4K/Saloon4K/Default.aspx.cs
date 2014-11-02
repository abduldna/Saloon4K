using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Resources;
using Saloon4kBLL;

namespace Saloon4K
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.Cookies)
            {
                var httpCookie = Request.Cookies["countryCookies"];
                if (httpCookie != null)
                {
                    Response.Redirect("~/Home.aspx", false);
                }
            }            
        }

        protected void lnkKuwait_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Home.aspx", false);
                Session["Country"] = Common.Kuwait;
                //Manage Cookie
                var countryCookies = new HttpCookie("countryCookies")
                    {
                        Value = Common.Kuwait,
                        Expires = DateTime.Now.AddDays(10)
                    };
                Response.Cookies.Add(countryCookies);
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkUae_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Home.aspx", false);
                Session["Country"] = Common.UAE;
                //Manage Cookie
                var countryCookies = new HttpCookie("countryCookies")
                {
                    Value = Common.UAE,
                    Expires = DateTime.Now.AddDays(10)
                };
                Response.Cookies.Add(countryCookies);
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkBahrain_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Home.aspx", false);
                Session["Country"] = Common.Bahrain;
                //Manage Cookie
                var countryCookies = new HttpCookie("countryCookies")
                {
                    Value = Common.Bahrain,
                    Expires = DateTime.Now.AddDays(10)
                };
                Response.Cookies.Add(countryCookies);
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkOman_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Home.aspx", false);
                Session["Country"] = Common.Oman;
                //Manage Cookie
                var countryCookies = new HttpCookie("countryCookies")
                {
                    Value = Common.Oman,
                    Expires = DateTime.Now.AddDays(10)
                };
                Response.Cookies.Add(countryCookies);
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkQatar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Home.aspx", false);
                Session["Country"] = Common.Qatar;
                //Manage Cookie
                var countryCookies = new HttpCookie("countryCookies")
                {
                    Value = Common.Qatar,
                    Expires = DateTime.Now.AddDays(10)
                };
                Response.Cookies.Add(countryCookies);
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkSaudiArabia_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Home.aspx", false);
                Session["Country"] = Common.SaudiArabia;
                //Manage Cookie
                var countryCookies = new HttpCookie("countryCookies")
                {
                    Value = Common.SaudiArabia,
                    Expires = DateTime.Now.AddDays(10)
                };
                Response.Cookies.Add(countryCookies);
            }
            catch (Exception ex)
            {

            }
        }
    }
}