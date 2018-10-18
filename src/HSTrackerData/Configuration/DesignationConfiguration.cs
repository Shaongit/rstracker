using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerData.Configuration
{
   public class DesignationConfiguration : EntityTypeConfiguration<Designation>
    {
        public DesignationConfiguration()
        {
            ToTable("Designation");
            Property(d => d.Name).IsRequired().HasMaxLength(80);
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
