using Aplication.Interface;
using Domain.Entity;
using Repositorio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    class EmpresaApplication : IEmpresaApplication
    {
        private  readonly IRepository<EmpresaEstabelecimento> _repository;
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresaApplication(IRepository<EmpresaEstabelecimento> repository, IEmpresaRepository empresaRepository)
        {
            _repository = repository;
            _empresaRepository = empresaRepository;
        }

        public EmpresaEstabelecimento Add(EmpresaEstabelecimento model)
        {
            try
            {
                _empresaRepository.Add(model);
                return _empresaRepository.GetEmpresaById(model.Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public EmpresaEstabelecimento Update(int id, EmpresaEstabelecimento model)
        {
            try
            {
                var empresa = _empresaRepository.GetEmpresaById(id);
                if (empresa ==null)
                {
                    return null;
                }
                else
                {
                    _repository.Update(model);
                }
                return _empresaRepository.GetEmpresaById(model.Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var empresa = _empresaRepository.GetEmpresaById(id);
                if (empresa == null)
                {
                     throw new Exception("Empresa não encontrada");
                }
                else
                {
                    _repository.Delete(empresa);
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IQueryable<EmpresaEstabelecimento> Get()
        {
            try
            {
                var empresa = _repository.Get();
                if (empresa == null)
                {
                    return null;
                }
                else
                {
                    return empresa;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public EmpresaEstabelecimento GetEmpresaById(int id)
        {
            try
            {
                
                var empresa = _empresaRepository.GetEmpresaById(id);
                if (empresa == null)
                {
                    return null;
                }
                return empresa;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public EmpresaEstabelecimento GetEmpresaByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return null;
                }
                var empresa = _empresaRepository.GetEmpresaByName(name);
                return empresa;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IQueryable GetEventoByName(string name)
        {
            throw new NotImplementedException();
        }

        
    }
}
