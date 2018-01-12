using DataContextNamespace;
using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public class RatingService : IRatingService
    {
        public List<Rating> GetRatings()
        {
            using (var context = new DataContext())
            {
                return context.Ratings.ToList();
            }
        }

        public Rating GetRating(int id)
        {
            using (var context = new DataContext())
            {
                return context.Ratings.FirstOrDefault(c=> c.ID == id);
            }
        }

        public Rating InsertRating(Rating rating)
        {
            using (var context = new DataContext())
            {
                Rating newRating = context.Ratings.Add(rating);
                context.SaveChanges();
                return newRating;
            }
        }

        public void RemoveRating(int id)
        {
            using (var context = new DataContext())
            {
                Rating rating = context.Ratings.FirstOrDefault(c=> c.ID == id);
                if (rating != null)
                {
                    context.Ratings.Remove(rating);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateRating(Rating rating)
        {
            using (var context = new DataContext())
            {
                context.Entry(rating).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
