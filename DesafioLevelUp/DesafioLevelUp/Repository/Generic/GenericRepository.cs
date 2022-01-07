using DesafioLevelUp.Models.Base;
using DesafioLevelUp.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace DesafioLevelUp.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected internal DbSet<T> dataSet;
        private MySQLContext _context;
        private IQueryable<T> _queriableWithIncludes;


        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
            var query = dataSet.AsQueryable();
            foreach (var pi in typeof(T).GetProperties())
            {
                var ca = pi.GetCustomAttribute(typeof(ForeignKeyAttribute));
                if (ca != null)
                {
                    Type t = pi.PropertyType;
                    if (t == typeof(int))
                    {
                        t = typeof(T).GetProperty(pi.Name[0..^2]).PropertyType;
                    }
                    else if (t == typeof(ICollection<>))
                    {
                        t = t.GetGenericArguments()[0];
                    }
                    var nullable = Nullable.GetUnderlyingType(t);
                    if (nullable != null)
                    {
                       t = nullable;
                    }

                    query = query.Include(t.Name);
                }
            }
            _queriableWithIncludes = query;
        }

        public List<T> FindAll()
        {
            return _queriableWithIncludes.ToList();
        }

        public T FindById(int id)
        {
            return _queriableWithIncludes.FirstOrDefault(x => x.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public T Update(T item)
        {
            var orderRef = _context.Orders.SingleOrDefault(x => x.Id.Equals(item.Id));
            if (orderRef != null)
            {
                try
                {
                    _context.Entry(orderRef).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public void Delete(int id)
        {
            // var item = dataSet.SingleOrDefault(x => x.Id.Equals(id));
            // if (item != null)
            {
                try
                {
                    _context.Entry(new T { Id = id }).State = EntityState.Deleted;
                    // dataSet.Remove(new T { Id = id });

                    // dataSet.Remove(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(int id)
        {
            return dataSet.Any(x => x.Id.Equals(id));
        }
    }
}
