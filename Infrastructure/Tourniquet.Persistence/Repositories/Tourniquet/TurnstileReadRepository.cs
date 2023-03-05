using Tourniquet.Application.Repositories.Tourniquet;
using Tourniquet.Domain;
using Tourniquet.Persistence.Context;

namespace Tourniquet.Persistence.Repositories.Tourniquet
{
    public class TurnstileReadRepository : ReadGenericRepository<Turnstile, TurnstileDbContext>, ITurnstileReadRepository
    {
        public TurnstileReadRepository(TurnstileDbContext context) : base(context)
        {
        }
    }
}