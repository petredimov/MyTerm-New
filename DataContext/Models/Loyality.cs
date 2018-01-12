using DataContextNamespace.Models;
using System;
using System.Runtime.Serialization;

namespace DataContextNamespace.Models
{
    [DataContract]
    public class Loyality
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public SubCategory SubCategory { get; set; }
        [DataMember]
        public Company Company { get; set; }
        [DataMember]
        public Client Client { get; set; }
    }
}
