using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContextNamespace.Models
{
    [DataContract]
    public class CompanyCategory
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public Company Company { get; set; }
        [DataMember]
        public Category Category { get; set; }
    }
}
