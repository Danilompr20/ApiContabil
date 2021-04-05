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
    public class EmpresaRepository : Repository<EmpresaEstabelecimento>, IEmpresaRepository
    {
       

        public EmpresaRepository(MovContext context): base(context)
        {
           
        }

        public EmpresaEstabelecimento GetEmpresaById(int id)
        {
            return _context.EmpresaEstabelecimentos.Where(x => x.Id == id).FirstOrDefault();
        }

        public EmpresaEstabelecimento GetEmpresaByName(string name)
        {
            return _context.EmpresaEstabelecimentos.Where(x => x.NomeFantasia == name).FirstOrDefault();
        }

        

        
    }
}
