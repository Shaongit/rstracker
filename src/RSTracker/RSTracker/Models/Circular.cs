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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {get; set;}
        public int RequisitionId { get; set; }
        [ForeignKey("RequisitionId")]
        public virtual Requisition Requisition { get; set; }
        public DateTime CircularDate { get; set; }
        public int NoOfCvFrom { get; set; }
        public int NoOfCvFromAD { get; set; }
        public int NoOfCvFromOnline { get; set; }
        public int NoOfCvFromHardcopy { get; set; }
        public int NoOfCvFromRef { get; set; }
        public int ShortLinedCvSendtoLm { get; set; }
        public int FinalSelectedCandidate { get; set; }
        public DateTime WrittentestDate { get; set; }
        public int WrittenTestPassedCandidate { get; set; }
        public DateTime VivaDate { get; set; }
        public int VivaCandidate { get; set; }

    }
}