using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class AddsSearch : System.Web.UI.Page
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

            var rep = new AddsManagementRepository();
            var list = rep.GetAllAdds(ddlCountry.SelectedValue);
            if (list.Count > 0)
            {
                rptAdds.DataSource = list;
                rptAdds.DataBind();
            }
            else
            {
                rptAdds.DataSource = list;
                rptAdds.DataBind();
            }
        }

        protected void rptAdds_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Activate")
                {
                    var rep = new AddsManagementRepository();
                    rep.ChangeAddStatus(Convert.ToInt32(e.CommandArgument), AddStatus.Active);
                    InitializePage();
                }
                else if (e.CommandName == "Delete")
                {
                    var rep = new AddsManagementRepository();
                    rep.ChangeAddStatus(Convert.ToInt32(e.CommandArgument), AddStatus.Deleted);
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
                var rep = new AddsManagementRepository();
                var list = rep.GetAllAdds(ddlCountry.SelectedValue);
                if (list.Count > 0)
                {
                    rptAdds.DataSource = list;
                    rptAdds.DataBind();
                }
                else
                {
                    rptAdds.DataSource = list;
                    rptAdds.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected static string GetUserName(object obj)
        {
            var rep = new UsersRepository();
            var user = rep.GetUserById(Convert.ToInt32(obj));
            if (user != null)
            {
                return user.Firstname + " " + user.Lastname;
            }
            else
            {
                return "N/A";
            }
        }

        protected static string GetEmail(object obj)
        {
            var rep = new UsersRepository();
            var user = rep.GetUserById(Convert.ToInt32(obj));
            if (user != null)
            {
                return user.Username;
            }
            else
            {
                return "N/A";
            }
        }

        protected static string GetPhone(object obj)
        {
            var rep = new UsersRepository();
            var user = rep.GetUserById(Convert.ToInt32(obj));
            if (user != null)
            {
                return user.Phone;
            }
            else
            {
                return "N/A";
            }
        }

        protected void rptAdds_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                var lblAddStatus = (Label)e.Item.FindControl("lblAddStatus");
                if (lblAddStatus.Text == "Open")
                {
                    lblAddStatus.CssClass = "statusOpen";
                }
                else if (lblAddStatus.Text == "Active")
                {
                    lblAddStatus.CssClass = "statusActive";
                }
                else
                {
                    lblAddStatus.CssClass = "statusDeleted";
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}