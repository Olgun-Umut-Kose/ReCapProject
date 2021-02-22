using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepo<User>
    {
        IDataResult<bool?> CheckCustomersForUsers(User entity);
    }
}