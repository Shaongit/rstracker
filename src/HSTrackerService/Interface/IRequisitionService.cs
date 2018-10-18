using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerService.Interface
{
   public interface IRequisitionService
    {
        IEnumerable<Requisition> GetAllRequisition();
        Requisition GetRequisition(int? id);
        void CreateRequisition(Requisition requisition);
        void EditRequisition(Requisition requisition);
        void DeleteRequisition(Requisition requisition);
        void SaveRequisition();
    }
}
