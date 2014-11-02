using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Resources;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtPassword.Attributes["type"] = "Password";
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
               Login();
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
        }

        protected void Login()
        {            
            string response = Utilities.Helper.AuthenticateUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (response == "GOOD")
            {
                Profile p = UserSession.Current.UserProfile;
                Response.Redirect("~/Moderator/Home.aspx", false);
            }
            else
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = "Invalid username password.";
                divMessage.Attributes.Add("class", "msgError");
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
        }
    }
}