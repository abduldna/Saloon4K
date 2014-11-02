using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class CategoriesRepository
    {
        /// <summary>
        /// Insert new category in the data base.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public int InsertCategory(Category cat)
        {
            cat.AddedDate = DateTime.Now.Date;
            cat.ModifiedDate = DateTime.Now.Date;
            cat.RecordStatus = RecordStatus.Active;
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToCategories(cat);
                conn.SaveChanges();
            }
            return cat.CategoryId;
        }

        /// <summary>
        /// Update a category in the data base.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public int UpdateCategory(Category cat)
        {
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                var newCat = conn.Categories.FirstOrDefault(x => x.RecordStatus != status && x.CategoryId == cat.CategoryId);
                if (newCat != null)
                {
                    newCat.ModifiedDate = DateTime.Now.Date;
                    newCat.CategoryId = cat.CategoryId;
                    newCat.Description = cat.Description;
                    newCat.Image = cat.Image;
                    newCat.Name = cat.Name;
                    newCat.RecordStatus = RecordStatus.Active;
                    conn.SaveChanges();
                }
            }
            return cat.CategoryId;
        }

        /// <summary>
        /// Get all active categories from the database.
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategories()
        {
            const string status = RecordStatus.Deleted;
            List<Category> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.Categories.Where(x => x.RecordStatus != status).OrderByDescending(y => y.CategoryId).ToList();
            }
            return list;
        }

        /// <summary>
        /// Get a category by Id from database.
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public Category GetCategoryById(int catId)
        {
            const string status = RecordStatus.Deleted;
            Category category;
            using (var conn = new Saloon4KEntities())
            {
                category = conn.Categories.FirstOrDefault(x => x.RecordStatus != status && x.CategoryId == catId);
            }
            return category;
        }
        /// <summary>
        /// Delete a category from the database.
        /// </summary>
        /// <param name="catId"></param>
        public void DeleteCategory(int catId)
        {
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                var cat = conn.Categories.FirstOrDefault(x => x.RecordStatus != status && x.CategoryId == catId);
                if (cat != null) cat.RecordStatus = RecordStatus.Deleted;
                conn.SaveChanges();
            }
        }
    }
}
