using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories;

namespace Tourniquet.Application.Features.Queries.GetAllPersons
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQueryCommand, IList<GetAllPersonQueryResponse>>
    {
        private IPersonReadRepository _personReadRepository;
        private IMapper _mapper;
        public GetAllPersonQueryHandler(IPersonReadRepository personReadRepository, IMapper mapper)
        {
            _personReadRepository = personReadRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetAllPersonQueryResponse>> Handle(GetAllPersonQueryCommand request, CancellationToken cancellationToken)
        {
            var persons = _personReadRepository.GetAll();
            var response = _mapper.Map<IList<GetAllPersonQueryResponse>>(persons);
            return response;
        }
    }
}