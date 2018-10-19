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
    public class CircularConfiguration : EntityTypeConfiguration<Circular>
    {
        public CircularConfiguration()
        {
            ToTable("Circular");
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
