using MediatR;

namespace Tourniquet.Application.Features.Queries.GetAllPersons
{
    public class GetAllPersonQueryCommand : IRequest<IList<GetAllPersonQueryResponse>>
    {
        public int Page => 0;
        public int PageSize => 10;
    }
}