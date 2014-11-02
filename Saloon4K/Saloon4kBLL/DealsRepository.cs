using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class DealsRepository
    {
        /// <summary>
        /// Insert new deal in the database.
        /// </summary>
        /// <param name="deal"></param>
        /// <returns></returns>
        public int InsertDeal(Deal deal)
        {
            deal.AddedDate = DateTime.Now.Date;
            deal.ModifiedDate = DateTime.Now.Date;
            deal.RecordStatus = RecordStatus.Active;
            int scopeId;
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToDeals(deal);
                conn.SaveChanges();
                scopeId = deal.DealId;
            }
            return scopeId;
        }

        /// <summary>
        /// Update a deal in the database.
        /// </summary>
        /// <param name="deal"></param>
        /// <returns></returns>
        public int UpdateDeal(Deal deal)
        {
            int scoprId;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                var newDeal = conn.Deals.FirstOrDefault(x => x.RecordStatus != null && x.RecordStatus != status && x.DealId == deal.DealId);
                if (newDeal != null)
                {
                    newDeal.AreaOfDeal = deal.AreaOfDeal;
                    newDeal.City = deal.City;
                    newDeal.Description = deal.Description;
                    newDeal.Image = deal.Image;
                    newDeal.IsDealOfTheDay = deal.IsDealOfTheDay;
                    newDeal.IsFeatured = deal.IsFeatured;
                    newDeal.ModifiedDate = DateTime.Now.Date;
                    newDeal.Name = deal.Name;
                    newDeal.RecordStatus = RecordStatus.Active;
                    newDeal.State = deal.State;
                    newDeal.Latitude = deal.Latitude;
                    newDeal.Longitude = deal.Longitude;
                    newDeal.Country = deal.Country;
                    newDeal.UserId = deal.UserId;
                    newDeal.SaloonId = deal.SaloonId;
                    newDeal.ActualPrice = deal.ActualPrice;
                    newDeal.DiscountedPrice = deal.DiscountedPrice;
                }
                conn.SaveChanges();
                scoprId = deal.DealId;
            }
            return scoprId;
        }

        /// <summary>
        /// Get all active deals from the database.
        /// </summary>
        /// <returns></returns>
        public List<Deal> GetAllDeals(string country)
        {
            List<Deal> list;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.Deals.Where(x => x.RecordStatus != status && x.Country == country).OrderByDescending(y => y.DealId).ToList();
            }
            return list;
        }

        public List<Deal> GetAllDealsByCountryAndMonth(string country, int month)
        {
            const string status = RecordStatus.Deleted;
            List<Deal> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.Deals.Where(x => x.RecordStatus != status && x.Country == country && x.AddedDate.Value.Month == month).OrderByDescending(y => y.SaloonId).ToList();
            }
            return list;
        }

        /// <summary>
        /// Get all deals of the day
        /// </summary>
        /// <returns></returns>
        public List<Deal> GetAllDealsOfTheDay(string country)
        {
            List<Deal> list;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.Deals.Where(x => x.RecordStatus != status && x.IsDealOfTheDay == true && x.Country == country).OrderByDescending(y => y.DealId).ToList();
            }
            return list;
        }

        /// <summary>
        /// Get all active and featured deals from the database.
        /// </summary>
        /// <returns></returns>
        public List<Deal> GetAllFeaturedDeals(string country)
        {
            List<Deal> list;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.Deals.Where(x => x.RecordStatus != status && x.IsFeatured == true && x.Country == country).OrderByDescending(y => y.DealId).ToList();
            }
            return list;
        }

        /// <summary>
        /// Get a deal by id from the database.
        /// </summary>
        /// <param name="dealId"></param>
        /// <returns></returns>
        public Deal GetDealById(int dealId)
        {
            Deal deal;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                deal = conn.Deals.FirstOrDefault(x => x.RecordStatus != status && x.DealId == dealId);
            }
            return deal;
        }

        public EntityGetDealDetailByIdForService GetDealByIdForService(int dealId)
        {
            EntityGetDealDetailByIdForService deal;            
            using (var conn = new Saloon4KEntities())
            {
                deal = conn.GetDealDetailByIdForService(dealId).FirstOrDefault();
            }
            return deal;
        }

        /// <summary>
        /// Delete a property from the database.
        /// </summary>
        /// <param name="dealId"></param>
        public void DeleteDeal(int dealId)
        {
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                var deal = conn.Deals.FirstOrDefault(x => x.RecordStatus != status);
                if (deal != null) deal.RecordStatus = RecordStatus.Deleted;
                conn.SaveChanges();
            }
        }

        public EntityGetFavouriteDealsCount GetFavouriteDealsCount(int dealId)
        {
            EntityGetFavouriteDealsCount count;
            using (var conn = new Saloon4KEntities())
            {
                count = conn.GetFavouriteDealsCount(dealId).FirstOrDefault();

            }
            return count;
        }
        
        public EntityGetBookedDealsCount GetBookedDealsCount(int dealId)
        {
            EntityGetBookedDealsCount count;
            using (var conn = new Saloon4KEntities())
            {
                count = conn.GetBookedDealsCount(dealId).FirstOrDefault();

            }
            return count;
        }

    }
}
