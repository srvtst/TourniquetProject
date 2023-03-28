using MediatR;
using Tourniquet.Application.Features.Auth.Rules;
using Tourniquet.Application.Repositories;
using Tourniquet.Application.Services.Auth;
using Tourniquet.Domain.Entities;

namespace Tourniquet.Application.Features.Auth.Commands.Login
{
    public class PersonLoginCommandHandler : IRequestHandler<PersonLoginCommand, PersonLoginCommandResponse>
    {
        private IAuthService _authService;
        private IPersonReadRepository _readPersonRepository;
        private AuthBusinessRules _businessRules;
        public PersonLoginCommandHandler(IAuthService authService, IPersonReadRepository personReadRepository, AuthBusinessRules authBusinessRules)
        {
            _authService = authService;
            _readPersonRepository = personReadRepository;
            _businessRules = authBusinessRules;
        }

        public async Task<PersonLoginCommandResponse> Handle(PersonLoginCommand request, CancellationToken cancellationToken)
        {
            Person personToCheck = _readPersonRepository.Get(x => x.Email == request.PersonForLogin.Email);
            await _businessRules.PersonExists(personToCheck);
            await _businessRules.PersonPasswordToCheck(personToCheck.Id, request.PersonForLogin.Password);
            PersonLoginCommandResponse response = new()
            {
                AccessToken = _authService.CreateToken()
            };
            return response;
        }
    }
}