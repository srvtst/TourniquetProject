using EntitiesLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IPersonDal
    {
        void Add(Person person);
        void Update(Person person);
        void Delete(int id);
        Person GetByEmail(string email);
    }
}