using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService : IEntityService<Color>
    {
        IResult AddOrEdit(Color entity);
    }
}