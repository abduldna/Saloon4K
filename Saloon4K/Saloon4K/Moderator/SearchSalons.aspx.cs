using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class SearchSalons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Utilities.Helper.BindCountries(ref ddlCountry);
                    Utilities.Helper.SetPleaseSelect(ref ddlCountry);
                    InitializePage();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void InitializePage()
        {

            var rep = new SaloonsRepository();
            var list = rep.GetAllSaloons(ddlCountry.SelectedValue, true);
            if (list.Count > 0)
            {
                rptSalons.DataSource = list;
                rptSalons.DataBind();
            }
            else
            {
                rptSalons.DataSource = list;
                rptSalons.DataBind();
            }
        }

        protected void rptSalons_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    Response.Redirect("~/Moderator/AddEditSalons.aspx?ID=" + Utilities.Helper.Encrypt(e.CommandArgument.ToString()));
                }
                else if (e.CommandName == "Delete")
                {
                    var rep = new SaloonsRepository();
                    rep.DeleteSaloon(Convert.ToInt32(e.CommandArgument));
                    InitializePage();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var rep = new SaloonsRepository();
                var list = rep.GetAllSaloons(ddlCountry.SelectedValue,true);
                if (list.Count > 0)
                {
                    rptSalons.DataSource = list;
                    rptSalons.DataBind();
                }
                else
                {
                    rptSalons.DataSource = list;
                    rptSalons.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}