using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerData.Configuration
{
   public class DivisionConfiguration : EntityTypeConfiguration<Division>
    {
        public DivisionConfiguration()
        {
            ToTable("Division");
            Property(d => d.Name).IsRequired().HasMaxLength(80);
        }
    }
}
