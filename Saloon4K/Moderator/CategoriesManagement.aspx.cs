using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Saloon4kBLL;
using Resources;

namespace Saloon4K.Moderator
{
    public partial class CategoriesManagement : System.Web.UI.Page
    {
        protected string TablePermission = "E";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hplImage.Visible = false;
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

            var rep = new CategoriesRepository();
            var list = rep.GetAllCategories();
            if (list.Count > 0)
            {
                rptContent.DataSource = list;
                rptContent.DataBind();
            }
            else
            {
                rptContent.DataSource = list;
                rptContent.DataBind();
            }
        }

        protected void rptContent_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                var rep = new CategoriesRepository();
                if (e.CommandName == "Edit")
                {
                    var cat = rep.GetCategoryById(Convert.ToInt32(e.CommandArgument));
                    if (cat != null)
                    {
                        txtCategoryName.Text = cat.Name;
                        txtDescription.Text = cat.Description;
                        hfCategoryId.Value = cat.CategoryId.ToString();
                        if (!string.IsNullOrEmpty(cat.Image))
                        {
                            hplImage.NavigateUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Categories/" + cat.Image;
                            hfImage.Value = cat.Image;
                            hplImage.Visible = true;
                        }
                    }
                }
                else if (e.CommandName == "Delete")
                {
                    rep.DeleteCategory(Convert.ToInt32(e.CommandArgument));
                    InitializePage();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ManageCategories()
        {
            var cat = new Category();
            cat.Description = txtDescription.Text.Trim();
            cat.Name = txtCategoryName.Text.Trim();
            var rep = new CategoriesRepository();
            if (hfCategoryId.Value != "0")
            {
                if (!string.IsNullOrEmpty(hplImage.NavigateUrl) && fuImage.HasFile == false)
                {
                    cat.Image = hfImage.Value;
                }
                else
                {
                    cat.Image = SaveFile(ref  fuImage);
                }
                cat.CategoryId = Convert.ToInt32(hfCategoryId.Value);
                rep.UpdateCategory(cat);
            }
            else
            {
                cat.Image = SaveFile(ref  fuImage);
                rep.InsertCategory(cat);
            }
            divMessage.Visible = true;
            divMessage.InnerHtml = Common.RecordSave;
            divMessage.Attributes.Add("class", Common.success);
            txtCategoryName.Text = "";
            txtDescription.Text = "";
            InitializePage();
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuImage.HasFile == false && hfCategoryId.Value == "0")
                {
                    divMessage.Visible = true;
                    divMessage.InnerHtml = "Please select an image for the category.";
                    divMessage.Attributes.Add("class", Common.error);
                }
                else
                {
                    ManageCategories();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                txtCategoryName.Text = "";
                txtDescription.Text = "";
                hfCategoryId.Value = "0";
            }
            catch (Exception ex)
            {

            }
        }

        protected string SaveFile(ref FileUpload fu)
        {
            string fileName = "N/A";
            var fileExt = "";
            if (fu.HasFile)
            {
                var guid = Guid.NewGuid();
                var guidFirst = guid.ToString().Split('-');
                fileName = fu.PostedFile.FileName;
                fileExt = Path.GetExtension(fileName);
                fileName = guidFirst[4];
                var uplaodPath = Server.MapPath("~/Uploads/Categories/" + fileName + fileExt);
                fu.SaveAs(uplaodPath);
            }
            return fileName + fileExt;
        }
        protected bool ValidateUser()
        {
            var isValid = false;
            if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
            {
                isValid = true;
                var per = PermissionsRepository.GetPermissionValueByRole(SystemManagerSession.Current.SystemManagerProfile.Role, Utilities.ModuleNames.Directories);
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