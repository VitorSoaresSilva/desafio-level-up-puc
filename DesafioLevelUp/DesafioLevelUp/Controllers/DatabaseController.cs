using DesafioLevelUp.Business.Generic;
using DesafioLevelUp.Business.Implementations;
using DesafioLevelUp.Models;
using DesafioLevelUp.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace DesafioLevelUp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            IBusiness<Order> orderController = (IBusiness<Order>)HttpContext.RequestServices.GetService(typeof(IBusiness<Order>));
            IBusiness<Item> itemController = (IBusiness<Item>)HttpContext.RequestServices.GetService(typeof(IBusiness<Item>));

            var parser = Parser.FromFile(@"C:\Users\ti\Documents\Dotnet\DesafioLevelUp\desafio-level-up-puc\DesafioLevelUp\DesafioLevelUp\Resource\Desafio.txt");
            foreach (object obj in parser.Parse()) {
                    if (obj is Order order)
                    {
                        orderController.Create(order);
                    }
                    else if (obj is Item item)
                    {
                        itemController.Create(item);
                    }
            }

            return Ok();
        }
    }
}
