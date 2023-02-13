using BusinessLayer.Abstract;
using BusinessLayer.Contants;
using CoreLayer.Security.Hashing;
using CoreLayer.Security.Jwt;
using CoreLayer.Utilities.Results;
using DataAccessLayer.Abstract;
using EntitiesLayer.Concrete;
using EntitiesLayer.Dto;
using System;

namespace BusinessLayer.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public IResult Add(Person person)
        {
            _personDal.Add(person);
            return new Result(true, Message.PersonAdded);
        }

        public IResult Delete(int id)
        {
            _personDal.Delete(id);
            return new Result(true, Message.PersonDeleted);
        }

        public IDataResult<Person> GetByEmail(string email)
        {
            var result = _personDal.GetByEmail(email);
            return new SuccessDataResult<Person>(result, Message.PersonGetByMail);
        }

        public IResult Update(PersonUpdate personUpdate)
        {
            string passwordHashUpdate, passwordSaltUpdate;
            HashingHelper.CreatePasswordHash(personUpdate.Password, out passwordHashUpdate, out passwordSaltUpdate);
            var person = new Person
            {
                Id = personUpdate.Id,
                FirstName = personUpdate.FirstName,
                LastName = personUpdate.LastName,
                Email = personUpdate.Email,
                PhoneNumber = personUpdate.PhoneNumber,
                PasswordHash = passwordHashUpdate,
                PasswordSalt = passwordSaltUpdate
            };
            _personDal.Update(person);
            return new Result(true, Message.PersonUpdated);
        }
    }
}