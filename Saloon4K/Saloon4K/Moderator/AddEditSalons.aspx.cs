using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Resources;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class AddEditSalons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
                hplImage1.Visible = false;
                hplImage2.Visible = false;
                hplImage3.Visible = false;
                if (!IsPostBack)
                {
                    InitializePage();
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
            var cRep = new CategoriesRepository();
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                var rep = new SaloonsRepository();
                var salon = rep.GetSaloonById(Convert.ToInt32(Utilities.Helper.Decrypt(Request.QueryString["ID"])));
                if (salon != null)
                {
                    ddlCountry.SelectedValue = salon.Country;
                    var address = salon.Address.Split('+');
                    txtAddress1.Text = address[0];
                    try
                    {
                        txtAddress2.Text = address[1];
                    }
                    catch (Exception ex)
                    {

                    }
                    txtCity.Text = salon.City;
                    txtDescription.Text = salon.Description;
                    txtLatitude.Text = salon.Latitude;
                    txtLongitude.Text = salon.Longitude;
                    txtName.Text = salon.Name;
                    txtPhone.Text = salon.Phone;
                    txtEmail.Text = salon.Email;
                    txtCountry.Text = salon.Country;
                    if (!string.IsNullOrEmpty(salon.Image1) && salon.Image1 != "N/A")
                    {
                        hplImage1.NavigateUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Saloons/" + salon.Image1;
                        hfImage1.Value = salon.Image1;
                        hplImage1.Visible = true;
                    }
                    if (!string.IsNullOrEmpty(salon.Image2) && salon.Image2 != "N/A")
                    {
                        hplImage2.NavigateUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Saloons/" + salon.Image2;
                        hfImage2.Value = salon.Image2;
                        hplImage2.Visible = true;
                    }
                    if (!string.IsNullOrEmpty(salon.Image3) && salon.Image3 != "N/A")
                    {
                        hplImage3.NavigateUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Saloons/" + salon.Image3;
                        hfImage3.Value = salon.Image3;
                        hplImage3.Visible = true;
                    }


                    var cListinner = cRep.GetAllCategories();
                    if (cListinner.Count > 0)
                    {
                        rptSaloonCategories.DataSource = cListinner;
                        rptSaloonCategories.DataBind();
                    }

                    var scRep = new SaloonCategoriesRepository();
                    var scList = scRep.GetAllSaloonCategoriesBySaloonId(salon.SaloonId);
                    if (scList.Count > 0)
                    {
                        for (int i = 0; i < scList.Count; i++)
                        {
                            foreach (RepeaterItem item in rptSaloonCategories.Items)
                            {
                                var cbCategory = (CheckBox)item.FindControl("cbCategory");
                                var hfCategoryId = (HiddenField)item.FindControl("hfCategoryId");
                                if (Convert.ToInt32(hfCategoryId.Value) == Convert.ToInt32(scList[i].CategoryId))
                                {
                                    cbCategory.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                var cList = cRep.GetAllCategories();
                if (cList.Count > 0)
                {
                    rptSaloonCategories.DataSource = cList;
                    rptSaloonCategories.DataBind();
                }
            }
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                var p = new Profile();
                if (UserSession.Current.IsUserAuthenticated)
                {
                    p = UserSession.Current.UserProfile;
                    if (ddlCountry.SelectedValue.ToLower() != txtCountry.Text.Trim().ToLower().Replace(" ", ""))
                    {
                        divMessage.Visible = true;
                        divMessage.InnerHtml = Common.InvalidCountry;
                        divMessage.Attributes.Add("class", Common.error);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                        {
                            if (fuImage1.HasFile == false && fuImage2.HasFile == false && fuImage3.HasFile == false)
                            {
                                divMessage.Visible = true;
                                divMessage.InnerHtml = "Please select an image for the salon.";
                                divMessage.Attributes.Add("class", Common.error);
                            }
                            else
                            {
                                ManageSalons(p.UserId);

                            }
                        }
                        else
                        {
                            ManageSalons(p.UserId);
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

        protected void lnkPickUpArea_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PickUpArea", "PickUpArea();", true);
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkReload_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        protected void ManageSalons(int userId)
        {
            var salon = new Saloon();
            salon.Address = txtAddress1.Text.Trim() + "+" + txtAddress2.Text.Trim();
            salon.City = txtCity.Text.Trim();
            salon.Description = txtDescription.Text.Trim();
            salon.Latitude = txtLatitude.Text.Trim();
            salon.Longitude = txtLongitude.Text.Trim();
            salon.Name = txtName.Text.Trim();
            salon.Phone = txtPhone.Text.Trim();
            salon.Email = txtEmail.Text.Trim();
            salon.Country = txtCountry.Text.Trim().Replace(" ", "");
            salon.UserId = userId;
            var rep = new SaloonsRepository();
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                if (!string.IsNullOrEmpty(hplImage1.NavigateUrl) && fuImage1.HasFile == false)
                {
                    salon.Image1 = hfImage1.Value;
                }
                else
                {
                    salon.Image1 = SaveFile(ref  fuImage1);
                }
                if (!string.IsNullOrEmpty(hplImage2.NavigateUrl) && fuImage2.HasFile == false)
                {
                    salon.Image2 = hfImage2.Value;
                }
                else
                {
                    salon.Image2 = SaveFile(ref  fuImage2);
                }
                if (!string.IsNullOrEmpty(hplImage3.NavigateUrl) && fuImage3.HasFile == false)
                {
                    salon.Image3 = hfImage3.Value;
                }
                else
                {
                    salon.Image3 = SaveFile(ref  fuImage3);
                }
                salon.SaloonId = Convert.ToInt32(Utilities.Helper.Decrypt(Request.QueryString["ID"]));
                var id = rep.UpdateSaloon(salon);
                var scRep = new SaloonCategoriesRepository();
                foreach (RepeaterItem item in rptSaloonCategories.Items)
                {
                    var sc = new SaloonCategory();
                    var cbCategory = (CheckBox)item.FindControl("cbCategory");
                    if (cbCategory != null && cbCategory.Checked)
                    {
                        var hfCategoryId = (HiddenField)item.FindControl("hfCategoryId");
                        sc.CategoryId = Convert.ToInt32(hfCategoryId.Value);
                        sc.SaloonId = id;
                        scRep.InsertSaloonCategory(sc);
                    }
                }
            }
            else
            {
                salon.Image1 = SaveFile(ref  fuImage1);
                salon.Image2 = SaveFile(ref  fuImage2);
                salon.Image3 = SaveFile(ref  fuImage3);
                var id = rep.InsertSaloon(salon);
                var scRep = new SaloonCategoriesRepository();
                foreach (RepeaterItem item in rptSaloonCategories.Items)
                {
                    var sc = new SaloonCategory();
                    var cbCategory = (CheckBox)item.FindControl("cbCategory");
                    if (cbCategory != null && cbCategory.Checked)
                    {
                        var hfCategoryId = (HiddenField)item.FindControl("hfCategoryId");
                        sc.CategoryId = Convert.ToInt32(hfCategoryId.Value);
                        sc.SaloonId = id;
                        scRep.InsertSaloonCategory(sc);
                    }
                }

            }
            Response.Redirect("~/Moderator/SearchSalons.aspx", false);
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
                var uplaodPath = Server.MapPath("~/Uploads/Saloons/" + fileName + fileExt);
                fu.SaveAs(uplaodPath);
            }
            return fileName + fileExt;
        }
    }
}