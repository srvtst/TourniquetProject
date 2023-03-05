using Tourniquet.Application.Dtos.Token;

namespace Tourniquet.Application.Features.Auth.Commands.Register
{
    public class PersonRegisterCommandResponse
    {
        public AccessToken AccessToken { get; set; }
    }
}