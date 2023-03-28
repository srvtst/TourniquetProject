using AutoMapper;
using MediatR;
using Tourniquet.Application.Repositories;
using Tourniquet.Application.SecurityHelper.Helpers;
using Tourniquet.Application.Services.Auth;
using Tourniquet.Domain.Entities;

namespace Tourniquet.Application.Features.Auth.Commands.Register
{
    public class PersonRegisterCommandHandler : IRequestHandler<PersonRegisterCommand, PersonRegisterCommandResponse>
    {
        private IAuthService _authService;
        private IMapper _mapper;
        private IPersonWriteRepository _personWriteRepository;
        public PersonRegisterCommandHandler(IAuthService authService, IPersonWriteRepository personWriteRepository, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
            _personWriteRepository = personWriteRepository;
        }

        public async Task<PersonRegisterCommandResponse> Handle(PersonRegisterCommand request, CancellationToken cancellationToken)
        {
            Person mappedPerson = _mapper.Map<Person>(request.PersonCreateAndRegister);

            string passwordSalt, passwordHash;

            HashingHelper.CreatePasswordHash(request.PersonCreateAndRegister.Password, out passwordHash, out passwordSalt);

            mappedPerson.PasswordSalt = passwordSalt;
            mappedPerson.PasswordHash = passwordHash;

            await _personWriteRepository.AddAsync(mappedPerson);

            PersonRegisterCommandResponse response = new()
            {
                AccessToken = _authService.CreateToken()
            };

            return response;
        }
    }
}