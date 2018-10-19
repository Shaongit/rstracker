using HSTrackerService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSTrackerModel.Models;
using HSTrackerData.Repositories.Interface;
using HSTrackerData.Infrastructure;

namespace HSTrackerService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;
        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateEmployee(Employee employee)
        {
            employeeRepository.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employeeRepository.Delete(employee);
        }

        public void EditEmployee(Employee employee)
        {
            employeeRepository.Update(employee);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return employeeRepository.GetAll();
        }

        public Employee GetEmployee(int? id)
        {
            return employeeRepository.GetById(id);
        }

        public void SaveEmployee()
        {
            unitOfWork.Commit();
        }
    }
}
