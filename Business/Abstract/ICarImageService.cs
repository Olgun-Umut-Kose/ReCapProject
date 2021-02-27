using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService : IEntityService<CarImage>
    {
        IResult AddOrEdit(IFormFile file, CarImage entity, string type);
    }
}