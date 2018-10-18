using HSTrackerData.Infrastructure;
using HSTrackerData.Repositories.Interface;
using HSTrackerModel.Models;
using HSTrackerService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerService.Services
{
   public class DeptService : IDeptService
    {
        private readonly IDeptRepository deptRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeptService(IDeptRepository deptRepository, IUnitOfWork unitOfWork)
        {
            this.deptRepository = deptRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateDept(Dept dept)
        {
            deptRepository.Add(dept);
        }

        public void DeleteDept(Dept dept)
        {
            deptRepository.Delete(dept);
        }

        public void EditDept(Dept dept)
        {
            deptRepository.Update(dept);
        }

        public IEnumerable<Dept> GetAllDept()
        {
            return deptRepository.GetAll();
        }

        public Dept GetDept(int? id)
        {
            return deptRepository.GetById(id);
        }

        public void SaveDept()
        {
            unitOfWork.Commit();
        }
    }
}
