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
    public class DivisionService : IDivisionService
    {
        private readonly IDivisionRepository divisionRepository;
        private readonly IUnitOfWork unitOfWork;
        public DivisionService(IDivisionRepository divisionRepository, IUnitOfWork unitOfWork)
        {
            this.divisionRepository = divisionRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateDivision(Division division)
        {
            divisionRepository.Add(division);
        }

        public void DeleteDivision(Division division)
        {
            divisionRepository.Delete(division);
        }

        public void EditDivision(Division division)
        {
            divisionRepository.Update(division);
        }

        public IEnumerable<Division> GetAllDivision()
        {
            return divisionRepository.GetAll();
        }

        public Division GetDivision(int? id)
        {
            return divisionRepository.GetById(id);
        }

        public void SaveDivision()
        {
            unitOfWork.Commit();
        }
    }
}
