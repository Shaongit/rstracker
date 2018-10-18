using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerService.Interface
{
   public interface ISubUnitService
    {
        IEnumerable<SubUnit> GetAllSubUnit();
        SubUnit GetSubUnit(int? id);
        void CreateSubUnit(SubUnit subUnit);
        void EditSubUnit(SubUnit subUnit);
        void DeleteSubUnit(SubUnit subUnit);
        void SaveSubUnit();
    }
}
