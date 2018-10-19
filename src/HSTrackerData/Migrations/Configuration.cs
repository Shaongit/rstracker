namespace HSTrackerData.Migrations
{
    using HSTrackerModel.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HSTrackerData.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HSTrackerData.AppDbContext context)
        {
            context.Status.AddOrUpdate(
                p => p.Id,
                new Status() { Id = 1, Name = "Open" },
                new Status() { Id = 2, Name = "In Progress" },
                new Status() { Id = 3, Name = "Closed" }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
