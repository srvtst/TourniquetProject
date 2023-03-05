using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories.Tourniquet;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Remove
{
    public class RemoveTurnstileCommandHandler : IRequestHandler<RemoveTurnstileCommand, RemoveTurnstileResponse>
    {
        private ITurnstileWriteRepository _writeRepository;
        private IMapper _mapper;
        public RemoveTurnstileCommandHandler(ITurnstileWriteRepository writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<RemoveTurnstileResponse> Handle(RemoveTurnstileCommand request, CancellationToken cancellationToken)
        {
            Turnstile mappedTurnstile = _mapper.Map<Turnstile>(request);
            var removeTurnstile = await _writeRepository.DeleteAsync(mappedTurnstile);
            RemoveTurnstileResponse response = _mapper.Map<RemoveTurnstileResponse>(removeTurnstile);
            return response;
        }
    }
}