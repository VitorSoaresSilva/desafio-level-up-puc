using DesafioLevelUp.Models;
using System.Collections.Generic;

namespace DesafioLevelUp.Business
{
    public interface IOrderBusiness
    {
        Order Create(Order order);
        Order FindById(int id);
        List<Order> FindAll();
        Order Update(Order order);
        void Delete(int id);
    }
}
