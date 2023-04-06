using MediatR;
using Tourniquet.Application.Configuration.Auth;

namespace Tourniquet.Application.Features.Auth.Commands.Login
{
    public class PersonLoginCommand : IRequest<PersonLoginCommandResponse>
    {
        public PersonForLogin PersonForLogin { get; set; }
    }
}