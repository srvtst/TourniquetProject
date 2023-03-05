using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories.Tourniquet;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet
{
    public class GetAllTurnstileQueryHandler : IRequestHandler<GetAllTurnstileQueryCommand, IList<GetAllTurnstileQueryResponse>>
    {
        private ITurnstileReadRepository _turnstileReadRepository;
        private IMapper _mapper;

        public GetAllTurnstileQueryHandler(ITurnstileReadRepository turnstileReadRepository, IMapper mapper)
        {
            _turnstileReadRepository = turnstileReadRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetAllTurnstileQueryResponse>> Handle(GetAllTurnstileQueryCommand request, CancellationToken cancellationToken)
        {
            var turnstiles = _turnstileReadRepository.GetAll().ToList();
            var response = _mapper.Map<IList<GetAllTurnstileQueryResponse>>(turnstiles);
            return response;
        }
    }
}