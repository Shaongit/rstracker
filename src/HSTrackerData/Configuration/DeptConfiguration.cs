using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerData.Configuration
{
   public class DeptConfiguration : EntityTypeConfiguration<Dept>
    {
        public DeptConfiguration()
        {
            ToTable("Dept");
            Property(c => c.Name).IsRequired().HasMaxLength(80);
        }
    }
}
