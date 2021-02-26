using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        private IBrandService _service;

        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
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
        public IActionResult AddOrEdit(Brand brand)
        {
            var result = _service.AddOrEdit(brand);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _service.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}