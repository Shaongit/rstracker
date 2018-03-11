using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSTracker.Models
{
    public class Circular
    {
        public Circular()
        {
            CreateDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            CreatedBy = null;
            ModifiedBy = null;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        [Display(Name = "Requisition ID")]
        public int RequisitionId { get; set; }
        [ForeignKey("RequisitionId")]
        public virtual Requisition Requisition { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Circular Date")]
        public DateTime? CircularDate { get; set; }
        [Display(Name = "No Of CV From AD")]
        public int? NoOfCvFromAD { get; set; }
        [Display(Name = "No Of CV From Online")]
        public int? NoOfCvFromOnline { get; set; }
        [Display(Name = "No Of CV From Hardcopy")]
        public int? NoOfCvFromHardcopy { get; set; }
        [Display(Name = "No Of CV From Ref")]
        public int? NoOfCvFromRef { get; set; }
        [Display(Name = "CV sent to line Manager")]
        public int? CvSendtoLM { get; set; }
        [Display(Name = "Sorted CV from line Manager")]
        public int? SortedCvFromLM { get; set; }
        [Display(Name = "Final Candidate")]
        public int? FinalSelectedCandidate { get; set; }
        [Display(Name = "Written Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WrittentestDate { get; set; }
        [Display(Name = "Written pass candidate")]
        public int? WrittenTestPassedCandidate { get; set; }
        [Display(Name = "Viva Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? VivaDate { get; set; }
        [Display(Name = "Viva Candidate")]
        public int? VivaCandidate { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        //User Id
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}