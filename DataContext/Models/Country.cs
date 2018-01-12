using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContextNamespace.Models
{

    [DataContract]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public Int32 Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Prefix { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public virtual IEnumerable<City> Cities { get; set; }
		public virtual IEnumerable<Municipality> Municipalities { get; set; }

		public Country() { }
    }
}
