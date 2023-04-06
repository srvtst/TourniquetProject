using Tourniquet.Application.Configuration.Token;

namespace Tourniquet.Application.Features.Auth.Commands.Login
{
    public class PersonLoginCommandResponse
    {
        public AccessToken AccessToken { get; set; }
    }
}