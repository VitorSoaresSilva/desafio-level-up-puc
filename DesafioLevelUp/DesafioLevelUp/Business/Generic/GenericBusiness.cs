using DesafioLevelUp.Models.Base;
using DesafioLevelUp.Repository.Generic;
using System.Collections.Generic;

namespace DesafioLevelUp.Business.Generic
{
    public class GenericBusiness<T> : IBusiness<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        public GenericBusiness(IRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual List<T> FindAll()
        {
            return _repository.FindAll();
        }

        public virtual T FindById(int id)
        {
            return _repository.FindById(id);
        }
        public virtual T Create(T order)
        {
            return _repository.Create(order);
        }

        public virtual T Update(T order)
        {
            return _repository.Update(order);
        }
        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }
        private bool Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
