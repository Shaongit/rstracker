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
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;
        private readonly IUnitOfWork unitOfWork;
        public StatusService(IStatusRepository statusRepository, IUnitOfWork unitOfWork)
        {
            this.statusRepository = statusRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateStatus(Status status)
        {
            statusRepository.Add(status);
        }

        public void DeleteStatus(Status status)
        {
            statusRepository.Delete(status);
        }

        public void EditStatus(Status status)
        {
            statusRepository.Update(status);
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return statusRepository.GetAll();
        }

        public Status GetStatus(int? id)
        {
            return statusRepository.GetById(id);
        }

        public void SaveStatus()
        {
            unitOfWork.Commit();
        }
    }
}
