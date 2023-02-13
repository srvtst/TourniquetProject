using CoreLayer.Security.Jwt;
using CoreLayer.Utilities.Results;
using EntitiesLayer.Dto;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        IDataResult<AccessToken> CreateToken();
        IDataResult<PersonForLogin> Login(PersonForLogin personForLogin);
        IDataResult<PersonCreateAndRegister> Register(PersonCreateAndRegister personCreateAndRegister);
    }
}