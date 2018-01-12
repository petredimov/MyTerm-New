namespace DataContextNamespace.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.Security.Claims;
    using System.Threading.Tasks;


    [Table("Users")]
    [DataContract]
    public partial class User : IdentityUser<string, ApplicationUserLogin,
        UserRole, ApplicationUserClaim>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            UserRoles = new HashSet<UserRole>();         
        }
        
        [StringLength(50)]
        [DataMember]
        public string Firstname { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Lastname { get; set; }

        [DataMember]
        public virtual ICollection<UserRole> UserRoles { get; set; }

        [DataMember]
        public virtual ICollection<Term> Terms { get; set; }

        [DataMember]
        public virtual ICollection<Rating> Ratings { get; set; }

        public async Task<ClaimsIdentity>
            GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    [Table("UserLogins")]
    public class ApplicationUserLogin : IdentityUserLogin<string> {

        [Key]
        public Int32 Id { get; set; }
    }
    [Table("UserClaims")]
    public class ApplicationUserClaim : IdentityUserClaim<string> { }
}
