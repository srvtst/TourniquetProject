using MediatR;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetDayTourniquet
{
    public class GetDayTurnstileQueryCommand : IRequest<List<GetDayTurnstileQueryResponse>>
    {
        public DateTime DateTime { get; set; }
    }
}