using Aplication.Model;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
   public interface IEmpresaApplication
    {
        IQueryable GetEventoByName(string name);

        IEnumerable<EmpresaEstabelecimentoViewModel> Get();
        EmpresaEstabelecimentoViewModel GetEmpresaByName(string name);
        EmpresaEstabelecimentoViewModel GetEmpresaById(int id);
        EmpresaEstabelecimentoViewModel Add(EmpresaEstabelecimentoViewModel model);
        EmpresaEstabelecimentoViewModel Update(int id, EmpresaEstabelecimentoViewModel model);
        void Delete(int id);
    }
}
