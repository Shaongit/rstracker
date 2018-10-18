using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerService.Interface
{
   public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(int? id);
        void CreateEmployee(Employee employee);
        void EditEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void SaveEmployee();
    }
}
