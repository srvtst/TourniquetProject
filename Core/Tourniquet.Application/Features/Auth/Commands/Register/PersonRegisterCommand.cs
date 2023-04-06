using MediatR;
using Tourniquet.Application.Configuration.Auth;

namespace Tourniquet.Application.Features.Auth.Commands.Register
{
    public class PersonRegisterCommand : IRequest<PersonRegisterCommandResponse>
    {
        public PersonCreateAndRegister PersonCreateAndRegister { get; set; }
    }
}