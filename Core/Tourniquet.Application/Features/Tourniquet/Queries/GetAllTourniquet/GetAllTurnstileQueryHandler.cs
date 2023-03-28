using AutoMapper;
using MediatR;
using System.Text.Json;
using Tourniquet.Application.Dtos.Tourniquet;
using Tourniquet.Application.Repositories.Redis;
using Tourniquet.Application.Repositories.Tourniquet;
using Tourniquet.Domain.Entities;

namespace Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet
{
    public class GetAllTurnstileQueryHandler : IRequestHandler<GetAllTurnstileQueryCommand, GetAllTurnstileQueryResponse>
    {
        private const string key = "TurnstileKey";
        private IMapper _mapper;
        private ITurnstileReadRepository _turnstileReadRepository;
        private IRedisReadRepository _redisReadRepository;
        private IRedisWriteRepository _redisWriteRepository;
        public GetAllTurnstileQueryHandler(ITurnstileReadRepository turnstileReadRepository, IMapper mapper
            , IRedisReadRepository redisReadRepository, IRedisWriteRepository redisWriteRepository)
        {
            _turnstileReadRepository = turnstileReadRepository;
            _mapper = mapper;
            _redisReadRepository = redisReadRepository;
            _redisWriteRepository = redisWriteRepository;

        }

        public async Task<GetAllTurnstileQueryResponse> Handle(GetAllTurnstileQueryCommand request, CancellationToken cancellationToken)
        {
            if (!_redisReadRepository.CacheKeyExists(key, 1))
            {
                var listTurnstiles = _turnstileReadRepository.GetAll().ToList();
                foreach (var item in listTurnstiles)
                {
                    var json = JsonSerializer.Serialize(item);
                    await _redisWriteRepository.Add(key, item.Id, json, 1);
                }
                return _mapper.Map<GetAllTurnstileQueryResponse>(listTurnstiles);
            }
            var turnstiles = await _redisReadRepository.GetAll<Turnstile>(key, 1);
            var mapperDto = _mapper.Map<IList<TurnstileList>>(turnstiles);
            var response = new GetAllTurnstileQueryResponse
            {
                TurnstileLists = mapperDto,
                Count = turnstiles.Count

            };
            return response;
        }
    }
}