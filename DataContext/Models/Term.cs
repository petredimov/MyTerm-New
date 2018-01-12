using DataContextNamespace.Helpers;
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
    public class Term
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public TimeSpan Duration { get; set; }
        [DataMember]
        public DateTime Scheduled { get; set; }
        [DataMember]
        public TermStatus Status { get; set; }

        [DataMember]
        public virtual ICollection<Schedule> Schedules { get; set; }
        [DataMember]
        public virtual ICollection<SubCategoryTerm> SubCategoryTerms { get; set; }
    }
}
