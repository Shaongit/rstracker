using HSTrackerModel.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HSTrackerModel.Models
{
    public class Employee : Entity
    {
        [Display(Name ="Employee Name")]
        [Required()]
        public string Name { get; set; }
        public int ?DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Dept Dept { get; set; }
        public int DivisionId { get; set; }
        [ForeignKey("DivisionId")]
        public virtual Division Division { get; set; }
        public int SubUnitId { get; set; }
        [ForeignKey("SubUnitId")]
        public virtual SubUnit SubUnit { get; set; }
    }
}