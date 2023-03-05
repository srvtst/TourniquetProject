using MediatR;
using Tourniquet.Application.Dtos;

namespace Tourniquet.Application.Features.Auth.Commands.Login
{
    public class PersonLoginCommand : IRequest<PersonLoginCommandResponse>
    {
        public PersonForLogin PersonForLogin { get; set; }
    }
}