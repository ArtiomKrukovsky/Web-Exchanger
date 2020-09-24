using Microsoft.AspNetCore.Mvc;
using WebStore.Auth.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.Resource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public ProductsController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products);
        }
    }
}
