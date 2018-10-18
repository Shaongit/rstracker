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
   public class RequisitionConfiguration : EntityTypeConfiguration<Requisition>
    {
        public RequisitionConfiguration()
        {
            ToTable("Requisitions");
            Property(r => r.RefNo).IsRequired();
            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
