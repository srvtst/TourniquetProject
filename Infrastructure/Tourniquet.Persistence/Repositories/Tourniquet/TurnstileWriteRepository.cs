using Tourniquet.Application.Repositories.Tourniquet;
using Tourniquet.Domain;
using Tourniquet.Persistence.Context;

namespace Tourniquet.Persistence.Repositories.Tourniquet
{
    public class TurnstileWriteRepository : WriteGenericRepository<Turnstile, TurnstileDbContext>, ITurnstileWriteRepository
    {
        public TurnstileWriteRepository(TurnstileDbContext context) : base(context)
        {
        }
    }
}