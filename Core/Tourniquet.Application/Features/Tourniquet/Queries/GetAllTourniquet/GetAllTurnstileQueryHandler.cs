using AutoMapper;
using MediatR;
using System.Text.Json;
using Tourniquet.Application.Repositories.Redis;
using Tourniquet.Application.Repositories.Tourniquet;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet
{
    public class GetAllTurnstileQueryHandler : IRequestHandler<GetAllTurnstileQueryCommand, IList<GetAllTurnstileQueryResponse>>
    {
        private const string key = "TurnstileKey";
        private IMapper _mapper;
        private IRedisReadRepository _redisReadRepository;
        private IRedisWriteRepository _redisWriteRepository;
        private ITurnstileReadRepository _turnstileReadRepository;

        public GetAllTurnstileQueryHandler(IRedisReadRepository redisReadRepository, IRedisWriteRepository redisWriteRepository,
            ITurnstileReadRepository turnstileReadRepository, IMapper mapper)
        {
            _redisReadRepository = redisReadRepository;
            _redisWriteRepository = redisWriteRepository;
            _turnstileReadRepository = turnstileReadRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetAllTurnstileQueryResponse>> Handle(GetAllTurnstileQueryCommand request, CancellationToken cancellationToken)
        {
            if (!_redisReadRepository.CacheKeyExists(key, 1))
            {
                var listTurnstiles = _turnstileReadRepository.GetAll().ToList();
                foreach (var item in listTurnstiles)
                {
                    var json = JsonSerializer.Serialize(item);
                    await _redisWriteRepository.Add(key, item.Id, json, 1);
                }
                return _mapper.Map<IList<GetAllTurnstileQueryResponse>>(listTurnstiles);
            }
            var turnstiles = await _redisReadRepository.GetAll<Turnstile>(key, 1);
            return _mapper.Map<IList<GetAllTurnstileQueryResponse>>(turnstiles);
        }
    }
}