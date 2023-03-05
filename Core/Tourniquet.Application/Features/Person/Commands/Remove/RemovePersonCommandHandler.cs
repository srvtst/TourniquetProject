using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Commands.Remove
{
    public class RemovePersonCommandHandler : IRequestHandler<RemovePersonCommand, RemovePersonResponse>
    {
        private IPersonWriteRepository _personWriteRepository;
        private IMapper _mapper;
        public RemovePersonCommandHandler(IPersonWriteRepository personWriteRepository, IMapper mapper)
        {
            _personWriteRepository = personWriteRepository;
            _mapper = mapper;
        }

        public async Task<RemovePersonResponse> Handle(RemovePersonCommand request, CancellationToken cancellationToken)
        {
            Person mappedPerson = _mapper.Map<Person>(request);
            var removedPerson = await _personWriteRepository.DeleteAsync(mappedPerson);
            RemovePersonResponse response = _mapper.Map<RemovePersonResponse>(removedPerson);
            return response;
        }
    }
}