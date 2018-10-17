using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTrackerData.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        AppDbContext dbContext;

        public AppDbContext Init()
        {
            return dbContext ?? (dbContext = new AppDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
