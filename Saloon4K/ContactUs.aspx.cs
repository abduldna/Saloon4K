using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Resources;
using System.Web.UI.HtmlControls;

namespace Saloon4K
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            HtmlAnchor lnkContactUs = (HtmlAnchor)this.Master.FindControl("lnkContactUs");
            lnkContactUs.Attributes.Add("class", "active");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            divMessage.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                bool isSennt = Saloon4kBLL.Utilities.Helper.SendEmail(txtEmail.Text.Trim(), txtName.Text.Trim(), txtPhone.Text.Trim(), txtComments.Text.Trim(), ConfigurationManager.AppSettings["ADMIN_EMAIL"]);
                if (isSennt)
                {                    
                    divMessage.Visible = true;
                    divMessage.InnerHtml = Common.ContactUsMessageSent;
                    divMessage.Attributes.Add("class", "msgSuccess");
                    ClearFields();
                }
                else
                {
                    divMessage.Visible = true;
                    divMessage.InnerHtml = Common.RecordError;
                    divMessage.Attributes.Add("class", "msgError");
                }

            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", "msgError");
            }
            
        }

        protected void ClearFields()
        {
            txtComments.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
        }
    }
}