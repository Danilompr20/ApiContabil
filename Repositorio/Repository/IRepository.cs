using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repository
{
     public interface IRepository<T>
    {
        IQueryable<T> Get();
      //  T GetById(Expression<Func<T, bool>> predicate);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);

       
    }
}
