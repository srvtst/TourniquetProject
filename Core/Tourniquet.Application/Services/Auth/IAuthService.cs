using Tourniquet.Application.Configuration.Token;

namespace Tourniquet.Application.Services.Auth
{
    public interface IAuthService
    {
        AccessToken CreateToken();
    }
}