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
    public class TermService : ITermService
    {
        public Term GetTerm(int id)
        {
            using (var context = new DataContext())
            {
                return context.Terms.FirstOrDefault(c => c.ID == id);
            }
        }

        public List<Term> GetTerms()
        {
            using (var context = new DataContext())
            {
                return context.Terms.ToList();
            }
        }

        public Term InsertTerm(Term term)
        {
            using (var context = new DataContext())
            {
                Term newTerm = context.Terms.Add(term);
                context.SaveChanges();
                return newTerm;
            }
        }

        public void RemoveTerm(int id)
        {
            using (var context = new DataContext())
            {
                Term term = context.Terms.FirstOrDefault(c => c.ID == id);
                if (term != null)
                {
                    context.Terms.Remove(term);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateTerm(Term term)
        {
            using (var context = new DataContext())
            {
                context.Entry(term).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
