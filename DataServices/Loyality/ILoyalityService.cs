using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface ILoyalityService
    {
        Loyality InsertLoyality(Loyality loyality);
        void UpdateLoyality(Loyality loyality);
        void RemoveLoyality(int id);
        Loyality GetLoyality(int id);
        List<Loyality> GetLoyality();
    }
}
