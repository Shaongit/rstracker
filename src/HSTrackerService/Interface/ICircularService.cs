using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerService.Interface
{
   public interface ICircularService
    {
        IEnumerable<Circular> GetAllCircular(int? requisitionId);
        Circular GetCircular(int id);
        void CreateCircular(Circular circular);
        void EditCircular(Circular circular);
        void DeleteCircular(int id);
        void SaveCircular();
    }
}
