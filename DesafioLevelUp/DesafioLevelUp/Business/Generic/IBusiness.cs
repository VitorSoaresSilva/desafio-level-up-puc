using System.Collections.Generic;

namespace DesafioLevelUp.Business.Generic
{
    public interface IBusiness<T>
    {
        T Create(T item);
        T FindById(int id);
        List<T> FindAll();
        T Update(T item);
        void Delete(int id);
    }
}
