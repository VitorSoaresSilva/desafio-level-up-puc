using DesafioLevelUp.Business.Generic;
using DesafioLevelUp.Models;
using DesafioLevelUp.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DesafioLevelUp.Business.Implementations
{
    public class ItemBusinessImplementation : GenericBusiness<Item>
    {
        private readonly IRepository<Item> _repository;
        public ItemBusinessImplementation(IRepository<Item> repository) : base(repository)
        {
            _repository = repository;
        }

        public override Item Create(Item item)
        {
            if(item.Order == null)
            {
                return null;
            }
            if (item.Order.Status == 'A')
            {
                return _repository.Create(item);
            }
            else
            {
                return null;
            }
        }
    }
}
