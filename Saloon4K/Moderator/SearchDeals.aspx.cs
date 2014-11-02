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
    public partial class SearchDeals : System.Web.UI.Page
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
            Utilities.Helper.BindCountries(ref ddlCountry);
            Utilities.Helper.SetPleaseSelect(ref ddlCountry);
        }

        protected void rptDeals_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    Response.Redirect("~/Moderator/AddEditDeals.aspx?ID=" + Utilities.Helper.Encrypt(e.CommandArgument.ToString()));
                }
                else if (e.CommandName == "Delete")
                {
                    var rep = new DealsRepository();
                    rep.DeleteDeal(Convert.ToInt32(e.CommandArgument));
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
                    var rep = new DealsRepository();
                    var list = new List<Deal>();
                    if (SystemManagerSession.Current.SystemManagerProfile.Role != "Manager")
                    {
                        list = rep.GetAllDeals(ddlCountry.SelectedValue);
                    }
                    else
                    {
                        list = rep.GetAllDeals(ddlCountry.SelectedValue, SystemManagerSession.Current.SystemManagerProfile.SystemManagerId);
                    }

                    if (list.Count > 0)
                    {
                        rptDeals.DataSource = list;
                        rptDeals.DataBind();
                    }
                    else
                    {
                        rptDeals.DataSource = list;
                        rptDeals.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("~/Moderator/Default.aspx", false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected static bool IsFeaturedValue(object obj)
        {
            if (obj != null && Convert.ToBoolean(obj) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool ValidateUser()
        {
            var isValid = false;
            if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
            {
                isValid = true;
                var per = PermissionsRepository.GetPermissionValueByRole(SystemManagerSession.Current.SystemManagerProfile.Role, Utilities.ModuleNames.Deals);
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