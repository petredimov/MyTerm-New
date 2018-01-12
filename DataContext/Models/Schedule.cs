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
    public class Schedule
    {
        [DataMember]
        [Key]
        public int ID { get; set; }
        [DataMember]
        public Line Line { get; set; }
        [DataMember]
        public User Client { get; set; }
        [DataMember]
        public Term Term { get; set; }
    }
}
