using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Saloon4kBLL;

namespace Saloon4K.Moderator
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SystemManagerSession.Current.IsSystemManagerAuthenticated)
                {
                    Utilities.Helper.BindCountries(ref ddlCountry);
                    Utilities.Helper.SetPleaseSelect(ref ddlCountry);
                }
                else
                {
                    Response.Redirect("~/Moderator/Default.aspx", false);
                }
            }
        }

        [WebMethod]
        public static List<Deal> GetAllFeaturedDeals(string country)
        {
            var rep = new DealsRepository();
            var list = rep.GetAllFeaturedDeals(country);
            return list;
        }

        //Search featured deals
        [WebMethod]
        public static List<Deal> SearchFeaturedDeals(string from, string to, string country)
        {
            var rep = new DealsRepository();
            var list = rep.GetAllFeaturedDeals(country).Where(x => x.AddedDate >= Convert.ToDateTime(from) && x.AddedDate <= Convert.ToDateTime(to)).ToList();
            return list;
        }
        //Search deals
        [WebMethod]
        public static List<Deal> SearchDeals(string from, string to, string country)
        {
            var rep = new DealsRepository();
            var list = rep.GetAllDeals(country).Where(x => x.AddedDate >= Convert.ToDateTime(from) && x.AddedDate <= Convert.ToDateTime(to)).ToList();
            return list;
        }
        //Search Salons
        [WebMethod]
        public static List<Saloon> SearchSalons(string from, string to, string country)
        {
            var rep = new SaloonsRepository();
            var list = rep.GetAllSaloons(country, true).Where(x => x.AddedDate >= Convert.ToDateTime(from) && x.AddedDate <= Convert.ToDateTime(to)).ToList();
            return list;
        }

        //Search Users
        [WebMethod]
        public static List<User> SearchUsers(string from, string to, string country)
        {
            var rep = new UsersRepository();
            var list = rep.GetAllUsers(country).Where(x => x.AddedDate >= Convert.ToDateTime(from) && x.AddedDate <= Convert.ToDateTime(to)).ToList();
            return list;
        }

    }
}