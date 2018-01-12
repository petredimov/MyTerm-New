using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataContextNamespace.Models;

namespace MyTermMVC.Models
{
    public class CompanyViewModel
    {
        [Required]
        public string EDB { get; set; }
        public string Name { get; set; }
        public string FaxNumber { get; set; }
        public string Town { get; set; }
        public string Minicipality { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        internal Company ToDataModel()
        {
            return new Company()
            {
                Address = this.Address,
                AreaCode = this.AreaCode,
                Country = this.Country,
                EDB = this.EDB,
                FaxNumber = this.FaxNumber,
                Minicipality = this.Minicipality,
                Name = this.Name,
                PhoneNumber = this.PhoneNumber,
                Town = this.Town
            };
        }
    }
}