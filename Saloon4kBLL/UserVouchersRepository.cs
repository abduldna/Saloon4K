using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class UserVouchersRepository
    {
        public static void InsertUserVoucher(UserVoucher userVoucher)
        {
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToUserVouchers(userVoucher);
                conn.SaveChanges();
            }
        }
        public static UserVoucher GetUserVoucherById(int userVoucherId)
        {
            UserVoucher userVoucher;
            using (var conn = new Saloon4KEntities())
            {
                userVoucher = conn.UserVouchers.FirstOrDefault(x => x.UserVoucherId == userVoucherId);
            }
            return userVoucher;
        }
        public static List<GetUserVouchersList> GetAllUserVouchersByUserId(int userId)
        {
            List<GetUserVouchersList> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetUserVouchers(userId).ToList();
            }
            return list;
        }
        public static void DeleteUserVoucher(int userVoucherId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var userVoucher = conn.UserVouchers.FirstOrDefault(x => x.UserVoucherId == userVoucherId);
                conn.UserVouchers.DeleteObject(userVoucher);
                conn.SaveChanges();
            }
        }
    }
}
