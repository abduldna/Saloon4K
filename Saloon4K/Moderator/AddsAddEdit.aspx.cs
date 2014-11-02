using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class AddsAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
                {

                }
                else
                {
                    Response.Redirect("~/Moderator/Default.aspx", false);
                }
            }
        }
    }
}