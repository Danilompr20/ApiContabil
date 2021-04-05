using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using MovcontabilClone.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public MovContext _context;

        public Repository(MovContext context)
        {
            _context = context;
        }
        // o SEt<T> retorna uma instancia de DBset que acesso a entidade de um determinado tipo
        // IQuerable retorna uma lista de entidade
        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        // retorna uma entidade
        //public T GetById(Expression<Func<T, bool>> predicate)
        //{
        //    return _context.Set<T>().SingleOrDefault(predicate);
        //}

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

      
    }
}
