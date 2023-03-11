using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories.Redis;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet
{
    public class GetAllTurnstileQueryHandler : IRequestHandler<GetAllTurnstileQueryCommand, IList<GetAllTurnstileQueryResponse>>
    {
        private const string key = "TurnstileKey";
        private IRedisReadRepository _redisReadRepository;
        private IMapper _mapper;

        public GetAllTurnstileQueryHandler(IRedisReadRepository redisReadRepository,IMapper mapper)
        {
            _redisReadRepository = redisReadRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetAllTurnstileQueryResponse>> Handle(GetAllTurnstileQueryCommand request, CancellationToken cancellationToken)
        {
            var turnstiles = await _redisReadRepository.GetAll<Turnstile>(key, 1);
            var response = _mapper.Map<IList<GetAllTurnstileQueryResponse>>(turnstiles);
            return response;
        }
    }
}