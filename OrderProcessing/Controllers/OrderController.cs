using Microsoft.AspNetCore.Mvc;

namespace OrderProcessing
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderController(IRepository<Order> repository)
        {
            _orderRepository = repository;
        }

        [HttpPost("talabat")]
        public IActionResult Create(string order)
        {
            return Ok( order);
        }
    }
}
