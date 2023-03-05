using Tourniquet.Application.Dtos.Token;

namespace Tourniquet.Application.Services.Auth
{
    public interface IAuthService
    {
        AccessToken CreateToken();
    }
}