using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Saloon4kBLL;
using Resources;

namespace Saloon4K.Moderator
{
    public partial class UserManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divMessage.Visible = false;
                if (!IsPostBack)
                {
                    Utilities.Helper.BindCountries(ref  ddlCountry);
                    Utilities.Helper.SetPleaseSelect(ref ddlCountry);
                    InitializePage();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void InitializePage()
        {            
            var rep = new UsersRepository();
            var list = rep.GetAllUsers(ddlCountry.SelectedValue);
            if (list.Count > 0)
            {
                rptUsers.DataSource = list;
                rptUsers.DataBind();
            }
            else
            {
                rptUsers.DataSource = list;
                rptUsers.DataBind();
            }
        }

        protected void rptUsers_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    var rep = new UsersRepository();
                    rep.DeleteUser(Convert.ToInt32(e.CommandArgument));
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
                var rep = new UsersRepository();
                var list = rep.GetAllUsers(ddlCountry.SelectedValue);
                if (list.Count > 0)
                {
                    rptUsers.DataSource = list;
                    rptUsers.DataBind();
                }
                else
                {
                    rptUsers.DataSource = list;
                    rptUsers.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}