using Lojinha3.Domain.Model;
using Lojinha3API.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lojinha3.Data.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly LojinhaContext _context;
        private DbSet<T> dataset;
        public GenericRepository(LojinhaContext lojinhaContext)
        {
            _context = lojinhaContext;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        public bool Delete(long id)
        {
           var result = dataset.SingleOrDefault(p => p.Equals(id));
            if(result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return false;
        }

        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindByID(long id)
        {
            return dataset.SingleOrDefault(x => x.Id == id);
        }

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(x => x.Id.Equals(item.Id));
            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
