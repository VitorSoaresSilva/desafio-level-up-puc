using DesafioLevelUp.Models.Base;
using System.Collections.Generic;
namespace DesafioLevelUp.Repository.Generic
{
    public interface IRepository<T> where T: BaseEntity
    {
        T Create(T item);
        T FindById(int id);
        List<T> FindAll();
        T Update(T item);
        void Delete(int id);
        bool Exists(int id);
    }
}
