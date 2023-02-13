using CoreLayer.Utilities.Results;
using EntitiesLayer.Concrete;
using EntitiesLayer.Dto;

namespace BusinessLayer.Abstract
{
    public interface IPersonService
    {
        IDataResult<Person> GetByEmail(string email);
        IResult Add(Person person);
        IResult Update(PersonUpdate personUpdate);
        IResult Delete(int id);
    }
}