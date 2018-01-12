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
    public class SubCategoryTerm
    {
        [DataMember]
        [Key]
        public Int32 ID { get; set; }

        [DataMember]
        public SubCategory SubCategory { get; set; }
        [DataMember]
        public Term Term { get; set; }
    }
}
