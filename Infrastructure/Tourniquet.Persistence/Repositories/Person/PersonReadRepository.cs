using Tourniquet.Application.Repositories;
using Tourniquet.Domain.Entities;
using Tourniquet.Persistence.Context;

namespace Tourniquet.Persistence.Repositories
{
    public class PersonReadRepository : ReadGenericRepository<Person, TurnstileDbContext>, IPersonReadRepository
    {
        public PersonReadRepository(TurnstileDbContext context) : base(context)
        {
        }
    }
}