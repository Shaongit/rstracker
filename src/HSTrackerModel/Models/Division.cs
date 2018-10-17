using HSTrackerModel.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HSTrackerModel.Models
{
    public class Division : Entity
    {
        public Division()
        {
            CreateDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            CreatedBy = null;
            ModifiedBy = null;
        }

        [Display(Name ="Division Name")]
        [Required()]
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        //User Id
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}