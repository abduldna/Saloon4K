using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Saloon4K
{
    public partial class AddType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializePage();
            }
        }

        protected void InitializePage()
        {
            try
            {                
                if (!IsPostBack)
                {
                    var masterPage = Master;
                    if (masterPage != null)
                    {
                        var divSlider = (HtmlGenericControl)masterPage.FindControl("divSlider");
                        if (divSlider != null)
                        {
                            divSlider.Visible = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

        }
    }
}