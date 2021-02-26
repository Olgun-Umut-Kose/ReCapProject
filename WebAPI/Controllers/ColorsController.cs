using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : Controller
    {
        private IColorService _service;

        public ColorController(IColorService service)
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
        public IActionResult AddOrEdit(Color color)
        {
            var result = _service.AddOrEdit(color);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _service.Delete(color);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}