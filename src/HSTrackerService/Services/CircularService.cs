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
            throw new NotImplementedException();
        }

        public void DeleteCircular(int id)
        {
            throw new NotImplementedException();
        }

        public void EditCircular(Circular circular)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Circular> GetAllCircular(int? requisitionId)
        {
            throw new NotImplementedException();
        }

        public Circular GetCircular(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveCircular()
        {
            throw new NotImplementedException();
        }
    }
}
