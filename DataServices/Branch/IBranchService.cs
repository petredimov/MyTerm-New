using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IBranchService
    {
        Branch InsertBranch(Branch branch);
        void UpdateBranch(Branch branch);
        void RemoveBranch(int id);
        Branch GetBranch(int id);
        List<Branch> GetBranches(); 
    }
}
