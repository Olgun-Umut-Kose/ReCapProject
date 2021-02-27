using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService : IEntityService<Rental>
    {
        IResult AddOrEdit(Rental entity);
    }
}