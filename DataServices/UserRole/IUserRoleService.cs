using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IUserRoleService
    {
        UserRole InsertUserRole(UserRole userRole);
        void UpdateTerm(UserRole userRole);
        void RemoveUserRole(int id);
        UserRole GetUserRole(int id);
        List<UserRole> GetUserRoles();
    }
}
