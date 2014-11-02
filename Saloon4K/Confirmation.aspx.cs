using System;
using System.Web.UI.HtmlControls;
using Saloon4kBLL;
using Resources;

namespace Saloon4K
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        ConfirmRegistration();
                    }
                    else
                    {
                        divMessage.Visible = true;
                        divMessage.InnerHtml = Common.AccountCreated;
                        divMessage.Attributes.Add("class", "msgSuccess");
                    }

                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ConfirmRegistration()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                var inRep = new IntermediateUsersRepository();
                var inUser = inRep.GetInterMediateUserById(Convert.ToInt32(Utilities.Helper.Decrypt(Request.QueryString["ID"])));
                if (inUser != null)
                {
                    var user = new User
                        {
                            About = inUser.About,
                            AddedDate = inUser.AddedDate,
                            Address = inUser.Address,
                            Facebook = inUser.Facebook,
                            FacebookId = "",
                            Firstname = inUser.Firstname,
                            Lastname = inUser.Lastname,
                            Latitude = inUser.Latitude,
                            Longitude = inUser.Longitude,
                            City = inUser.City,
                            State = inUser.State,
                            ModifiedDate = inUser.ModifiedDate,
                            Password = inUser.Password,
                            Phone = inUser.Phone,
                            RecordStatus = inUser.RecordStatus,
                            Role = inUser.Role,
                            Username = inUser.Username,
                            Country = inUser.Country,
                            DeviceId = ""
                        };
                    var userRep = new UsersRepository();
                    var scopeId = userRep.InsertUser(user);
                    if (scopeId != 0)
                    {
                        Login(user.Username, Utilities.Helper.Decrypt(user.Password));
                    }
                }
            }
        }

        protected void Login(string userName, string password)
        {
            string response = Utilities.Helper.AuthenticateUser(userName, password);
            if (response == "GOOD")
            {
                var p = UserSession.Current.UserProfile;

                var masterPage = Master;
                if (masterPage != null)
                {
                    var lnklogin = (HtmlAnchor)masterPage.FindControl("lnklogin");
                    var lnkProfile = (HtmlAnchor)masterPage.FindControl("lnkProfile");
                    var lnkRegister = (HtmlAnchor)masterPage.FindControl("lnkRegister");
                    lnklogin.Visible = false;
                    lnkProfile.Visible = true;
                    lnkProfile.InnerHtml = p.FirstName + " " + p.LastName;
                    lnkRegister.Visible = false;
                }
                Response.Redirect("~/Home.aspx", false);
            }
        }
    }
}