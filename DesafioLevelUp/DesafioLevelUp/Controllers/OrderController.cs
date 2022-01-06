using DesafioLevelUp.Models;
using DesafioLevelUp.Business;
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
        private IOrderBusiness _orderBusiness;
        public OrderController(ILogger<OrderController> logger,IOrderBusiness orderService)
        {
            _logger = logger;
            _orderBusiness = orderService;
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

        [HttpPut]
        public IActionResult Update([FromBody] Order order)
        {
            if (order == null) return BadRequest();
            return Ok(_orderBusiness.Update(order));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _orderBusiness.Delete(id);
            return NoContent();
        }
        
    }

}
