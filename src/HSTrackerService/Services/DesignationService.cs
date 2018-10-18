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
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationRepository designationRepository;
        private readonly IUnitOfWork unitOfWork;
        public DesignationService(IDesignationRepository designationRepository, IUnitOfWork unitOfWork)
        {
            this.designationRepository = designationRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateDesignation(Designation designation)
        {
            designationRepository.Add(designation);
        }

        public void DeleteDesignation(Designation designation)
        {
            designationRepository.Delete(designation);
        }

        public void EditDesignation(Designation designation)
        {
            designationRepository.Update(designation);
        }

        public IEnumerable<Designation> GetAllDesignation()
        {
            return designationRepository.GetAll();
        }

        public Designation GetDesignation(int? id)
        {
            return designationRepository.GetById(id);
        }

        public void SaveDesignation()
        {
            unitOfWork.Commit();
        }
    }
}
