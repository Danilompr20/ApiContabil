using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    interface IEmpresaApplication
    {
        IQueryable GetEventoByName(string name);

        IQueryable<EmpresaEstabelecimento> Get();
        EmpresaEstabelecimento GetEmpresaByName(string name);
        EmpresaEstabelecimento GetEmpresaById(int id);
        EmpresaEstabelecimento Add(EmpresaEstabelecimento model);
        EmpresaEstabelecimento Update(int id,EmpresaEstabelecimento model);
        void Delete(int id);
    }
}
