using DataContextNamespace.Models;
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
    [DataContract]
    public abstract class Client
    {
        [Key]
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public Address Address { get; set; }       
        [DataMember]
        public string PhoneNumber { get; set; }
        
        [DataMember]
        public virtual ICollection<Term> Terms { get; set; }
        [DataMember]
        public virtual ICollection<Client> RatedClients { get; set; }
        [DataMember]
        public virtual ICollection<Loyality> Loyalities { get; set; }
        [DataMember]
        public Rating Rating { get; set; }
        [DataMember]
        public User Credentials { get; set; }
    }
}
