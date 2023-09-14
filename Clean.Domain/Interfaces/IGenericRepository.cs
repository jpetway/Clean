using Clean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById (int id);
        IEnumerable<T> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
