using EntitiesLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ITourniquetDal
    {
        void Entry(Tourniquet tourniquet);
        void Exit(Tourniquet Tourniquet);
        Tourniquet GetByTourniquet(int id);
        List<Tourniquet> GetAll();
        List<Tourniquet> GetDayTourniquet(DateTime dateTime);
        List<Tourniquet> GetMonthTourniquet(DateTime dateTime);
    }
}