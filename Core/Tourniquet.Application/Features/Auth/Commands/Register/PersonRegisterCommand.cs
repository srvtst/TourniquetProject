using MediatR;
using Tourniquet.Application.Dtos;

namespace Tourniquet.Application.Features.Auth.Commands.Register
{
    public class PersonRegisterCommand : IRequest<PersonRegisterCommandResponse>
    {
        public PersonCreateAndRegister PersonCreateAndRegister { get; set; }
    }
}