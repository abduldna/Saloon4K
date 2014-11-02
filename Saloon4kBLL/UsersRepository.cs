using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class UsersRepository
    {
        /// <summary>
        /// Insert new user in the data base.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int InsertUser(User user)
        {
            user.AddedDate = DateTime.Now.Date;
            user.ModifiedDate = DateTime.Now.Date;
            user.RecordStatus = RecordStatus.Active;
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToUsers(user);
                conn.SaveChanges();
            }
            return user.UserId;
        }

        /// <summary>
        /// Update a user in the database.
        /// </summary>
        /// <param name="nuser"></param>
        /// <returns></returns>
        public int UpdateUser(User nuser)
        {
            const string status = RecordStatus.Deleted;
            int scopeId;
            using (var conn = new Saloon4KEntities())
            {
                var user = conn.Users.FirstOrDefault(x => x.RecordStatus != status && x.UserId == nuser.UserId);
                if (user != null)
                {
                    user.About = nuser.About;
                    user.Address = nuser.Address;
                    user.City = nuser.City;
                    user.Facebook = nuser.Facebook;
                    user.Firstname = nuser.Firstname;
                    user.Lastname = nuser.Lastname;
                    user.Latitude = nuser.Latitude;
                    user.Longitude = nuser.Longitude;
                    user.ModifiedDate = DateTime.Now.Date;
                    user.Password = nuser.Password;
                    user.Phone = nuser.Phone;
                    user.RecordStatus = RecordStatus.Active;
                    user.Role = UserRoles.User;
                    user.State = nuser.State;
                    user.Username = nuser.Username;
                    user.Country = nuser.Country;
                }
                conn.SaveChanges();
                scopeId = nuser.UserId;
            }
            return scopeId;
        }
        /// <summary>
        /// Update a user in the database.
        /// </summary>
        /// <param name="deviceId"></param>
        /// /// <param name="userId"></param>
        /// <returns></returns>
        public static void UpdateUserDeviceId(string deviceId, int userId)
        {
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                var user = conn.Users.FirstOrDefault(x => x.RecordStatus != status && x.UserId == userId);
                if (user != null)
                {
                    user.DeviceId = deviceId;
                }
                conn.SaveChanges();
            }
        }

        /// <summary>
        /// Update a user in the database.
        /// </summary>
        /// <param name="nuser"></param>
        /// <returns></returns>
        public int UpdateUserForApi(User nuser)
        {
            const string status = RecordStatus.Deleted;
            int scopeId;
            using (var conn = new Saloon4KEntities())
            {
                var user = conn.Users.FirstOrDefault(x => x.RecordStatus != status && x.UserId == nuser.UserId);
                if (user != null)
                {
                    user.About = nuser.About;
                    user.Address = nuser.Address;
                    user.Facebook = nuser.Facebook;
                    user.Firstname = nuser.Firstname;
                    user.Lastname = nuser.Lastname;
                    user.ModifiedDate = nuser.ModifiedDate;
                    user.Password = nuser.Password;
                    user.Phone = nuser.Phone;
                    user.RecordStatus = nuser.RecordStatus;
                    user.Role = nuser.Role;
                    user.Country = nuser.Country;
                }
                conn.SaveChanges();
                scopeId = nuser.UserId;
            }
            return scopeId;
        }

        /// <summary>
        /// Get active user by id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static User GetUserById(int userId)
        {
            const string status = RecordStatus.Deleted;
            User user;
            using (var conn = new Saloon4KEntities())
            {
                user = conn.Users.FirstOrDefault(x => x.RecordStatus != status && x.UserId == userId);
            }
            return user;
        }
        public static User GetUserByEmail(string email)
        {
            const string status = RecordStatus.Deleted;
            User user;
            using (var conn = new Saloon4KEntities())
            {
                user = conn.Users.FirstOrDefault(x => x.RecordStatus != status && x.Username == email);
            }
            return user;
        }
        public static void DeleteUserPoints(int userId, int points)
        {
            using (var conn = new Saloon4KEntities())
            {
                var entity = conn.Users.FirstOrDefault(x => x.UserId == userId);
                if (entity != null)
                {
                    if (entity.TotalPoints > 0)
                    {
                        entity.TotalPoints = entity.TotalPoints - points;
                    }
                }
                conn.SaveChanges();
            }
        }

        public User GetUserByFacebookId(string facebookId)
        {
            const string status = RecordStatus.Deleted;
            User user;
            using (var conn = new Saloon4KEntities())
            {
                user = conn.Users.FirstOrDefault(x => x.RecordStatus != status && x.FacebookId == facebookId);
            }
            return user;
        }
        public static void InsertUserPoints(int userId, int points)
        {
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                var user = conn.Users.FirstOrDefault(x => x.RecordStatus != status && x.UserId == userId);
                if (user != null)
                {
                    if (string.IsNullOrEmpty(user.TotalPoints.ToString()))
                    {
                        user.TotalPoints = points;
                    }
                    else
                    {
                        user.TotalPoints += points;
                    }
                }
                conn.SaveChanges();
            }
        }

        /// <summary>
        /// Get all users from the database.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers(string country)
        {
            List<User> list;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.Users.Where(x => x.RecordStatus != status && x.Country == country).OrderByDescending(y => y.UserId).ToList();
            }
            return list;
        }

        public List<User> GetAllUsers()
        {
            List<User> list;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.Users.OrderByDescending(y => y.UserId).ToList();
            }
            return list;
        }

        /// <summary>
        /// Delete user based on the user id.
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUser(int userId)
        {
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                var user = conn.Users.FirstOrDefault(x => x.RecordStatus != status && x.UserId == userId);
                if (user != null) user.RecordStatus = RecordStatus.Deleted;
                conn.SaveChanges();
            }
        }

        /// <summary>
        /// Get User Order List
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ListGetUserOrderList> GetUserOrderList(int userId)
        {
            List<ListGetUserOrderList> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetUserOrderList(userId).ToList();
            }
            return list;
        }
    }
}
