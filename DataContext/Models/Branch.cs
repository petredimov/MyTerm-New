using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.DynamicData;

namespace DataContextNamespace.Models
{
    [TableName("Branches")]
    [DataContract]
    public class Branch
    {
        [Key]
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Address Address { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string FaxNumber { get; set; }
        [DataMember]
        public virtual Company Company { get; set; }
        [DataMember]
        public virtual ICollection<Line> Lines { get; set; }
    }
}
