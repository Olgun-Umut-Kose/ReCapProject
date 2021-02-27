using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService : IEntityService<User>
    {
        IResult AddOrEdit(User entity);
    }
}