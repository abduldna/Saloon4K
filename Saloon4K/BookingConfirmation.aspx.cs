using System;
using System.Web.UI.HtmlControls;
using Saloon4kBLL;
using Resources;

namespace Saloon4K
{
    public partial class BookingConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    divMessage.Visible = true;
                    divMessage.InnerHtml = Common.AccountCreated;
                    divMessage.Attributes.Add("class", "msgSuccess");
                }
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}