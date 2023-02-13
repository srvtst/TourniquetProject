using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class EFPersonDal : IPersonDal
    {
        private readonly TourniquetContext _context;
        public EFPersonDal(TourniquetContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var delete = _context.Persons.Single(p => p.Id == id);
            _context.Remove(delete);
            _context.SaveChanges();
        }

        public Person GetByEmail(string email)
        {
            return _context.Set<Person>().Single(x => x.Email == email);
        }

        public void Add(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
        }
    }
}