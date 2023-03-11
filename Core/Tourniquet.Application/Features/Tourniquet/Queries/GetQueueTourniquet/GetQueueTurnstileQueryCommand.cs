using MediatR;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetQueueTourniquet
{
    public class GetQueueTurnstileQueryCommand : IRequest<IList<GetQueueTurnstileQueryResponse>>
    {
        public int Queue { get; set; }
    }
}