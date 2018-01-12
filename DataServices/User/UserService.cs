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
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            using (var context = new DataContext())
            {
                return context.Users.ToList();
            }
        }

        public User GetUser(string id)
        {
            using (var context = new DataContext())
            {
                return context.Users.FirstOrDefault(c => c.Id == id);
            }
        }

        public User InsertUser(User user)
        {
            using (var context = new DataContext())
            {
                User newUser = context.Users.Add(user);
                context.SaveChanges();
                return newUser;
            }
        }

        public void RemoveUser(string id)
        {
            using (var context = new DataContext())
            {
                User user = context.Users.FirstOrDefault(c => c.Id == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (var context = new DataContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
