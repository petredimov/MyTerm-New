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
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public Int32 CountryId { get; set; }

        [DataMember]
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
		public virtual IEnumerable<Municipality> Municipalities { get; set; }

		public City() { }
    }
}
