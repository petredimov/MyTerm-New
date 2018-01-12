using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IRoleService
    {
        Role InsertRole(Role role);
        void UpdateRole(Role role);
        void RemoveRole(int id);
        Role GetRole(int id);
        List<Role> GetRoles();
    }
}
