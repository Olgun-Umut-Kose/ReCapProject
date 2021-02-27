using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService : IEntityService<Brand>
    {
        IResult AddOrEdit(Brand entity);
    }
}