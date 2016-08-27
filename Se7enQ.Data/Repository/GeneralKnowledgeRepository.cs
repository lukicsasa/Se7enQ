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
    public class GeneralKnowledgeRepository : GenericRepository<GeneralKnowledge>
    {
        public GeneralKnowledgeRepository(DbContext dbContext) : base(dbContext) { }

    }
}
