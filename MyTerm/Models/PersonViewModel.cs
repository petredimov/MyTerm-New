using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataContextNamespace.Models;

namespace MyTermMVC.Models
{
    public class PersonViewModel
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Town { get; set; }
        public string Minicipality { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        internal Person ToDataModel()
        {
            return new Person()
            {
                Address = this.Address,
                AreaCode = this.AreaCode,
                Country = this.Country,
                Firstname = this.Firstname,
                ID = this.ID,
                Lastname = this.Lastname,
                Minicipality = this.Minicipality,
                PhoneNumber = this.PhoneNumber,
                Town = this.Town
            };

        }
    }
}