using BusinessLayer.Repository.Interfaces.Entities;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class OperationTypeRepository : Repository<OperationType>
    {
        public OperationTypeRepository(DataContext context) : base(context) { }
    }
}
