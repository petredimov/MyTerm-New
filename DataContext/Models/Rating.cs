using DataContextNamespace.Models;
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
    public class Rating
    {
        [Key]
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public virtual ICollection<User> Users { get; set;}
    }
}
