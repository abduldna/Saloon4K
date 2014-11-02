using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class AdminDashboardRepository
    {
        /// <summary>
        /// Get Registered Users Count For Admin Dashboard
        /// </summary>
        /// <returns></returns>
        public List<ListGetRegisteresUsersCountForAdminDashboard> GetRegisteresUsersCountForAdminDashboard(string country, string month)
        {
            List<ListGetRegisteresUsersCountForAdminDashboard> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetRegisteresUsersCountForAdminDashboard(country, month).ToList();
            }
            return list;
        }

        /// <summary>
        /// Get Salons Graph For Admin
        /// </summary>
        /// <param name="country"></param>        
        /// <param name="month"></param>
        /// <returns></returns>
        public List<ListGetSalonsGraphForAdmin> GetSalonsGraphForAdmin(string country, string month)
        {
            List<ListGetSalonsGraphForAdmin> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetSalonsGraphForAdmin(country, month).ToList();
            }
            return list;
        }

        /// <summary>
        /// Get deals graph for admin
        /// </summary>
        /// <param name="country"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public List<ListGetDealsGraphForAdmin> GetDealsGraphForAdmin(string country, string month)
        {
            List<ListGetDealsGraphForAdmin> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetDealsGraphForAdmin(country, month).ToList();
            }
            return list;
        }

        /// <summary>
        /// Get Newsletters for admin dashboard
        /// </summary>
        /// <param name="country"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public List<ListGetNewsLettersForDashboard> GetNewsLettersForAdmin(string country, string month)
        {
            List<ListGetNewsLettersForDashboard> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetNewsLettersForAdmin(country, month).ToList();
            }
            return list;
        }
        public List<GetUserLikeAddsList> GetUserAddList(string country)
        {
            List<GetUserLikeAddsList> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetUserLikeAdds(country).ToList();
            }
            return list;
        }
    }
}
