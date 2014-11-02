using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class SaloonsRepository
    {
        /// <summary>
        /// Insert a new saloon in the data base.
        /// </summary>
        /// <param name="saloon"></param>
        /// <returns></returns>
        public int InsertSaloon(Saloon saloon)
        {
            int scopeId;
            saloon.RecordStatus = RecordStatus.Active;
            saloon.AddedDate = DateTime.Now.Date;
            saloon.ModifiedDate = DateTime.Now.Date;
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToSaloons(saloon);
                conn.SaveChanges();
                scopeId = saloon.SaloonId;
            }
            return scopeId;
        }

        /// <summary>
        /// Update a saloon in the database.
        /// </summary>
        /// <param name="saloon"></param>
        /// <returns></returns>
        public int UpdateSaloon(Saloon saloon)
        {
            const string status = RecordStatus.Deleted;
            int scopeId;
            using (var conn = new Saloon4KEntities())
            {
                var sl = conn.Saloons.FirstOrDefault(x => x.RecordStatus != status && x.SaloonId == saloon.SaloonId);
                if (sl != null)
                {
                    sl.Address = saloon.Address;
                    sl.City = saloon.City;
                    sl.Description = saloon.Description;
                    sl.Image1 = saloon.Image1;
                    sl.Image2 = saloon.Image2;
                    sl.Image3 = saloon.Image3;
                    sl.ModifiedDate = DateTime.Now.Date;
                    sl.Name = saloon.Name;
                    sl.RecordStatus = RecordStatus.Active;
                    sl.State = saloon.State;
                    sl.UserId = saloon.UserId;
                    sl.Latitude = saloon.Latitude;
                    sl.Longitude = saloon.Longitude;
                    sl.Phone = saloon.Phone;
                    sl.Email = saloon.Email;
                    sl.Country = saloon.Country;
                    sl.AcceptVouchers = saloon.AcceptVouchers;
                }
                conn.SaveChanges();
                scopeId = saloon.SaloonId;
            }
            return scopeId;
        }

        /// <summary>
        /// Get all active saloons from database.
        /// </summary>
        /// <returns></returns>
        public List<Saloon> GetAllSaloons(string country, bool isCountry)
        {
            const string status = RecordStatus.Deleted;
            List<Saloon> list;
            using (var conn = new Saloon4KEntities())
            {
                if (isCountry)
                {
                    list = conn.Saloons.Where(x => x.RecordStatus != status && x.Country == country).OrderByDescending(y => y.SaloonId).ToList();
                }
                else
                {
                    list = conn.Saloons.Where(x => x.RecordStatus != status).OrderByDescending(y => y.SaloonId).ToList();
                }
            }
            return list;
        }

        public List<Saloon> GetAllSaloons(string country, bool isCountry, int userId)
        {
            const string status = RecordStatus.Deleted;
            List<Saloon> list;
            using (var conn = new Saloon4KEntities())
            {
                if (isCountry)
                {
                    list = conn.Saloons.Where(x => x.RecordStatus != status && x.Country == country && x.UserId == userId).OrderByDescending(y => y.SaloonId).ToList();
                }
                else
                {
                    list = conn.Saloons.Where(x => x.RecordStatus != status && x.UserId == userId).OrderByDescending(y => y.SaloonId).ToList();
                }
            }
            return list;
        }

        public List<Saloon> GetAllSaloonsByCountryAndMonth(string country, int month)
        {
            const string status = RecordStatus.Deleted;
            List<Saloon> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.Saloons.Where(x => x.RecordStatus != status && x.Country == country && x.AddedDate.Value.Month == month).OrderByDescending(y => y.SaloonId).ToList();
            }
            return list;
        }

        /// <summary>
        /// Get a saloon by id from the database.
        /// </summary>
        /// <param name="saloonId"></param>
        /// <returns></returns>
        public Saloon GetSaloonById(int saloonId)
        {
            const string status = RecordStatus.Deleted;
            Saloon saloon;
            using (var conn = new Saloon4KEntities())
            {
                saloon = conn.Saloons.FirstOrDefault(x => x.RecordStatus != status && x.SaloonId == saloonId);
            }
            return saloon;
        }

        /// <summary>
        /// Get all saloons based on the category Id.
        /// </summary>
        /// <param name="categoryId"></param>
        /// /// <param name="countryName"></param>
        /// <returns></returns>
        public List<ListOfGetAllSaloonsByCategoryId> GetAllSaloonsByCategoryId(int categoryId, string countryName)
        {
            List<ListOfGetAllSaloonsByCategoryId> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetAllSaloonsByCategoryId(categoryId, countryName).ToList();
            }
            return list;
        }

        public void DeleteSaloon(int saloonId)
        {
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                var saloon = conn.Saloons.FirstOrDefault(x => x.RecordStatus != status && x.SaloonId == saloonId);
                if (saloon != null)
                {
                    saloon.RecordStatus = RecordStatus.Deleted;
                    conn.SaveChanges();
                }
            }
        }

        public List<ListGetAroundMeSalons> GetAroundMe(string latitude, string longitude)
        {
            List<ListGetAroundMeSalons> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetAroundMeSalons(Convert.ToInt32(100), Convert.ToInt32(1), "AddedDate DESC", Convert.ToInt32(14), Convert.ToDecimal(latitude), Convert.ToDecimal(longitude)).ToList();
            }
            return list;
        }

        public EntityGetBookedSalonsCount GetBookedSalonsCount(int salonId)
        {
            EntityGetBookedSalonsCount count;
            using (var conn = new Saloon4KEntities())
            {
                count = conn.GetBookedSalonsCount(salonId).FirstOrDefault();

            }
            return count;
        }

        public EntityGetInterestedSalonsCount GetInterestedSalonsCount(int salonId)
        {
            EntityGetInterestedSalonsCount count;
            using (var conn = new Saloon4KEntities())
            {
                count = conn.GetInterestedSalonsCount(salonId).FirstOrDefault();

            }
            return count;
        }

        public static void DeleteSalonCategoriesForUpdate(int salonId)
        {

            using (var con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (var cmd = new SqlCommand("sp_DeleteSalonCategoriesForUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@salonId", SqlDbType.Int));
                    cmd.Parameters["@salonId"].Value = salonId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
