using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepo<User>
    {
        bool CheckCustomersForUsers(User entity);
    }
}