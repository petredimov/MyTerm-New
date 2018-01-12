using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IRatingService
    {
        Rating InsertRating(Rating rating);
        void UpdateRating(Rating rating);
        void RemoveRating(int id);
        Rating GetRating(int id);
        List<Rating> GetRatings();
    }
}
