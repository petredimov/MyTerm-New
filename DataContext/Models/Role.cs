namespace DataContextNamespace.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Roles")]
    [DataContract]
    public partial class Role : IdentityRole<string, UserRole>
    {
        public Role()
        {
            this.Id = Guid.NewGuid().ToString();
            UserRoles = new HashSet<UserRole>();
        }
        [DataMember]
        [DisplayName("OrderNumber")]
        public int? OrderNumber { get; set; }
        [DataMember]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
