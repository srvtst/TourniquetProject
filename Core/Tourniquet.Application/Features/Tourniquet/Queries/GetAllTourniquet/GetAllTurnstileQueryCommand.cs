using MediatR;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet
{
    public class GetAllTurnstileQueryCommand : IRequest<GetAllTurnstileQueryResponse>
    {
        public int Page => 0;
        public int PageSize => 100;
    }
}