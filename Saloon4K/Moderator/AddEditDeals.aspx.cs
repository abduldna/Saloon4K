using System;
using System.Configuration;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushSharp;
using PushSharp.Apple;
using System.Net.Security;
using Saloon4kBLL;
using Resources;

namespace Saloon4K.Moderator
{
    public partial class AddEditDeals : Page
    {
        protected string TablePermission = "E";
        protected void Page_Load(object sender, EventArgs e)
        {
            divMessage.Visible = false;
            hplImage.Visible = false;
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

        protected void InitializePage()
        {
            Utilities.Helper.BindCountries(ref ddlCountry);
            Utilities.Helper.SetPleaseSelect(ref ddlCountry);
            var sRep = new SaloonsRepository();
            var sList = sRep.GetAllSaloons(null, false);
            if (sList.Count > 0)
            {
                ddlSalon.DataSource = sList;
                ddlSalon.DataTextField = "Name";
                ddlSalon.DataValueField = "SaloonId";
                ddlSalon.DataBind();
                Utilities.Helper.SetPleaseSelect(ref ddlSalon);
            }
            if (SystemManagerSession.Current.SystemManagerProfile.Role == "Manager")
            {
                ddlSalon.SelectedValue = SystemManagerSession.Current.SystemManagerProfile.SalonId.ToString();
                ddlSalon.Enabled = false;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                var rep = new DealsRepository();
                var deal = rep.GetDealById(Convert.ToInt32(Utilities.Helper.Decrypt(Request.QueryString["ID"])));
                if (deal != null)
                {
                    ddlCountry.SelectedValue = deal.Country;
                    ddlSalon.SelectedValue = deal.SaloonId.ToString();
                    var address = deal.AreaOfDeal.Split('+');
                    txtAddress1.Text = address[0];
                    try
                    {
                        txtAddress2.Text = address[1];
                    }
                    catch (Exception ex)
                    {

                    }

                    txtCity.Text = deal.City;
                    txtDescription.Text = deal.Description;
                    txtLatitude.Text = deal.Latitude;
                    txtLongitude.Text = deal.Longitude;
                    txtName.Text = deal.Name;
                    txtCountry.Text = deal.Country;
                    txtActualPrice.Text = deal.ActualPrice.ToString();
                    txtDiscountedPrice.Text = deal.DiscountedPrice.ToString();
                    cbAcceptVouchers.Checked = Convert.ToBoolean(deal.AcceptVouchers);
                    if (!string.IsNullOrEmpty(deal.Image))
                    {
                        hplImage.NavigateUrl = ConfigurationManager.AppSettings["SiteUrl"] + "Uploads/Deals/" + deal.Image;
                        hfImage.Value = deal.Image;
                        hplImage.Visible = true;
                    }
                    if (!string.IsNullOrEmpty(deal.IsDealOfTheDay.ToString()))
                    {
                        cbIsDealOfTheDay.Checked = Convert.ToBoolean(deal.IsDealOfTheDay);
                    }
                    if (!string.IsNullOrEmpty(deal.IsFeatured.ToString()))
                    {
                        cbIsFeatured.Checked = Convert.ToBoolean(deal.IsFeatured);
                    }
                }
            }
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserSession.Current.IsUserAuthenticated)
                {
                    if (ddlCountry.SelectedValue.ToLower() != txtCountry.Text.ToLower())
                    {
                        divMessage.Visible = true;
                        divMessage.InnerHtml = Common.InvalidCountry;
                        divMessage.Attributes.Add("class", Common.error);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                        {
                            if (fuImage.HasFile == false)
                            {
                                divMessage.Visible = true;
                                divMessage.InnerHtml = "Please select an image for the deal.";
                                divMessage.Attributes.Add("class", Common.error);
                            }
                            else
                            {
                                ManageDeals(SystemManagerSession.Current.SystemManagerProfile.SystemManagerId);
                            }
                        }
                        else
                        {
                            ManageDeals(SystemManagerSession.Current.SystemManagerProfile.SystemManagerId);
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
                divMessage.InnerHtml = ex.Message;
                divMessage.Visible = true;
                divMessage.Attributes.Add("class", Common.error);
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

        protected void ManageDeals(int userId)
        {
            var deal = new Deal();
            deal.AreaOfDeal = txtAddress1.Text.Trim() + "+" + txtAddress2.Text.Trim();
            deal.City = txtCity.Text.Trim();
            deal.Description = txtDescription.Text.Trim();
            deal.IsDealOfTheDay = cbIsDealOfTheDay.Checked;
            deal.IsFeatured = cbIsFeatured.Checked;
            deal.Latitude = txtLatitude.Text.Trim();
            deal.Longitude = txtLongitude.Text.Trim();
            deal.Name = txtName.Text.Trim();
            deal.Country = txtCountry.Text.Trim().Replace(" ", "");
            deal.UserId = userId;
            deal.SaloonId = Convert.ToInt32(ddlSalon.SelectedValue);
            deal.ActualPrice = Convert.ToDecimal(txtActualPrice.Text.Trim());
            deal.DiscountedPrice = Convert.ToDecimal(txtDiscountedPrice.Text.Trim());
            deal.AcceptVouchers = cbAcceptVouchers.Checked;
            var rep = new DealsRepository();
            var ret = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                if (!string.IsNullOrEmpty(hplImage.NavigateUrl) && fuImage.HasFile == false)
                {
                    deal.Image = hfImage.Value;
                }
                else
                {
                    deal.Image = SaveFile(ref  fuImage);
                }
                deal.DealId = Convert.ToInt32(Utilities.Helper.Decrypt(Request.QueryString["ID"]));
                ret = rep.UpdateDeal(deal);
            }
            else
            {
                deal.Image = SaveFile(ref  fuImage);
                ret = rep.InsertDeal(deal);
            }
            if (cbIsFeatured.Checked)
            {
                //wakeel
                SendPushNotifications(Convert.ToInt32(ret));
            }
            Response.Redirect("~/Moderator/SearchDeals.aspx", false);
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
                var uplaodPath = Server.MapPath("~/Uploads/Deals/" + fileName + fileExt);
                fu.SaveAs(uplaodPath);
            }
            return fileName + fileExt;
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

        protected void SendPushNotifications(int dealId)
        {
            var rep = new UsersRepository();
            var list = rep.GetAllUsers();
            if (list.Count > 0)
            {
                foreach (var user in list)
                {
                    if (!string.IsNullOrEmpty(user.DeviceId))
                    {
                        var push = new PushBroker();
                        var p12File = ConfigurationManager.AppSettings["PushNotification"];
                        var appleCert = File.ReadAllBytes(p12File);
                        bool APNSProduction = true;
                        push.StopAllServices();
                        push.RegisterAppleService(new ApplePushChannelSettings(APNSProduction, appleCert, ConfigurationManager.AppSettings["PushPassword"]));
                        push.QueueNotification(new AppleNotification().ForDeviceToken(user.DeviceId).WithAlert("New Feature Deal Added").WithBadge(1).WithSound(dealId.ToString()));
                    }
                }
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