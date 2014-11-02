using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class SaloonCategoriesRepository
    {
        /// <summary>
        /// Insert new saloon category in the data base.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int InsertSaloonCategory(SaloonCategory category)
        {
            category.AddedDate = DateTime.Now.Date;
            using (var conn = new Saloon4KEntities())
            {
                if (Utilities.Helper.IsNotCategoryBelongToSaloon(Convert.ToInt32(category.SaloonId)) == false)
                {
                    conn.AddToSaloonCategories(category);
                    conn.SaveChanges();
                }
            }
            return category.SaloonCategoryId;
        }

        public List<List_GetSaloonCategories> GetAllSaloonCategories()
        {
            List<List_GetSaloonCategories> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.GetSaloonCategories().ToList();
            }
            return list;
        }

        public List<SaloonCategory> GetAllSaloonCategoriesBySaloonId(int saloonId)
        {
            List<SaloonCategory> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.SaloonCategories.Where(x => x.SaloonId == saloonId).ToList();
            }
            return list;
        }
    }
}
