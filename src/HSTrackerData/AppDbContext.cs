using HSTrackerData.Configuration;
using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerData
{
   public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<Dept> Dept { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<SubUnit> SubUnit { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<Circular> Circular { get; set; }
        public DbSet<Status> Status { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

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
                .WithMany(w => w.Employees)
                .HasForeignKey(d => d.DivisionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubUnit>()
                .HasRequired(c => c.Dept)
                .WithMany(w => w.SubUnits)
                .HasForeignKey(d => d.DeptId)
                .WillCascadeOnDelete(false);
            modelBuilder.Configurations.Add(new CircularConfiguration());
            modelBuilder.Configurations.Add(new DeptConfiguration());
            modelBuilder.Configurations.Add(new DesignationConfiguration());
            modelBuilder.Configurations.Add(new DivisionConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new RequisitionConfiguration());
            modelBuilder.Configurations.Add(new StatusConfiguration());
            modelBuilder.Configurations.Add(new SubUnitConfiguration());

            base.OnModelCreating(modelBuilder);

        }

    }
}
