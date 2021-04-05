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
    public class CnaeRepository : Repository<Cnae>, ICnaeRepository
    {
        

        public CnaeRepository(MovContext context) : base(context)
        {
            
        }
  

        public IQueryable GetCnaeByName(string name)
        {
            return _context.Cnaes.Where(x=> x.Descricao.ToLower().Contains(name.ToLower()));
        }

        public IQueryable GetCnaeByName(int id)
        {
            return _context.Cnaes.Where(x => x.Id == id);
        }
    }
}
