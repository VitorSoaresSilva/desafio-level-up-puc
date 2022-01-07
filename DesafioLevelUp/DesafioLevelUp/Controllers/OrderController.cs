using DesafioLevelUp.Models;
using Microsoft.AspNetCore.Mvc;
using DesafioLevelUp.Business.Generic;

namespace DesafioLevelUp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase
    {
        //private readonly ILogger<OrderController> _logger;
        private IBusiness<Order> _orderBusiness;
        public OrderController(IBusiness<Order> orderBusiness)
        {
            //_logger = logger;
            _orderBusiness = orderBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderBusiness.FindById(id);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (order == null) return BadRequest();
            return Ok(_orderBusiness.Create(order));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _orderBusiness.Delete(id);
            return NoContent();
        }
        
    }

}
