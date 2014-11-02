using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class IntermediateUsersRepository
    {
        /// <summary>
        /// Register Intermediate User in the database.
        /// </summary>
        /// <param name="inUser"></param>
        /// <returns></returns>
        public int InsertIntermediateUser(IntermediateUser inUser)
        {
            inUser.AddedDate = DateTime.Now.Date;
            inUser.ModifiedDate = DateTime.Now.Date;
            inUser.RecordStatus = RecordStatus.Active;
            inUser.Role = UserRoles.User;
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToIntermediateUsers(inUser);
                conn.SaveChanges();
            }
            return inUser.IntermediateUserId;
        }

        public IntermediateUser GetInterMediateUserById(int inUserId)
        {
            IntermediateUser inUser;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                inUser = conn.IntermediateUsers.FirstOrDefault(x => x.RecordStatus != status && x.IntermediateUserId == inUserId);
            }
            return inUser;
        }
    }
}
