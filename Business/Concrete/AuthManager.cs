using BusinessLayer.Abstract;
using BusinessLayer.Contants;
using CoreLayer.Security.Hashing;
using CoreLayer.Security.Jwt;
using CoreLayer.Utilities.Results;
using DataAccessLayer.Abstract;
using EntitiesLayer.Concrete;
using EntitiesLayer.Dto;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IPersonDal _personDal;
        private readonly ITokenHelper _tokenHelper;
        public AuthManager(IPersonDal personDal, ITokenHelper tokenHelper)
        {
            _personDal = personDal;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<PersonForLogin> Login(PersonForLogin personForLogin)
        {
            var userToCheck = _personDal.GetByEmail(personForLogin.Email);
            if (userToCheck != null)
            {
                if (!HashingHelper.VerifyPasswordHash(personForLogin.Password, userToCheck.PasswordSalt, userToCheck.PasswordHash))
                {
                    throw new Exception("Mail veya şifre hatalı");
                }
                else
                {
                    return new SuccessDataResult<PersonForLogin>(personForLogin, Message.PersonLogin);
                }
            }
            else
                return new ErrorDataResult<PersonForLogin>("Mail veya şifre hatalı");
        }

        public IDataResult<PersonCreateAndRegister> Register(PersonCreateAndRegister personCreateAndRegister)
        {
            string passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(personCreateAndRegister.Password, out passwordHash, out passwordSalt);

            var person = new Person
            {
                FirstName = personCreateAndRegister.FirstName,
                LastName = personCreateAndRegister.LastName,
                Email = personCreateAndRegister.Email,
                PhoneNumber = personCreateAndRegister.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _personDal.Add(person);
            return new SuccessDataResult<PersonCreateAndRegister>(personCreateAndRegister, Message.PersonRegister);
        }

        public IDataResult<AccessToken> CreateToken()
        {
            var token = _tokenHelper.CreateToken();
            return new SuccessDataResult<AccessToken>(token);
        }
    }
}