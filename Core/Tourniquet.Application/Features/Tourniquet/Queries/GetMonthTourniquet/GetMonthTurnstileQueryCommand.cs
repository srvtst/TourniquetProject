using MediatR;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetMonthTourniquet
{
    public class GetMonthTurnstileQueryCommand : IRequest<IList<GetMonthTurnstileQueryResponse>>
    {
        public DateTime DateTime { get; set; }
    }
}