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
    public partial class SearchSalons : System.Web.UI.Page
    {
        protected string TablePermission = "E";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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

            var rep = new SaloonsRepository();
            var list = new List<Saloon>();
            if (SystemManagerSession.Current.SystemManagerProfile.Role != "Manager")
            {
                list = rep.GetAllSaloons(ddlCountry.SelectedValue, true);
            }
            else
            {
                list = rep.GetAllSaloons(ddlCountry.SelectedValue, true, SystemManagerSession.Current.SystemManagerProfile.SystemManagerId);
            }
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
                if (ValidateUser())
                {
                    var rep = new SaloonsRepository();
                    var list = new List<Saloon>();
                    if (SystemManagerSession.Current.SystemManagerProfile.Role != "Manager")
                    {
                        list = rep.GetAllSaloons(ddlCountry.SelectedValue, true);
                    }
                    else
                    {
                        list = rep.GetAllSaloons(ddlCountry.SelectedValue, true, SystemManagerSession.Current.SystemManagerProfile.SystemManagerId);
                    }
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
                else
                {
                    Response.Redirect("~/Moderator/Default.aspx", false);
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
                var per = PermissionsRepository.GetPermissionValueByRole(SystemManagerSession.Current.SystemManagerProfile.Role, Utilities.ModuleNames.Salons);
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