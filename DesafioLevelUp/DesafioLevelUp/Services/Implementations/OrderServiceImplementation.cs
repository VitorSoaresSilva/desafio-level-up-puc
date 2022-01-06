using DesafioLevelUp.Models;
using DesafioLevelUp.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioLevelUp.Services.Implementations
{
    public class OrderServiceImplementation : IOrderService
    {
        private MySQLContext _context;
        public OrderServiceImplementation(MySQLContext context)
        {
            _context = context;
        }
        public Order Create(Order order)
        {
            try
            {
                _context.Add(order);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return order;
        }

        public void Delete(int id)
        {
            var order = _context.Orders.SingleOrDefault(x=> x.Id.Equals(id));
            if(order != null)
            {
                try
                {
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Order> FindAll()
        {
            List<Order> pedidos = new List<Order> {
                new Order() {
                    Id =1,
                    date=System.DateTime.Today,
                    Descricao="opa",
                    status='E',
                    value=12

                }
            };


            return _context.Orders.ToList();
        }

        public Order FindById(int id)
        {
            return _context.Orders.SingleOrDefault(x => x.Id.Equals(id));
        }

        public Order Update(Order order)
        {
            if (!Exists(order.Id))
            {
                return new Order();
            }
            var orderRef = _context.Orders.SingleOrDefault(x => x.Id.Equals(order.Id));
            if (orderRef != null)
            {
                try
                {
                    _context.Entry(orderRef).CurrentValues.SetValues(order);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return order;
        }
        private bool Exists(int id)
        {
            return _context.Orders.Any(x => x.Id.Equals(id));
        }
    }
}
