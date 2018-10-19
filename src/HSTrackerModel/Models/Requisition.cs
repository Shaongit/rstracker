using HSTrackerModel.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HSTrackerModel.Models
{
    public class Requisition : Entity
    {
        public Requisition()
        {
            CreateDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            CreatedBy = null;
            ModifiedBy = null;
        }

        [Display(Name = "Ref. No")]
        public string RefNo { get; set; }

        //Employee Id
        [Display(Name ="Raised by")]
        public int? RaisedBy { get; set; }
        [ForeignKey("RaisedBy")]
        public virtual Employee Employee { get; set; }

        //Designation Id
        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual Designation Designation { get; set; }

        [Display(Name ="Division")]
        public int? DivisionId { get; set; }
        [ForeignKey("DivisionId")]
        public virtual Division Division { get; set; }

        [Display(Name ="Dept")]
        public int? DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Dept Dept { get; set; }

        [Display(Name ="Sub Unit")]
        public int? SubUnitId { get; set; }
        [ForeignKey("SubUnitId")]
        public virtual SubUnit SubUnit { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name ="Requisition Date")]
        public DateTime? RequisitionDate { get; set; }

        [Display(Name = "Required by")]
        public int? RequiredBy { get; set; }
        [ForeignKey("RequiredBy")]
        public virtual Employee RequiredByEmp { get; set; }

        [Display(Name ="Vacancy Type")]
        public int? VacancyTypeId { get; set; }

        [NotMapped]
        public string VacancyTypeName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name ="Last Working Day")]
        public DateTime LastWorkingDay { get; set; }

        [Display(Name ="Status")]
        public int? StatusId { get; set;  }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        //User Id
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}