using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories.Tourniquet;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Tourniquet.Commands.Update
{
    public class UpdatedTurnstileCommandHandler : IRequestHandler<UpdatedTurnstileCommand, UpdatedTurnstileResponse>
    {
        private ITurnstileWriteRepository _turnstileWrite;
        private ITurnstileReadRepository _turnstileRead;
        private IMapper _mapper;
        public UpdatedTurnstileCommandHandler(ITurnstileWriteRepository turnstileWrite, IMapper mapper, ITurnstileReadRepository turnstileRead)
        {
            _turnstileWrite = turnstileWrite;
            _mapper = mapper;
            _turnstileRead = turnstileRead;
        }

        public async Task<UpdatedTurnstileResponse> Handle(UpdatedTurnstileCommand request, CancellationToken cancellationToken)
        {
            var newTurnstile = _turnstileRead.Get(x => x.Id == request.Id);
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
            var updatedTurnstile = await _turnstileWrite.UpdateAsync(mappedTurnstile);
            UpdatedTurnstileResponse response = _mapper.Map<UpdatedTurnstileResponse>(updatedTurnstile);
            return response;
        }
    }
}