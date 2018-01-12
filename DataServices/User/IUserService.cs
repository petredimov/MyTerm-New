using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IUserService
    {
        User InsertUser(User user);
        void UpdateUser(User user);
        void RemoveUser(string id);
        User GetUser(string id);
        List<User> GetUsers();
    }
}
