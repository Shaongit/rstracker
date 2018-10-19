using HSTrackerModel.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HSTrackerModel.Models
{
    public class SubUnit : Entity
    {
        [Display(Name ="Sub Unit")]
        public string Name { get; set; }
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Dept Dept { get; set; }
    }
}