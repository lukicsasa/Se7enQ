using Se7enQ.Data.UnitOfWork;
using Se7enQ.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7enQ.Data.Repository
{
    public class ProjectionRepository : GenericRepository<Projection>
    {
        public ProjectionRepository(DbContext dbContext) : base(dbContext) { }

    }
}
