using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService : IEntityService<Customer>
    {
        IResult AddOrEdit(Customer entity);
    }
}