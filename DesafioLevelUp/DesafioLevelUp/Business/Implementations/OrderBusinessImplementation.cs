using DesafioLevelUp.Business.Generic;
using DesafioLevelUp.Models;
using DesafioLevelUp.Repository.Generic;

namespace DesafioLevelUp.Business.Implementations
{
    public class OrderBusinessImplementation : GenericBusiness<Order>
    {
        private readonly IRepository<Order> _repository;

        public OrderBusinessImplementation(IRepository<Order> repository) : 
            base(repository)
        {
            _repository = repository;
        }

        public override void Delete(int id)
        {
            Order order = _repository.FindById(id);
            if(order != null)
            {
                order.Status = 'E';
            }

            _repository.Update(order);
        }
    }
}
