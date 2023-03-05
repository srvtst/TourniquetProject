using MediatR;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet
{
    public class GetAllTurnstileQueryCommand : IRequest<IList<GetAllTurnstileQueryResponse>>
    {
        public int Page => 0;
        public int PageSize => 10;
    }
}