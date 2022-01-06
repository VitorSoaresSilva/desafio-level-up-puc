using DesafioLevelUp.Models;
using DesafioLevelUp.Models.Context;
using DesafioLevelUp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioLevelUp.Business.Implementations
{
    public class OrderBusinessImplementation : IOrderBusiness
    {
        private readonly IOrderRepository _repository;
        public OrderBusinessImplementation(IOrderRepository repository)
        {
            _repository = repository;
        }
        public List<Order> FindAll()
        {
            return _repository.FindAll();
        }

        public Order FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Order Create(Order order)
        {
            return _repository.Create(order);
        }

        public Order Update(Order order)
        {
            return _repository.Update(order);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        private bool Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
