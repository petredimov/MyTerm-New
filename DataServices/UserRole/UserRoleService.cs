using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContextNamespace.Models;
using DataContextNamespace;
using System.Data.Entity;

namespace DataServices
{
    public class UserRoleService : IUserRoleService
    {
        public UserRole GetUserRole(int id)
        {
            using (var context = new DataContext())
            {
                return context.UserRoles.FirstOrDefault(c => c.Id == id);
            }
        }

        public List<UserRole> GetUserRoles()
        {
            using (var context = new DataContext())
            {
                return context.UserRoles.ToList();
            }
        }

        public UserRole InsertUserRole(UserRole userRole)
        {
            using (var context = new DataContext())
            {
                UserRole newUserRole = context.UserRoles.Add(userRole);
                context.SaveChanges();
                return newUserRole;
            }
        }

        public void RemoveUserRole(int id)
        {
            using (var context = new DataContext())
            {
                UserRole userRole = context.UserRoles.FirstOrDefault(c => c.Id == id);
                if (userRole != null)
                {
                    context.UserRoles.Remove(userRole);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateTerm(UserRole userRole)
        {
            using (var context = new DataContext())
            {
                context.Entry(userRole).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
