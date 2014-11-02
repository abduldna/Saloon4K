using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class UserFavouriteAndBookedDealsRepository
    {
        /// <summary>
        /// Insert new Favourite or Booked deal in the database.
        /// </summary>
        /// <param name="deal"></param>
        /// <returns></returns>
        public int InsertFavouriteOrBookedDeal(UserFavouriteAndBookedDeal deal)
        {
            int scopeId;
            using (var conn = new Saloon4KEntities())
            {
                deal.AddedDate = DateTime.Now.Date;
                conn.AddToUserFavouriteAndBookedDeals(deal);
                conn.SaveChanges();
                scopeId = deal.UserFavouriteBookedDealId;
            }
            return scopeId;
        }

        /// <summary>
        /// Get user booked deal by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dealId"></param>
        /// <returns></returns>
        public UserFavouriteAndBookedDeal GetUserBookedDealById(int userId, int dealId)
        {
            UserFavouriteAndBookedDeal deal;
            using (var conn = new Saloon4KEntities())
            {
                deal = conn.UserFavouriteAndBookedDeals.FirstOrDefault(x => x.UserId == userId && x.DealId == dealId && x.IsBooked == true);
            }
            return deal;
        }

        /// <summary>
        /// Get user favourite deal by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dealId"></param>
        /// <returns></returns>
        public UserFavouriteAndBookedDeal GetUserFavouriteDealById(int userId, int dealId)
        {
            UserFavouriteAndBookedDeal deal;
            using (var conn = new Saloon4KEntities())
            {
                deal = conn.UserFavouriteAndBookedDeals.FirstOrDefault(x => x.UserId == userId && x.DealId == dealId && x.IsFavourite == true);
            }
            return deal;
        }

        /// <summary>
        /// Get all favourite deals of a user by user id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ListGetAllFavouriteDealsByUserId> GetAllFavouriteDeals_ByUserId(int userId)
        {
            List<ListGetAllFavouriteDealsByUserId> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetAllFavouriteDealsByUserId(userId).ToList();
            }
            return list;
        }

        /// <summary>
        /// Get all booked deals of a user by user id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ListGetAllBookedDealsByUserId> GetAllBookedDeals_ByUserId(int userId)
        {
            List<ListGetAllBookedDealsByUserId> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetAllBookedDealsByUserId(userId).ToList();
            }
            return list;
        }

        public void DeleteUserFavouriteDeal(int userId, int dealId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var deal = conn.UserFavouriteAndBookedDeals.FirstOrDefault(x => x.DealId == dealId && x.UserId == userId && x.IsFavourite == true);
                conn.UserFavouriteAndBookedDeals.DeleteObject(deal);
                conn.SaveChanges();
            }
        }

        public void DeleteUserBookedDeal(int userId, int dealId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var deal = conn.UserFavouriteAndBookedDeals.FirstOrDefault(x => x.DealId == dealId && x.UserId == userId && x.IsBooked == true);
                conn.UserFavouriteAndBookedDeals.DeleteObject(deal);
                conn.SaveChanges();
            }
        }

        public List<UserFavouriteAndBookedDeal> GetAllDealsForBooking(int salonId)
        {
            List<UserFavouriteAndBookedDeal> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.UserFavouriteAndBookedDeals.Where(x => x.SalonId == salonId && x.IsBooked == true).OrderByDescending(y => y.AddedDate).ToList();
            }
            return list;
        }

        public static void ChangeDealStatus(int dealId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var newDeal = conn.UserFavouriteAndBookedDeals.FirstOrDefault(x => x.DealId == dealId && x.IsBooked == true);
                if (newDeal != null)
                {

                    newDeal.Status = DealSalonStatus.Confirmed;

                }
                conn.SaveChanges();
            }
        }
    }
}
