using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using DataContextNamespace.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataContextNamespace
{
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public class DataContext : IdentityDbContext<User, Role,
        string, ApplicationUserLogin, UserRole, ApplicationUserClaim>
    {
        // Your context has been configured to use a 'SenseContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '.SenseContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SenseContext' 
        // connection string in the application configuration file.
        public DataContext() : base(ConnectionTools.GetConnection(), true)      
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<DataContext>((new CreateDatabaseIfNotExists<DataContext>()));
            Database.Initialize(true);
        }
		
		public static DataContext Create()
        {
            return new DataContext();
        }

        public bool UpdateDatabase(string connectionString = "", string dbVersion = "")
        {
            bool result = false;
            try
            {
                var configuration = new Migrations.Configuration();
                if (!string.IsNullOrEmpty(connectionString))
                {
                    configuration.TargetDatabase = new System.Data.Entity.Infrastructure.DbConnectionInfo(connectionString, "System.Data.MySqlClient");
                }
                var migrator = new DbMigrator(configuration);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        //public virtual DbSet<User> UserList { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<CompanyCategory> CompanyCategories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<SubCategoryTerm> SubCategoryTerms { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<Loyality> Loyalities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.Configuration.LazyLoadingEnabled = false;
            modelBuilder.Entity<Role>()
                .HasMany<UserRole>((Role c) => c.UserRoles)
                .WithRequired().HasForeignKey<string>((UserRole ur) => ur.RoleId);
            modelBuilder.Entity<User>()
                .HasMany<UserRole>((User c) => c.UserRoles)
                .WithRequired().HasForeignKey<string>((UserRole ur) => ur.UserId);

            modelBuilder.Entity<UserRole>().HasKey((UserRole ur) =>
                new
                {
                    UserId = ur.UserId,
                    RoleId = ur.RoleId
                });
        }
    }
}