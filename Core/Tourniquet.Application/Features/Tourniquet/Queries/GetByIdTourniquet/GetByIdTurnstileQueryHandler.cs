using AutoMapper;
using MediatR;
using System.Text.Json;
using Tourniquet.Application.Repositories.Redis;
using Tourniquet.Application.Repositories.Tourniquet;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetByIdTourniquet
{
    public class GetByIdTurnstileQueryHandler : IRequestHandler<GetByIdTurnstileQueryCommand, GetByIdTurnstileQueryResponse>
    {
        private const string key = "TurnstileKey";
        private IMapper _mapper;
        private IRedisReadRepository _redisReadRepository;
        private IRedisWriteRepository _redisWriteRepository;
        private ITurnstileReadRepository _turnstileReadRepository;

        public GetByIdTurnstileQueryHandler(IMapper mapper , IRedisReadRepository redisReadRepository, ITurnstileReadRepository turnstileReadRepository, IRedisWriteRepository redisWriteRepository)
        {
            _mapper = mapper;
            _redisReadRepository = redisReadRepository;
            _turnstileReadRepository = turnstileReadRepository;
            _redisWriteRepository = redisWriteRepository;
        }

        public async Task<GetByIdTurnstileQueryResponse> Handle(GetByIdTurnstileQueryCommand request, CancellationToken cancellationToken)
        {
            if (!_redisReadRepository.CacheKeyExists(key,1))
            {
                var dbTurnstile = _turnstileReadRepository.Get(x => x.Id == request.Id);
                var json = JsonSerializer.Serialize(dbTurnstile);
                await _redisWriteRepository.Add(key, dbTurnstile.Id, json, 1);
                return _mapper.Map<GetByIdTurnstileQueryResponse>(dbTurnstile);
            }
            var turnstile = await _redisReadRepository.GetById<Turnstile>(key, request.Id, 1);
            var mapped = _mapper.Map<GetByIdTurnstileQueryResponse>(turnstile);
            return mapped;
        }
    }
}