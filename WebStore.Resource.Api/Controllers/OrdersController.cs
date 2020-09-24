using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Auth.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.Resource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly StoreDbContext _context;

        private Guid UserId => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public OrdersController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("")]
        public IActionResult GetOrders()
        {
            var orders = _context.Orders.ToList();
            return Ok(orders);
        }
    }
}
