using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories.Redis;
using Tourniquet.Application.Repositories.Tourniquet;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Remove
{
    public class RemoveTurnstileCommandHandler : IRequestHandler<RemoveTurnstileCommand, RemoveTurnstileResponse>
    {
        private const string key = "TurnstileKey";
        private ITurnstileWriteRepository _turnstileWriteRepository;
        private ITurnstileReadRepository _turnstileReadRepository;
        private IRedisWriteRepository _redisWriteRepository;

        public RemoveTurnstileCommandHandler(ITurnstileWriteRepository writeRepository, ITurnstileReadRepository turnstileReadRepository 
            ,IMapper mapper, IRedisWriteRepository redisWriteRepository)
        {
            _redisWriteRepository = redisWriteRepository;
            _turnstileWriteRepository = writeRepository;
            _turnstileReadRepository = turnstileReadRepository;
        }

        public async Task<RemoveTurnstileResponse> Handle(RemoveTurnstileCommand request, CancellationToken cancellationToken)
        {
            var turnstile = _turnstileReadRepository.Get(x=>x.Id == request.Id);
            var removeTurnstile = await _turnstileWriteRepository.DeleteAsync(turnstile);
            await _redisWriteRepository.Delete(key, request.Id, 1);
            var response = new RemoveTurnstileResponse { Message = "Silme işlemi başarılı olarak tamamlanmıştır." };
            return response;
        }
    }
}