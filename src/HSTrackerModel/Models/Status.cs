using HSTrackerModel.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HSTrackerModel.Models
{
    public class Status : Entity
    {
        [Display (Name ="Status")]
        [Required()]
        public string Name { get; set; }
    }
}