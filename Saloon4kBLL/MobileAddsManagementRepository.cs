using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class MobileAddsManagementRepository
    {
        public void InsertAdd(MobileAddsManagement adds)
        {
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToMobileAddsManagements(adds);
                conn.SaveChanges();
            }

        }
        public void DeleteAdd(int addId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var add = conn.MobileAddsManagements.FirstOrDefault(x => x.MobileAddId == addId);
                if (add != null)
                {
                    conn.MobileAddsManagements.DeleteObject(add);
                    conn.SaveChanges();
                }
            }
        }
        public List<MobileAddsManagement> GetAllAdds(string country)
        {
            List<MobileAddsManagement> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.MobileAddsManagements.Where(x => x.Country == country).OrderByDescending(y => y.MobileAddId).ToList();
            }
            return list;
        }
        public bool ChangeAddStatus(int addManagementId, string status)
        {
            using (var conn = new Saloon4KEntities())
            {
                var add = conn.MobileAddsManagements.FirstOrDefault(x => x.MobileAddId == addManagementId);
                if (add != null)
                {
                    if (add.AddStatus == AddStatus.Active)
                    {
                        add.AddStatus = AddStatus.InActive;
                    }
                    else
                    {
                        if (add.StartDate >= DateTime.Today)
                        {
                            add.AddStatus = status;
                        }
                        else
                        {
                            return true;
                        }

                    }

                    conn.SaveChanges();
                }
            }
            return false;
        }
        public void ChangeStatusToInActive(int addManagementId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var add = conn.MobileAddsManagements.FirstOrDefault(x => x.MobileAddId == addManagementId);
                if (add != null)
                {

                    add.AddStatus = AddStatus.InActive;
                    conn.SaveChanges();
                }
            }
        }
        public static MobileAddsManagement GetMobileAdd(string country, string addFor, bool isPublic)
        {
            MobileAddsManagement add;
            using (var conn = new Saloon4KEntities())
            {
                add = conn.MobileAddsManagements.FirstOrDefault(x => x.Country == country && x.AddFor == addFor && x.IsPublic == isPublic && x.AddStatus == AddStatus.Active);
            }
            return add;
        }
        public bool IsPurchasedAdd(string addFor, bool isPublic, string country, DateTime date)
        {
            MobileAddsManagement add;
            using (var conn = new Saloon4KEntities())
            {
                add = conn.MobileAddsManagements.FirstOrDefault(x => x.AddFor == addFor && x.IsPublic == isPublic && x.Country == country && x.AddStatus == "Active" && x.EndDate >= date);
            }
            if (add != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
