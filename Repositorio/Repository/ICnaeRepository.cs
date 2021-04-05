using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repository
{
     public interface ICnaeRepository :IRepository<Cnae>
    {
       
        IQueryable GetCnaeByName(string name);

        IQueryable GetCnaeByName(int id);
    }
}
