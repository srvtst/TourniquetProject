using Tourniquet.Application.Repositories;
using Tourniquet.Application.SecurityHelper.Helpers;
using Tourniquet.Domain;

namespace Tourniquet.Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private IPersonReadRepository _readRepository;
        public AuthBusinessRules(IPersonReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public Task PersonExists(Person person)
        {
            if (person == null) throw new Exception("Kullanıcı mevcut değildir");
            return Task.CompletedTask;
        }

        public Task PersonPasswordToCheck(int id, string password)
        {
            Person person = _readRepository.Get(p => p.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, person.PasswordHash, person.PasswordSalt))
            {
                throw new Exception("Şifre bilgisi hatalı");
            }
            return Task.CompletedTask;
        }
    }
}