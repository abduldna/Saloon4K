using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Saloon4kBLL
{
    public class PermissionsRepository
    {
        public void InsertPermissions(Permission permission)
        {
            using (var con = new Saloon4KEntities())
            {
                con.AddToPermissions(permission);
                con.SaveChanges();
            }
        }
        public void UpdatePermissions(Permission permission)
        {
            using (var con = new Saloon4KEntities())
            {
                var entity = con.Permissions.FirstOrDefault(z => z.PermissionId == permission.PermissionId);
                if (entity != null)
                {
                    entity.Role = permission.Role;
                    entity.Dashboard = permission.Dashboard;
                    entity.Users = permission.Users;
                    entity.Deals = permission.Deals;
                    entity.Directories = permission.Directories;
                    entity.Salons = permission.Salons;
                    entity.Adds = permission.Adds;
                    entity.Points = permission.Points;
                    entity.SystemManagers = permission.SystemManagers;                    
                    con.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                con.SaveChanges();
            }
        }
        public static Permission GetPermissionsByRole(string role)
        {
            Permission entity;
            using (var con = new Saloon4KEntities())
            {
                con.Permissions.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                entity = con.Permissions.FirstOrDefault(x => x.Role == role);
            }
            return entity;
        }
        public static string GetPermissionValueByRole(string role, string moduleName)
        {
            var per = "N/A";
            using (var con = new Saloon4KEntities())
            {
                con.Permissions.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                Permission entity;
                if (moduleName == Utilities.ModuleNames.Dashboard)
                {
                    entity = con.Permissions.FirstOrDefault(x => x.Role == role);
                    if (entity != null) per = entity.Dashboard;
                }
                else if (moduleName == Utilities.ModuleNames.Users)
                {
                    entity = con.Permissions.FirstOrDefault(x => x.Role == role);
                    if (entity != null) per = entity.Users;
                }
                else if (moduleName == Utilities.ModuleNames.Deals)
                {
                    entity = con.Permissions.FirstOrDefault(x => x.Role == role);
                    if (entity != null) per = entity.Deals;
                }
                else if (moduleName == Utilities.ModuleNames.Directories)
                {
                    entity = con.Permissions.FirstOrDefault(x => x.Role == role);
                    if (entity != null) per = entity.Directories;
                }
                else if (moduleName == Utilities.ModuleNames.Salons)
                {
                    entity = con.Permissions.FirstOrDefault(x => x.Role == role);
                    if (entity != null) per = entity.Salons;
                }
                else if (moduleName == Utilities.ModuleNames.Adds)
                {
                    entity = con.Permissions.FirstOrDefault(x => x.Role == role);
                    if (entity != null) per = entity.Adds;
                }
                else if (moduleName == Utilities.ModuleNames.Points)
                {
                    entity = con.Permissions.FirstOrDefault(x => x.Role == role);
                    if (entity != null) per = entity.Points;
                }
                else if (moduleName == Utilities.ModuleNames.SystemManagers)
                {
                    entity = con.Permissions.FirstOrDefault(x => x.Role == role);
                    if (entity != null) per = entity.SystemManagers;
                }               
            }
            return per;
        }
    }
}
