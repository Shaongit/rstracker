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
    public class RequisitionService : IRequisitionService
    {
        private readonly IRequisitionRepository requisitionRepository;
        private readonly IUnitOfWork unitOfWork;
        public RequisitionService(IRequisitionRepository requisitionRepository, IUnitOfWork unitOfWork)
        {
            this.requisitionRepository = requisitionRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateRequisition(Requisition requisition)
        {
            requisitionRepository.Add(requisition);
        }

        public void DeleteRequisition(Requisition requisition)
        {
            requisitionRepository.Delete(requisition);
        }

        public void EditRequisition(Requisition requisition)
        {
            requisitionRepository.Update(requisition);
        }

        public IEnumerable<Requisition> GetAllRequisition()
        {
            return requisitionRepository.GetAll();
        }

        public Requisition GetRequisition(int? id)
        {
            var req = requisitionRepository.GetById(id);
            return req;
        }

        public void SaveRequisition()
        {
            unitOfWork.Commit();
        }
    }
}
