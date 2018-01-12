using System.Runtime.Serialization;
using System.Web.DynamicData;

namespace DataContextNamespace.Models
{
    [TableName("Persons")]
    [DataContract]
    public class Person : Client
    {
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; }
    }
}
