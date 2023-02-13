using CoreLayer.Utilities.Results;
using EntitiesLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ITourniquetService
    {
        IResult Entry(Tourniquet tourniquet);
        IResult Exit(Tourniquet tourniquet);
        IDataResult<List<Tourniquet>> GetAll();
        IDataResult<Tourniquet> GetByTourniquet(int id);
        IDataResult<List<Tourniquet>> GetDayTourniquet(DateTime dateTime);
        IDataResult<List<Tourniquet>> GetMonthTourniquet(DateTime dateTime);
    }
}