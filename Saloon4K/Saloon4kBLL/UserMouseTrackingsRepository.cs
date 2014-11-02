using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class UserMouseTrackingsRepository
    {
        /// <summary>
        /// Insert new UserMouseTracking in the data base.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int InsertUserMouseTracking(UserMouseTracking entity)
        {
            entity.AddedDate = DateTime.Now.Date;
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToUserMouseTrackings(entity);
                conn.SaveChanges();
            }
            return entity.UserMouseTrackingId;
        }

        /// <summary>
        /// Get all active GetAllUserMouseTrackingsByCountry from the database.
        /// </summary>
        /// <returns></returns>
        //public List<UserMouseTracking> GetAllUserMouseTrackingsByCountry(int countryId)
        //{
        //    List<UserMouseTracking> list;
        //    using (var conn = new Saloon4KEntities())
        //    {
        //        list = conn.entityegories.Where(x => x.RecordStatus != status).OrderByDescending(y => y.UserMouseTrackingId).ToList();
        //    }
        //    return list;
        //}

        /// <summary>
        /// Get a UserMouseTracking by Id from database.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public UserMouseTracking GetUserMouseTrackingById(int entityId)
        {
            UserMouseTracking entity;
            using (var conn = new Saloon4KEntities())
            {
                entity = conn.UserMouseTrackings.FirstOrDefault(x => x.UserMouseTrackingId == entityId);
            }
            return entity;
        }
        /// <summary>
        /// Delete a UserMouseTracking from the database.
        /// </summary>
        /// <param name="entityId"></param>
        public void DeleteUserMouseTracking(int entityId)
        {            
            using (var conn = new Saloon4KEntities())
            {
                var entity = conn.UserMouseTrackings.FirstOrDefault(x => x.UserMouseTrackingId == entityId);
                conn.UserMouseTrackings.DeleteObject(entity);
                conn.SaveChanges();
            }
        }
    }
}
