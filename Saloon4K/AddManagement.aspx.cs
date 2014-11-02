using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Resources;
using Saloon4kBLL;

namespace Saloon4K
{
    public partial class AddManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializePage();
            }
        }

        protected void InitializePage()
        {
            try
            {
                divMessage.Visible = false;
                if (!IsPostBack)
                {
                    var masterPage = Master;
                    if (masterPage != null)
                    {
                        var divSlider = (HtmlGenericControl)masterPage.FindControl("divSlider");
                        if (divSlider != null)
                        {
                            divSlider.Visible = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        protected void btnBannerAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuImage1.HasFile == false && fuImage2.HasFile == false && fuImage3.HasFile == false)
                {
                    divMessage.Visible = true;
                    divMessage.InnerHtml = "Please select the images to proceed.";
                    divMessage.Attributes.Add("class", Common.error);
                }
                else
                {
                    if (UserSession.Current.IsUserAuthenticated)
                    {
                        var p = UserSession.Current.UserProfile;
                        BannerAddManagement(p.UserId);
                    }
                    else
                    {
                        divMessage.Visible = true;
                        divMessage.InnerHtml = Common.LoginToCompleteAction;
                        divMessage.Attributes.Add("class", Common.error);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnRightAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuSingle.HasFile == false)
                {
                    divMessage.Visible = true;
                    divMessage.InnerHtml = "Please select the image to proceed.";
                    divMessage.Attributes.Add("class", Common.error);
                }
                else
                {
                    if (UserSession.Current.IsUserAuthenticated)
                    {
                        var p = UserSession.Current.UserProfile;
                        SinglAddManagement(p.UserId);
                    }
                    else
                    {
                        divMessage.Visible = true;
                        divMessage.InnerHtml = Common.LoginToCompleteAction;
                        divMessage.Attributes.Add("class", Common.error);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void BannerAddManagement(int userId)
        {
            var add = new AddsManagement();
            add.Image1 = SaveFile(ref fuImage1);
            add.Alignment1 = AddAlignment.Top;
            add.Position1 = AddPosition.One;

            add.Image2 = SaveFile(ref fuImage2);
            add.Alignment2 = AddAlignment.Top;
            add.Position2 = AddPosition.Two;

            add.Image3 = SaveFile(ref fuImage3);
            add.Alignment3 = AddAlignment.Top;
            add.Position3 = AddPosition.Three;

            add.StartDate = Convert.ToDateTime(txtStartDate.Text.Trim());
            add.EndDate = Convert.ToDateTime(txtEndDate.Text.Trim());
            add.AddStatus = AddStatus.Open;
            add.UserId = userId;
            add.Country = hfCountryFlag.Value;
            if (cbPublic.Checked)
            {
                add.IsPublic = true;
            }
            else
            {
                add.IsPublic = false;
            }
            var rep = new AddsManagementRepository();

            var isPurchased = rep.IsPurchasedBanner(AddPosition.One, AddAlignment.Top, AddPosition.Two, AddAlignment.Top, AddPosition.Three, AddAlignment.Top, cbPublic.Checked, hfCountryFlag.Value);
            if (isPurchased == false)
            {
                rep.InsertAdd(add);
                divMessage.Visible = true;
                divMessage.InnerHtml = "Your add request has been submitted for approval.";
                divMessage.Attributes.Add("class", Common.success);
            }
            else
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = "This add is not available.";
                divMessage.Attributes.Add("class", Common.error);
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
                var uplaodPath = Server.MapPath("~/Uploads/Adds/" + fileName + fileExt);
                fu.SaveAs(uplaodPath);
            }
            return fileName + fileExt;
        }

        protected void SinglAddManagement(int userId)
        {
            var rep = new AddsManagementRepository();
            var isPurchased = false;
            var add = new AddsManagement();
            add.Image1 = SaveFile(ref fuSingle);
            if (hfPositionOfImage.Value == "RightAdd")
            {
                isPurchased = rep.IsPurchasedSingle(AddPosition.One, AddAlignment.Right, hfPageName.Value.Trim(), cbPublic.Checked, hfCountryFlag.Value.Trim());
                add.Position1 = AddPosition.One;
                add.Alignment1 = AddAlignment.Right;
            }
            else if (hfPositionOfImage.Value == "LeftAdd1")
            {
                isPurchased = rep.IsPurchasedSingle(AddPosition.One, AddAlignment.Left, hfPageName.Value.Trim(), cbPublic.Checked, hfCountryFlag.Value.Trim());
                add.Position1 = AddPosition.One;
                add.Alignment1 = AddAlignment.Left;
            }
            else if (hfPositionOfImage.Value == "LeftAdd2")
            {
                isPurchased = rep.IsPurchasedSingle(AddPosition.Two, AddAlignment.Left, hfPageName.Value.Trim(), cbPublic.Checked, hfCountryFlag.Value.Trim());
                add.Position1 = AddPosition.Two;
                add.Alignment1 = AddAlignment.Left;
            }
            else if (hfPositionOfImage.Value == "LeftAdd3")
            {
                isPurchased = rep.IsPurchasedSingle(AddPosition.Three, AddAlignment.Left, hfPageName.Value.Trim(), cbPublic.Checked, hfCountryFlag.Value.Trim());
                add.Position1 = AddPosition.Three;
                add.Alignment1 = AddAlignment.Left;
            }
            if (cbPublic.Checked)
            {
                add.IsPublic = true;
            }
            else
            {
                add.IsPublic = false;
            }
            add.Country = hfCountryFlag.Value;
            add.PageName = hfPageName.Value;
            add.StartDate = Convert.ToDateTime(txtStartDateRightAdd.Text.Trim());
            add.EndDate = Convert.ToDateTime(txtEndDateRightAdd.Text.Trim());
            add.AddStatus = AddStatus.Open;
            add.UserId = userId;
            if (isPurchased == false)
            {
                rep.InsertAdd(add);
                divMessage.Visible = true;
                divMessage.InnerHtml = "Your add request has been submitted for approval.";
                divMessage.Attributes.Add("class", Common.success);
            }
            else
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = "This add is not available.";
                divMessage.Attributes.Add("class", Common.error);
            }
        }
    }
}