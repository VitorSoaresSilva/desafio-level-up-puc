using DesafioLevelUp.Models;
using DesafioLevelUp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DesafioLevelUp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private IOrderService _orderService;
        public OrderController(ILogger<OrderController> logger,IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderService.FindById(id);
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
            return Ok(_orderService.Create(order));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Order order)
        {
            if (order == null) return BadRequest();
            return Ok(_orderService.Update(order));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return NoContent();
        }
        
    }

}
