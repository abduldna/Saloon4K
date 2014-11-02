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
    public partial class Moderator : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
                {
                    if (SystemManagerSession.Current.SystemManagerProfile.Role != "Manager")
                    {
                        liPermissions.Visible = true;
                    }
                    AuthenticatePermissions(SystemManagerSession.Current.SystemManagerProfile.Role);
                }
                else
                {
                    Response.Redirect("~/Moderator/Default.aspx", false);
                }
            }
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Moderator/Default.aspx", false);
        }
        protected void AuthenticatePermissions(string role)
        {
            if (PermissionsRepository.GetPermissionValueByRole(role, Utilities.ModuleNames.Dashboard) != Common.NotAvailable)
            {
                liDashboard.Visible = true;
            }
            if (PermissionsRepository.GetPermissionValueByRole(role, Utilities.ModuleNames.Users) != Common.NotAvailable)
            {
                liUsers.Visible = true;
            }
            if (PermissionsRepository.GetPermissionValueByRole(role, Utilities.ModuleNames.Deals) != Common.NotAvailable)
            {
                liDeals.Visible = true;
            }
            if (PermissionsRepository.GetPermissionValueByRole(role, Utilities.ModuleNames.Directories) != Common.NotAvailable)
            {
                liDirectories.Visible = true;
            }
            if (PermissionsRepository.GetPermissionValueByRole(role, Utilities.ModuleNames.Salons) != Common.NotAvailable)
            {
                liSalon.Visible = true;
            }
            if (PermissionsRepository.GetPermissionValueByRole(role, Utilities.ModuleNames.Adds) != Common.NotAvailable)
            {
                liAdds.Visible = true;
            }
            if (PermissionsRepository.GetPermissionValueByRole(role, Utilities.ModuleNames.Points) != Common.NotAvailable)
            {
                liPoints.Visible = true;
            }
            if (PermissionsRepository.GetPermissionValueByRole(role, Utilities.ModuleNames.SystemManagers) != Common.NotAvailable)
            {
                liSystemManagers.Visible = true;
            }
            if (role == "Manager")
            {
                liDealBookings.Visible = true;
                liSalonBookings.Visible = true;
            }
        }
    }
}