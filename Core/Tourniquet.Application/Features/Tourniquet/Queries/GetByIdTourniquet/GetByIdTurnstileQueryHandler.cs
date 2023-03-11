using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories.Redis;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetByIdTourniquet
{
    public class GetByIdTurnstileQueryHandler : IRequestHandler<GetByIdTurnstileQueryCommand, GetByIdTurnstileQueryResponse>
    {
        private const string key = "TurnstileKey";
        private IRedisReadRepository _redisReadRepository;
        private IMapper _mapper;

        public GetByIdTurnstileQueryHandler(IRedisReadRepository redisReadRepository, IMapper mapper)
        {
            _redisReadRepository = redisReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTurnstileQueryResponse> Handle(GetByIdTurnstileQueryCommand request, CancellationToken cancellationToken)
        {
            var turnstile = await _redisReadRepository.GetById<Turnstile>(key, request.Id, 1);
            var mapped = _mapper.Map<GetByIdTurnstileQueryResponse>(turnstile);
            return mapped;
        }
    }
}