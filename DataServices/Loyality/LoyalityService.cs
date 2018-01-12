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
    public class LoyalityService : ILoyalityService
    {
        public List<Loyality> GetLoyality()
        {
            using (var context = new DataContext())
            {
                return context.Loyalities.ToList();
            }
        }

        public Loyality GetLoyality(int id)
        {
            using (var context = new DataContext())
            {
                return context.Loyalities.FirstOrDefault(c => c.ID == id);
            }
        }

        public Loyality InsertLoyality(Loyality loyality)
        {
            using (var context = new DataContext())
            {
                Loyality newLoyality = context.Loyalities.Add(loyality);
                context.SaveChanges();
                return newLoyality;
            }
        }

        public void RemoveLoyality(int id)
        {
            using (var context = new DataContext())
            {
                Loyality loyality = context.Loyalities.FirstOrDefault(c=> c.ID == id);
                if (loyality != null)
                {
                    context.Loyalities.Remove(loyality);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateLoyality(Loyality loyality)
        {
            using (var context = new DataContext())
            {
                context.Entry(loyality).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
