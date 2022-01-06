using DesafioLevelUp.Models;
using System.Collections.Generic;

namespace DesafioLevelUp.Repository
{
    public interface IOrderRepository
    {
        Order Create(Order order);
        Order FindById(int id);
        List<Order> FindAll();
        Order Update(Order order);
        void Delete(int id);
        bool Exists(int id);
    }
}
