using MediatR;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetByIdTourniquet
{
    public class GetByIdTurnstileQueryCommand : IRequest<GetByIdTurnstileQueryResponse>
    {
        public int Id { get; set; }
    }
}