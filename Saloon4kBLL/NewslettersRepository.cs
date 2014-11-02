using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class NewslettersRepository
    {
        /// <summary>
        /// Insert new news letter in database.
        /// </summary>
        /// <param name="letter"></param>
        public void InsertNewsletter(Newsletter letter)
        {
            letter.AddedDate = DateTime.Now.Date;
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToNewsletters(letter);
                conn.SaveChanges();
            }
        }

        public List<Newsletter> GetAllNewsletters()
        {
            List<Newsletter> list;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.Newsletters.OrderByDescending(x => x.AddedDate).ToList();
            }
            return list;
        }
    }
}
