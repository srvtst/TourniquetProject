using AutoMapper;
using MediatR;
using System.Text.Json;
using Tourniquet.Application.Repositories.Redis;
using Tourniquet.Application.Repositories.Tourniquet;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Update
{
    public class UpdatedTurnstileCommandHandler : IRequestHandler<UpdatedTurnstileCommand, UpdatedTurnstileResponse>
    {
        private const string key = "TurnstileKey";
        private IMapper _mapper;
        private ITurnstileWriteRepository _turnstileWriteRepository;
        private ITurnstileReadRepository _turnstileReadRepository;
        private IRedisWriteRepository _redisWriteRepository;

        public UpdatedTurnstileCommandHandler(ITurnstileWriteRepository turnstileWrite, IMapper mapper, ITurnstileReadRepository turnstileRead,
            IRedisWriteRepository redisWriteRepository)
        {
            _mapper = mapper;
            _turnstileWriteRepository = turnstileWrite;
            _turnstileReadRepository = turnstileRead;
            _redisWriteRepository = redisWriteRepository;
        }

        public async Task<UpdatedTurnstileResponse> Handle(UpdatedTurnstileCommand request, CancellationToken cancellationToken)
        {
            var newTurnstile = _turnstileReadRepository.Get(x => x.Id == request.Id);
            var cache = _redisWriteRepository.Delete(key, newTurnstile.Id, 1);
            var turnstile = new Turnstile()
            {
                Id = request.Id,
                Queue = request.Queue,
                ExitDate = request.ExitDate,
                PersonId = newTurnstile.PersonId,
                DateOfEntry = request.DateOfEntry,
                Status = Domain.Enums.Status.Inactive
            };
            var mappedTurnstile = _mapper.Map<Turnstile>(turnstile);
            var updatedTurnstile = await _turnstileWriteRepository.UpdateAsync(mappedTurnstile);
            var json = JsonSerializer.Serialize(updatedTurnstile);
            var cacheAdded = _redisWriteRepository.Add(key, updatedTurnstile.Id, json, 1);
            UpdatedTurnstileResponse response = _mapper.Map<UpdatedTurnstileResponse>(updatedTurnstile);
            return response;
        }
    }
}