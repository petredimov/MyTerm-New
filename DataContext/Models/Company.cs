using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.DynamicData;

namespace DataContextNamespace.Models
{
    [TableName("Companies")]
    [DataContract]
    public class Company : Client
    {
        [DataMember]
        public string EDB { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string FaxNumber { get; set; }
        [DataMember]
        public virtual ICollection<Branch> Branches { get; set; }
        [DataMember]
        public virtual ICollection<Category> CompCategories { get; set; }
        
    }
}
