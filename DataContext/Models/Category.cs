using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContextNamespace.Models
{
    [DataContract]
    public class Category
    {
        [Key]
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public virtual ICollection<CompanyCategory> CompCategories { get; set;}
        [DataMember]
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
