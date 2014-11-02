using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Resources;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class AddsSearch : System.Web.UI.Page
    {
        protected string TablePermission = "E";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
                if (!IsPostBack)
                {
                    if (ValidateUser())
                    {
                        Utilities.Helper.BindCountries(ref ddlCountry);
                        Utilities.Helper.SetPleaseSelect(ref ddlCountry);
                        InitializePage();
                    }
                    else
                    {
                        Response.Redirect("~/Moderator/Default.aspx", false);
                    }
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
                    bool s = rep.ChangeAddStatus(Convert.ToInt32(e.CommandArgument), AddStatus.Active);
                    if (s)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Alert", "Alert()", true);
                    }
                    else
                    {
                        InitializePage();
                    }

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
                if (ValidateUser())
                {
                    var rep = new AddsManagementRepository();
                    var list = rep.GetAllAdds(ddlCountry.SelectedValue);
                    foreach (var addsManagement in list)
                    {
                        if (addsManagement.EndDate == DateTime.Today)
                        {
                            rep.ChangeStatusToInActive(addsManagement.AddsManagementId);
                        }
                    }
                    var filteredList = rep.GetAllAdds(ddlCountry.SelectedValue);
                    if (filteredList.Count > 0)
                    {
                        if (list.Count > 0)
                        {
                            rptAdds.DataSource = filteredList;
                            rptAdds.DataBind();
                        }
                        else
                        {
                            rptAdds.DataSource = filteredList;
                            rptAdds.DataBind();
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Moderator/Default.aspx", false);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected static string GetUserName(object obj)
        {
            var name = "N/A";
            var user = UsersRepository.GetUserById(Convert.ToInt32(obj));
            if (user != null)
            {
                name = user.Firstname + " " + user.Lastname;
            }
            return name;
        }
        protected static string GetEmail(object obj)
        {
            var name = "N/A";
            var user = UsersRepository.GetUserById(Convert.ToInt32(obj));
            if (user != null)
            {
                name = user.Username;
            }
            return name;
        }
        protected static string GetPhone(object obj)
        {
            var name = "N/A";
            var user = UsersRepository.GetUserById(Convert.ToInt32(obj));
            if (user != null)
            {
                name = user.Phone;
            }
            return name;
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
        protected bool ValidateUser()
        {
            var isValid = false;
            if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
            {
                isValid = true;
                var per = PermissionsRepository.GetPermissionValueByRole(SystemManagerSession.Current.SystemManagerProfile.Role, Utilities.ModuleNames.Adds);
                if (per == Common.ReadOnly)
                {
                    TablePermission = Common.ReadOnly;
                }
                else if (per == Common.Edit)
                {
                    TablePermission = Common.Edit;
                }
                else
                {
                    Response.Redirect("~/Moderator/NoAccess.aspx", false);
                }
            }
            return isValid;
        }
    }
}