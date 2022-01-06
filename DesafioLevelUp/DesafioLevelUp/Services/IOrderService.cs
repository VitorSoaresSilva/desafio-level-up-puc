using DesafioLevelUp.Models;
using System.Collections.Generic;

namespace DesafioLevelUp.Services
{
    public interface IOrderService
    {
        Order Create(Order order);
        Order FindById(int id);
        List<Order> FindAll();
        Order Update(Order order);
        void Delete(int id);
    }
}
