using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerService.Interface
{
   public interface IStatusService
    {
        IEnumerable<Status> GetAllStatus();
        Status GetStatus(int? id);
        void CreateStatus(Status status);
        void EditStatus(Status status);
        void DeleteStatus(Status status);
        void SaveStatus();
    }
}
