using HSTrackerModel.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HSTrackerModel.Models
{
    public class Dept : Entity
    {
        [Display(Name ="Department")]
        [Required()]

        public string Name { get; set; }
        public int DivisionId { get; set; }

        [ForeignKey("DivisionId")]
        public virtual Division Division { get; set; }
        public virtual List<SubUnit> SubUnits { get; set; }
        //public virtual List<Employee> Employees { get; set; }
    }
}