using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CarImagesController : Controller
    {
        private ICarImageService _service;

        public CarImagesController(ICarImageService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        [HttpGet]
        public IActionResult Index()
        {
            var result = _service.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpPost("addoredit")]
        public IActionResult AddOrEdit([FromForm(Name = "Image")] IFormFile file, CarImage carImage)
        {
            var result = _service.AddOrEdit(file, carImage, "Image");
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _service.Delete(carImage);
            
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carid)
        {
            var result = _service.GetImagesByCarId(carid);
            
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}