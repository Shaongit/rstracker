using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSTracker.Models
{
    public class Requisition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RefNo { get; set; }
        public int RaisedBy { get; set; }
        [ForeignKey("RaisedBy")]
        public virtual Employee Employee { get; set; }
        public int Position { get; set; }
        [ForeignKey("Position")]
        public virtual Designation Designation { get; set; }
        public int Division { get; set; }
        [ForeignKey("Division")]
        public virtual Division Div { get; set; }
        public int Dept { get; set; }
        [ForeignKey("Dept")]
        public virtual Dept Dep { get; set; }
        public int SubUnit { get; set; }
        [ForeignKey("SubUnit")]
        public virtual SubUnit SubUni { get; set; }
        public DateTime RequisitionDate { get; set; }
        public int RequiredBy { get; set; }
        [ForeignKey("RequiredBy")]
        public virtual Employee Emp { get; set; }
        public int VacancyType { get; set; }
        public DateTime LastWorkingDay { get; set; }



    }
}