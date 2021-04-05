using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repository
{
     public interface IEmpresaRepository : IRepository<EmpresaEstabelecimento>
    {
       

        EmpresaEstabelecimento GetEmpresaByName(string name);

        EmpresaEstabelecimento GetEmpresaById(int id);

    }
}
