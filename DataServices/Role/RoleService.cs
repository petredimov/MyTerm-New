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
    public class RoleService : IRoleService
    {
        public Role GetRole(int id)
        {
            using (var context = new DataContext())
            {
                return context.Roles.FirstOrDefault(c=> c.Id == id.ToString());
            }
        }

        public List<Role> GetRoles()
        {
            using (var context = new DataContext())
            {
                return context.Roles.ToList();
            }
        }

        public Role InsertRole(Role role)
        {
            using (var context = new DataContext())
            {
                Role newRole = context.Roles.Add(role);
                context.SaveChanges();
                return newRole;
            }
        }

        public void RemoveRole(int id)
        {
            using (var context = new DataContext())
            {
                Role role = context.Roles.First(c => c.Id == id.ToString());
                if (role != null)
                {
                    context.Roles.Remove(role);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateRole(Role role)
        {
            using (var context = new DataContext())
            {
                context.Entry(role).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
