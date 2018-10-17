using HSTrackerModel.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HSTrackerModel.Models
{
    public class Circular : Entity
    {
        public Circular()
        {
            CreateDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            CreatedBy = null;
            ModifiedBy = null;
        }

        [Display(Name = "Ref. No.")]
        public int RequisitionId { get; set; }
        [ForeignKey("RequisitionId")]
        public virtual Requisition Requisition { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Circular Date")]
        public DateTime? CircularDate { get; set; }

        [Display(Name = "No. of CV from AD")]
        public int? NoOfCvFromAD { get; set; }

        [Display(Name = "No of CV from Online")]
        public int? NoOfCvFromOnline { get; set; }

        [Display(Name = "No. of hard copy CV")]
        public int? NoOfCvFromHardcopy { get; set; }

        [Display(Name = "No. of CV From Ref")]
        public int? NoOfCvFromRef { get; set; }

        [Display(Name = "CV sent to line manager")]
        public int? CvSendtoLM { get; set; }

        [Display(Name = "Sorted CV from line manager")]
        public int? SortedCvFromLM { get; set; }

        //Final selected candidate for interview
        [Display(Name = "Final Candidates")]
        public int? FinalSelectedCandidate { get; set; }

        [Display(Name = "Written Test Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WrittentestDate { get; set; }
 
        [Display(Name = "Written test pass candidates")]
        public int? WrittenTestPassedCandidate { get; set; }

        [Display(Name = "Viva date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? VivaDate { get; set; }

        [Display(Name = "No. of candidates for viva")]
        public int? VivaCandidate { get; set; }

        [Display(Name = "No. of candidate for final viva")]
        public int? FinalVivaCandidate { get; set; }

        [Display(Name = "Reference check")]
        public string ReferenceCheck { get; set; }

        [Display(Name = "Final meeting with CEO")]
        public string FinalMeetingWithCEO { get; set; }

        [Display(Name = "Selected candidate details")]
        public string SelectedCandidateDetails { get; set; }

        [Display(Name = "AL Issue Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ALIssueDate { get; set; }

        [Display(Name = "Date of joining")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfJoining { get; set; }

        [Display(Name = "Process length")]
        public int? ProcessLength { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        //User Id
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}