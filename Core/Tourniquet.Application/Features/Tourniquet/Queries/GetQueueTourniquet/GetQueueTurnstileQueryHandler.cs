using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories.Tourniquet;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetQueueTourniquet
{
    public class GetQueueTurnstileQueryHandler : IRequestHandler<GetQueueTurnstileQueryCommand, IList<GetQueueTurnstileQueryResponse>>
    {
        private ITurnstileReadRepository _turnstileReadRepository;
        private IMapper _mapper;
        public GetQueueTurnstileQueryHandler(ITurnstileReadRepository turnstileReadRepository,IMapper mapper)
        {
            _turnstileReadRepository = turnstileReadRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetQueueTurnstileQueryResponse>> Handle(GetQueueTurnstileQueryCommand request, CancellationToken cancellationToken)
        {
            var turnstile = _turnstileReadRepository.GetWhere(x => x.Queue == request.Queue).ToList();
            var response = _mapper.Map<IList<GetQueueTurnstileQueryResponse>>(turnstile);
            return response;
        }
    }
}