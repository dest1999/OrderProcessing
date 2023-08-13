using Microsoft.AspNetCore.Mvc;

namespace OrderProcessing
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IInputOrderHandler _inputOrderHandler;

        public OrderController(IInputOrderHandler inputOrderHandler)
        {
            _inputOrderHandler = inputOrderHandler;
        }

        [HttpPost("talabat")]
        public IActionResult CreateTalabat(string order)
        {//TODO возможно следует добавить валидацию моделей, обработку верных/неверных заказов 
            _inputOrderHandler.CreateNewOrderAsync(SystemType.talabat, order);
            return Ok();
        }

        [HttpPost("zomato")]
        public IActionResult CreateZomato(string order)
        {
            _inputOrderHandler.CreateNewOrderAsync(SystemType.zomato, order);
            return Ok();
        }

        [HttpPost("uber")]
        public IActionResult CreateUber(string order)
        {
            _inputOrderHandler.CreateNewOrderAsync(SystemType.uber, order);
            return Ok();
        }

    }
}
