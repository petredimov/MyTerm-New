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
    public class BranchService : IBranchService
    {
        public Branch GetBranch(int id)
        {
            using (var context = new DataContext())
            {
                return context.Branches.FirstOrDefault(c => c.ID == id);
            }
        }

        public List<Branch> GetBranches()
        {
            using (var context = new DataContext())
            {
                return context.Branches.ToList();
            }
        }

        public Branch InsertBranch(Branch branch)
        {
            using (var context = new DataContext())
            {
                Branch newBranch = context.Branches.Add(branch);
                context.SaveChanges();
                return newBranch;
            }
        }

        public void RemoveBranch(int id)
        {
            using (var context = new DataContext())
            {
                Branch branch = context.Branches.FirstOrDefault(c => c.ID == id);
                if (branch != null)
                {
                    context.Branches.Remove(branch);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateBranch(Branch branch)
        {
            using (var context = new DataContext())
            {
                context.Entry(branch).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
