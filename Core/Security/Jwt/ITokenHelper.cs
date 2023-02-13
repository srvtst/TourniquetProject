namespace CoreLayer.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken();
    }
}