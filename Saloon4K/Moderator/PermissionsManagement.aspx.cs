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
    public partial class PermissionsManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divMessage.Visible = false;
            if (!IsPostBack)
            {
                Utilities.Helper.BindRoles(ref ddlRole);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ManagePermissionsByRole(ddlRole.SelectedValue);
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", Common.error);
            }
        }
        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRole.SelectedValue != "0")
                {
                    divPermissions.Visible = true;
                    GetPermissions(ddlRole.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
                divMessage.Attributes.Add("class", Common.error);
            }
        }
        protected void GetPermissions(string role)
        {
            var entity = PermissionsRepository.GetPermissionsByRole(role);
            if (entity != null)
            {
                hfEntityId.Value = entity.PermissionId.ToString();
                ddlDashboard.SelectedValue = entity.Dashboard;
                ddlUsers.SelectedValue = entity.Users;
                ddlDeals.SelectedValue = entity.Deals;
                ddlDirectories.SelectedValue = entity.Directories;
                ddlSalons.SelectedValue = entity.Salons;
                ddlAdds.SelectedValue = entity.Adds;
                ddlPoints.SelectedValue = entity.Points;
                ddlSystemManagers.SelectedValue = entity.SystemManagers;
            }
            else
            {
                ddlDashboard.SelectedValue = "N/A";
                ddlUsers.SelectedValue = "N/A";
                ddlDeals.SelectedValue = "N/A";
                ddlDirectories.SelectedValue = "N/A";
                ddlSalons.SelectedValue = "N/A";
                ddlAdds.SelectedValue = "N/A";
                ddlPoints.SelectedValue = "N/A";
                ddlSystemManagers.SelectedValue = "N/A";
                hfEntityId.Value = "0";
            }

        }
        protected void ManagePermissionsByRole(string role)
        {
            var entity = new Permission();
            entity.Dashboard = ddlDashboard.SelectedValue;
            entity.Users = ddlUsers.SelectedValue;
            entity.Deals = ddlDeals.SelectedValue;
            entity.Directories = ddlDirectories.SelectedValue;
            entity.Salons = ddlSalons.SelectedValue;
            entity.Adds = ddlAdds.SelectedValue;
            entity.Points = ddlPoints.SelectedValue;
            entity.SystemManagers = ddlSystemManagers.SelectedValue;           
            entity.Role = role;            
            var rep = new PermissionsRepository();
            if (hfEntityId.Value == "0")
            {
                entity.PermissionId = 0;
                rep.InsertPermissions(entity);
            }
            else
            {
                entity.PermissionId = Convert.ToInt32(hfEntityId.Value);
                rep.UpdatePermissions(entity);
            }
            divMessage.Visible = true;
            divMessage.InnerHtml = Common.RecordSave;
            divMessage.Attributes.Add("class", Common.success);
            hfEntityId.Value = "0";
        }
    }
}