using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class UserBookedAndInterestedSaloonsRepository
    {

        public int InsertBookedSaloon(UserBookedInterestedSaloon saloon)
        {
            int scopeId;
            using (var conn = new Saloon4KEntities())
            {
                saloon.IsBooked = true;
                saloon.IsInterested = false;
                saloon.AddedDate = DateTime.Now.Date;
                conn.AddToUserBookedInterestedSaloons(saloon);
                conn.SaveChanges();
                scopeId = saloon.UserBookedInterestedSaloonId;
            }
            return scopeId;
        }

        public int InsertInterestedSaloon(UserBookedInterestedSaloon saloon)
        {
            int scopeId;
            using (var conn = new Saloon4KEntities())
            {
                saloon.IsBooked = false;
                saloon.IsInterested = true;
                saloon.AddedDate = DateTime.Now.Date;
                conn.AddToUserBookedInterestedSaloons(saloon);
                conn.SaveChanges();
                scopeId = saloon.UserBookedInterestedSaloonId;
            }
            return scopeId;
        }

        public UserBookedInterestedSaloon GetUserBookedSaloonById(int userId, int saloonId)
        {
            UserBookedInterestedSaloon saloon;
            using (var conn = new Saloon4KEntities())
            {
                saloon = conn.UserBookedInterestedSaloons.FirstOrDefault(x => x.UserId == userId && x.SaloonId == saloonId && x.IsBooked == true);
            }
            return saloon;
        }

        public UserBookedInterestedSaloon GetUserInterestedSaloonById(int userId, int saloonId)
        {
            UserBookedInterestedSaloon saloon;
            using (var conn = new Saloon4KEntities())
            {
                saloon = conn.UserBookedInterestedSaloons.FirstOrDefault(x => x.UserId == userId && x.SaloonId == saloonId && x.IsInterested == true);
            }
            return saloon;
        }

        public List<ListGetAllBookedSaloonsByUserId> GetAllBookedSaloons_ByUserId(int userId)
        {
            List<ListGetAllBookedSaloonsByUserId> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetAllBookedSaloonsByUserId(userId).ToList();
            }
            return list;
        }

        public List<ListGetAllInterestedSaloonsByUserId> GetAllInterestedSaloons_ByUserId(int userId)
        {
            List<ListGetAllInterestedSaloonsByUserId> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetAllInterestedSaloonsByUserId(userId).ToList();
            }
            return list;
        }

        public void DeleteUserInterestedSaloon(int userId, int saloonId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var saloon = conn.UserBookedInterestedSaloons.FirstOrDefault(x => x.SaloonId == saloonId && x.UserId == userId && x.IsInterested == true);
                conn.UserBookedInterestedSaloons.DeleteObject(saloon);
                conn.SaveChanges();
            }
        }

        public void DeleteUserBookedSalon(int userId, int saloonId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var saloon = conn.UserBookedInterestedSaloons.FirstOrDefault(x => x.SaloonId == saloonId && x.UserId == userId && x.IsBooked == true);
                conn.UserBookedInterestedSaloons.DeleteObject(saloon);
                conn.SaveChanges();
            }
        }

        public List<UserBookedInterestedSaloon> GetAllSalonsForBooking(int salonId)
        {
            List<UserBookedInterestedSaloon> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.UserBookedInterestedSaloons.Where(x => x.SaloonId == salonId && x.IsBooked == true).OrderByDescending(y => y.AddedDate).ToList();
            }
            return list;
        }

        public static void ChangeSalonBookingStatus(int salonId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var newDeal = conn.UserBookedInterestedSaloons.FirstOrDefault(x => x.SaloonId == salonId && x.IsBooked == true);
                if (newDeal != null)
                {

                    newDeal.Status = DealSalonStatus.Confirmed;

                }
                conn.SaveChanges();
            }
        }
    }
}
