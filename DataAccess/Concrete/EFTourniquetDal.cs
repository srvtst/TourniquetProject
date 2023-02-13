using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class EFTourniquetDal : ITourniquetDal
    {
        private readonly TourniquetContext _context;
        public EFTourniquetDal(TourniquetContext context)
        {
            _context = context;
        }

        public void Entry(Tourniquet tourniquet)
        {
            _context.Add(tourniquet);
            _context.SaveChanges();
        }

        public void Exit(Tourniquet tourniquet)
        {
            _context.Update(tourniquet);
            _context.SaveChanges();
        }

        public List<Tourniquet> GetAll()
        {
            return _context.Set<Tourniquet>().ToList();
        }

        public Tourniquet GetByTourniquet(int id)
        {
            return _context.Set<Tourniquet>().Single(t => t.Id == id);
        }

        public List<Tourniquet> GetDayTourniquet(DateTime dateTime)
        {
            return _context.Set<Tourniquet>().Where(t => t.DateOfEntry.Day == dateTime.Day || t.ExitDate.Day == dateTime.Day).ToList();
        }

        public List<Tourniquet> GetMonthTourniquet(DateTime dateTime)
        {
            return _context.Set<Tourniquet>().Where(t => t.DateOfEntry.Month == dateTime.Month || t.ExitDate.Month == dateTime.Month).ToList();
        }
    }
}