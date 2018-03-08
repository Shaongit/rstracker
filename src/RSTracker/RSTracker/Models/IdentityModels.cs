using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RSTracker.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RSTracker.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Dept> Dept { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<SubUnit> SubUnit { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<Circular> Circular { get; set; }
        public DbSet<Status> Status { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Division>()
            //    .HasRequired(c => c.Employees)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Employee>()
            //.HasRequired(c => c.Division)
            //.WithMany()
            //.HasForeignKey(d => d.DivisionId)
            //.WillCascadeOnDelete(false);

            //modelBuilder.Entity<Dept>()
            //    .HasRequired(c => c.Employees)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //        modelBuilder.Entity<Course>()
            //.HasRequired(t => t.Department)
            //.WithMany(t => t.Courses)
            //.HasForeignKey(d => d.DepartmentID)
            //.WillCascadeOnDelete(false);


            // modelBuilder.Entity<SubUnit>()
            //.HasRequired(c => c.Dept)
            //.WithMany()
            //.WillCascadeOnDelete(false);

            //modelBuilder.Entity<Employee>()

            //.ForeignKey("dbo.Divisions", t => t.DivisionId, cascadeDelete: true)
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Employee>()
                .HasRequired(c => c.Division)
                .WithMany(w=>w.Employees)
                .HasForeignKey(d => d.DivisionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubUnit>()
                .HasRequired(c => c.Dept)
                .WithMany(w => w.SubUnits)
                .HasForeignKey(d => d.DeptId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);

        }
    }
}