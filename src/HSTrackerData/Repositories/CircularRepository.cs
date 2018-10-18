using HSTrackerData.Infrastructure;
using HSTrackerData.Repositories.Interface;
using HSTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerData.Repositories
{
    public class CircularRepository : RepositoryBase<Circular>, ICircularRepository
    {
        public CircularRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
