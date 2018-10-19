using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerService.Interface
{
   public interface IDeptService
    {
        IEnumerable<Dept> GetAllDept();
        Dept GetDept(int? id);
        void CreateDept(Dept dept);
        void EditDept(Dept dept);
        void DeleteDept(Dept dept);
        void SaveDept();
    }
}
