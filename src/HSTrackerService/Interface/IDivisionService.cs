using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerService.Interface
{
   public interface IDivisionService
    {
        IEnumerable<Division> GetAllDivision();
        Division GetDivision(int? id);
        void CreateDivision(Division division);
        void EditDivision(Division division);
        void DeleteDivision(Division division);
        void SaveDivision();
    }
}
