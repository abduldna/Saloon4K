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
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divMessage.Visible = false;
            txtpassword.Attributes["type"] = "password";
            txtConfirmPassword.Attributes["type"] = "password";
            if (!IsPostBack)
            {
                if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
                {
                    InitializePage();
                }
                else
                {
                    Response.Redirect("~/Moderator/Default.aspx", false);
                }
            }
        }
        protected void InitializePage()
        {
            Utilities.Helper.BindCountries(ref ddlCountry);
            Utilities.Helper.SetPleaseSelect(ref ddlCountry);
            var entity = SystemManagersRepository.GetSystemManagerById(SystemManagerSession.Current.SystemManagerProfile.SystemManagerId);
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
    }
}