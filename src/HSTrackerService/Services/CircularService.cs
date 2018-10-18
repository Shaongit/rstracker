using HSTrackerService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSTrackerModel.Models;
using HSTrackerData.Infrastructure;
using HSTrackerData.Repositories.Interface;

namespace HSTrackerService.Services
{
    public class CircularService : ICircularService
    {
        private readonly ICircularRepository _circularRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CircularService(ICircularRepository circularRepository, IUnitOfWork unitOfWork)
        {
            this._circularRepository = circularRepository;
            this._unitOfWork = unitOfWork;
        }
        public void CreateCircular(Circular circular)
        {
            _circularRepository.Add(circular);
        }

        public void DeleteCircular(Circular circular)
        {
            _circularRepository.Delete(circular);
        }

        public void EditCircular(Circular circular)
        {
            _circularRepository.Update(circular);
        }

        public IEnumerable<Circular> GetAllCircular(int? requisitionId)
        {
            if(requisitionId == null)
            {
                return _circularRepository.GetAll();
            }
            else
            {
                return _circularRepository.GetAll().Where(c => c.RequisitionId == requisitionId);
            }
        }

        public Circular GetCircular(int? id)
        {
            var circular = _circularRepository.GetById(id);
            return circular;
        }

        public void SaveCircular()
        {
            _unitOfWork.Commit();
        }
    }
}
