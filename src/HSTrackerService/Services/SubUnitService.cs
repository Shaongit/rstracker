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
    public class SubUnitService : ISubUnitService
    {
        private readonly ISubUnitRepository subUnitRepository;
        private readonly IUnitOfWork unitOfWork;

        public SubUnitService(ISubUnitRepository subUnitRepository, IUnitOfWork unitOfWork)
        {
            this.subUnitRepository = subUnitRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateSubUnit(SubUnit subUnit)
        {
            subUnitRepository.Add(subUnit);
        }

        public void DeleteSubUnit(SubUnit subUnit)
        {
            subUnitRepository.Delete(subUnit);
        }

        public void EditSubUnit(SubUnit subUnit)
        {
            subUnitRepository.Update(subUnit);
        }

        public IEnumerable<SubUnit> GetAllSubUnit()
        {
            return subUnitRepository.GetAll();
        }

        public SubUnit GetSubUnit(int? id)
        {
            return subUnitRepository.GetById(id);
        }

        public void SaveSubUnit()
        {
            unitOfWork.Commit();
        }
    }
}
