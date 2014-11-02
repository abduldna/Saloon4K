using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class SystemManagersRepository
    {
        public static void InsertSystemManager(SystemManager systemManager)
        {
            systemManager.AddedDate = DateTime.Now.Date;
            systemManager.ModifiedDate = DateTime.Now.Date;
            systemManager.RecordStatus = RecordStatus.Active;
            using (var conn = new Saloon4KEntities())
            {
                conn.AddToSystemManagers(systemManager);
                conn.SaveChanges();
            }
        }
        public static void UpdateSystemManager(SystemManager systemManager)
        {
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                var entity = conn.SystemManagers.FirstOrDefault(x => x.RecordStatus != status && x.SystemManagerId == systemManager.SystemManagerId);
                if (entity != null)
                {
                    entity.Country = systemManager.Country;
                    entity.Gender = systemManager.Gender;
                    entity.ModifiedDate = DateTime.Now.Date;
                    entity.Name = systemManager.Name;
                    entity.Email = systemManager.Email;
                    entity.Password = systemManager.Password;
                    entity.SalonId = systemManager.SalonId;
                }
                conn.SaveChanges();
            }
        }
        public static SystemManager GetSystemManagerById(int systemManagerId)
        {
            SystemManager systemManager;
            using (var conn = new Saloon4KEntities())
            {
                systemManager = conn.SystemManagers.FirstOrDefault(x => x.SystemManagerId == systemManagerId);
            }
            return systemManager;
        }
        public static List<SystemManager> GetAllSystemManagers()
        {
            List<SystemManager> list;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                list = conn.SystemManagers.Where(x => x.RecordStatus != status).OrderByDescending(y => y.SystemManagerId).ToList();
            }
            return list;
        }
        public static void DeleteSystemManager(int systemManagerId)
        {
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                var systemManager = conn.SystemManagers.FirstOrDefault(x => x.RecordStatus != status && x.SystemManagerId == systemManagerId);
                if (systemManager != null) systemManager.RecordStatus = RecordStatus.Deleted;
                conn.SaveChanges();
            }
        }
    }
}
