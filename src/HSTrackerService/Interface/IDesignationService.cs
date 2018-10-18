using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerService.Interface
{
   public interface IDesignationService
    {
        IEnumerable<Designation> GetAllDesignation();
        Designation GetDesignation(int? id);
        void CreateDesignation(Designation designation);
        void EditDesignation(Designation designation);
        void DeleteDesignation(Designation designation);
        void SaveDesignation();
    }
}
