using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushSharp;
using PushSharp.Apple;
using Resources;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class SystemManagersManagement : System.Web.UI.Page
    {
        protected string TablePermission = "E";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtpassword.Attributes["type"] = "password";
                txtConfirmPassword.Attributes["type"] = "password";
                divMessage.Visible = false;
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
            var list = SystemManagersRepository.GetAllSystemManagers();
            if (list.Count > 0)
            {
                rptContent.DataSource = list;
                rptContent.DataBind();
            }
            else
            {
                rptContent.DataSource = null;
                rptContent.DataBind();
            }
        }
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageEntity();
            }
            catch (Exception ex)
            {
                divMessage.InnerHtml = ex.Message;
                divMessage.Visible = true;
                divMessage.Attributes.Add("class", Common.error);
            }
        }
        protected void ManageEntity()
        {
            var entity = new SystemManager();
            entity.Country = ddlCountry.SelectedValue;
            entity.Email = txtEmail.Text.Trim();
            entity.Gender = ddlGender.SelectedValue;
            entity.Name = txtName.Text.Trim();
            entity.Password = Utilities.Helper.Encrypt(txtpassword.Text.Trim());
            entity.Role = ddlRole.SelectedValue;
            entity.SalonId = Convert.ToInt32(ddlSalon.SelectedValue);
            if (!string.IsNullOrEmpty(hfEntityId.Value))
            {
                entity.SystemManagerId = Convert.ToInt32(hfEntityId.Value);
                SystemManagersRepository.UpdateSystemManager(entity);
            }
            else
            {
                SystemManagersRepository.InsertSystemManager(entity);
            }
            divMessage.Visible = true;
            divMessage.InnerHtml = Common.RecordSave;
            divMessage.Attributes.Add("class", Common.success);
            ClearFields();
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlSalon.Items.Clear();
                if (ddlCountry.SelectedValue != "0")
                {
                    var rep = new SaloonsRepository();
                    var sList = rep.GetAllSaloons(ddlCountry.SelectedValue, true);
                    if (sList.Count > 0)
                    {
                        ddlSalon.DataSource = sList;
                        ddlSalon.DataTextField = "Name";
                        ddlSalon.DataValueField = "SaloonId";
                        ddlSalon.DataBind();
                    }
                    Utilities.Helper.SetPleaseSelect(ref ddlSalon);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void rptContent_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    var entity = SystemManagersRepository.GetSystemManagerById(Convert.ToInt32(e.CommandArgument));
                    if (entity != null)
                    {
                        hfEntityId.Value = entity.SystemManagerId.ToString();
                        txtEmail.Text = entity.Email;
                        txtName.Text = entity.Name;
                        ddlCountry.SelectedValue = entity.Country;
                        if (ddlCountry.SelectedValue != "0")
                        {
                            var rep = new SaloonsRepository();
                            var sList = rep.GetAllSaloons(ddlCountry.SelectedValue, true);
                            if (sList.Count > 0)
                            {
                                ddlSalon.DataSource = sList;
                                ddlSalon.DataTextField = "Name";
                                ddlSalon.DataValueField = "SaloonId";
                                ddlSalon.DataBind();
                            }
                            Utilities.Helper.SetPleaseSelect(ref ddlSalon);
                        }
                        ddlSalon.SelectedValue = entity.SalonId.ToString();
                        ddlRole.SelectedValue = entity.Role;
                        ddlGender.SelectedValue = entity.Gender;
                    }
                }
                else if (e.CommandName == "Delete")
                {
                    SystemManagersRepository.DeleteSystemManager(Convert.ToInt32(e.CommandArgument));
                    InitializePage();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void ClearFields()
        {
            txtEmail.Text = "";
            txtName.Text = "";
            txtpassword.Text = "";
            txtpassword.Text = "";
            ddlCountry.SelectedValue = "0";
            ddlSalon.SelectedValue = "0";
            ddlRole.SelectedValue = "0";
            ddlGender.SelectedValue = "0";
        }
        protected bool ValidateUser()
        {
            var isValid = false;
            if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
            {
                isValid = true;
                var per = PermissionsRepository.GetPermissionValueByRole(SystemManagerSession.Current.SystemManagerProfile.Role, Utilities.ModuleNames.SystemManagers);
                if (per == Common.ReadOnly)
                {
                    TablePermission = Common.ReadOnly;
                }
                else if (per == Common.Edit)
                {
                    TablePermission = Common.Edit;
                    lnkSave.Visible = true;
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