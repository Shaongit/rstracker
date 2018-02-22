using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSTracker.Models
{
    public class Designation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name ="Designation")]
        [Required()]
        public string Name { get; set; }
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Dept Dept { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}