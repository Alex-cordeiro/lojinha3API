using Lojinha3.Domain.Model;
using System.Collections.Generic;

namespace Lojinha3.Data.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        bool Delete(long id);
        bool Exists(long id);
    }
}
