using DataContextNamespace.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContextNamespace.Models
{
    [Table("UserRole")]
    [DataContract]
    public partial class UserRole : IdentityUserRole<string>
    {
        [DataMember]
        [Key, Column(Order = 2)]
        public int Id { get; set; }
        [DataMember]
        public virtual Role Role { get; set; }
        [DataMember]
        public virtual User User { get; set; }
    }
}
