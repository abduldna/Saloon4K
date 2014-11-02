using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class AddsManagementRepository
    {
        /// <summary>
        /// Insert new add in the database.
        /// </summary>
        /// <param name="adds"></param>
        /// <returns></returns>
        public int InsertAdd(AddsManagement adds)
        {
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToAddsManagements(adds);
                conn.SaveChanges();
            }
            return adds.AddsManagementId;
        }

        /// <summary>
        /// Delete over due add from the data base.
        /// </summary>
        /// <param name="addId"></param>
        public void DeleteAdd(int addId)
        {
            using (var conn = new Saloon4KEntities())
            {
                var add = conn.AddsManagements.FirstOrDefault(x => x.AddsManagementId == addId);
                if (add != null)
                {
                    conn.AddsManagements.DeleteObject(add);
                    conn.SaveChanges();
                }
            }
        }

        public bool IsPurchasedSingle(string position, string alignment, string pageName, bool isPublic, string country)
        {
            AddsManagement add;
            using (var conn = new Saloon4KEntities())
            {
                add = conn.AddsManagements.FirstOrDefault(x => x.Position1 == position && x.Alignment1 == alignment && x.PageName == pageName && x.IsPublic == isPublic && x.Country == country);
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

        public bool IsPurchasedBanner(string position1, string alignment1, string position2, string alignment2, string position3, string alignment3, bool isPublic, string country)
        {
            AddsManagement add;
            using (var conn = new Saloon4KEntities())
            {
                add = conn.AddsManagements.FirstOrDefault(x => x.Position1 == position1 && x.Alignment1 == alignment1 && x.Position2 == position2 && x.Alignment2 == alignment2 && x.Position3 == position3 && x.Alignment3 == alignment3 && x.IsPublic == isPublic && x.Country == country);
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

        public List<AddsManagement> GetAllAdds(string country)
        {
            List<AddsManagement> list;
            using (var conn = new Saloon4KEntities())
            {
                list =
                    conn.AddsManagements.Where(x => x.Country == country)
                        .OrderByDescending(y => y.AddsManagementId)
                        .ToList();
            }
            return list;
        }

        public AddsManagement GetSingleAdd(string position, string alignment, string pageName, bool isPublic, string country)
        {
            AddsManagement add;
            using (var conn = new Saloon4KEntities())
            {
                add = conn.AddsManagements.FirstOrDefault(x => x.Position1 == position && x.Alignment1 == alignment && x.PageName == pageName && x.IsPublic == isPublic && x.Country == country && x.AddStatus == AddStatus.Active);
            }
            return add;
        }

        public AddsManagement GetBannerAdd(string position1, string alignment1, string position2, string alignment2, string position3, string alignment3, bool isPublic, string country)
        {
            AddsManagement add;
            using (var conn = new Saloon4KEntities())
            {
                add = conn.AddsManagements.FirstOrDefault(x => x.Position1 == position1 && x.Alignment1 == alignment1 && x.Position2 == position2 && x.Alignment2 == alignment2 && x.Position3 == position3 && x.Alignment3 == alignment3 && x.IsPublic == isPublic && x.Country == country && x.AddStatus == AddStatus.Active);
            }
            return add;
        }

        public bool ChangeAddStatus(int addManagementId, string status)
        {
            using (var conn = new Saloon4KEntities())
            {
                var add = conn.AddsManagements.FirstOrDefault(x => x.AddsManagementId == addManagementId);
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
                var add = conn.AddsManagements.FirstOrDefault(x => x.AddsManagementId == addManagementId);
                if (add != null)
                {
                   
                        add.AddStatus = AddStatus.InActive;
                        conn.SaveChanges();
                }
            }
        }
    }
}
