using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories;
using Tourniquet.Application.SecurityHelper.Helpers;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Commands.Update
{
    public class UpdatedPersonCommandHandler : IRequestHandler<UpdatedPersonCommand, UpdatedPersonResponse>
    {
        private IPersonWriteRepository _personWriteRepository;
        private IMapper _mapper;
        public UpdatedPersonCommandHandler(IPersonWriteRepository personWriteRepository, IMapper mapper)
        {
            _personWriteRepository = personWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedPersonResponse> Handle(UpdatedPersonCommand request, CancellationToken cancellationToken)
        {
            Person mappedPerson = _mapper.Map<Person>(request);
            string passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            mappedPerson.PasswordHash = passwordHash;
            mappedPerson.PasswordSalt = passwordSalt;
            var updatedPerson = await _personWriteRepository.UpdateAsync(mappedPerson);
            UpdatedPersonResponse response = _mapper.Map<UpdatedPersonResponse>(updatedPerson);
            return response;
        }
    }
}