using DesafioLevelUp.Business.Generic;
using DesafioLevelUp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLevelUp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController: ControllerBase
    {
        private IBusiness<Item> _itemBusiness;
        public ItemController(IBusiness<Item> itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_itemBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _itemBusiness.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
