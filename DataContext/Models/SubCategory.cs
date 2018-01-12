using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContextNamespace.Models
{
    [DataContract]
    public class SubCategory
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public Category Category { get; set; }
        [DataMember]
        public virtual ICollection<Loyality> Loyalities { get; set; }
        [DataMember]
        public virtual ICollection<SubCategoryTerm> SubCategoryTerms { get; set; }
    }
}
