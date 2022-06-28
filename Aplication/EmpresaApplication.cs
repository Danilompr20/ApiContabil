using Aplication.Interface;
using Aplication.Model;
using AutoMapper;
using Domain.Entity;
using Repositorio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class EmpresaApplication : IEmpresaApplication
    {
        private  readonly IRepository<EmpresaEstabelecimento> _repository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        public EmpresaApplication(IRepository<EmpresaEstabelecimento> repository, IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _repository = repository;
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public EmpresaEstabelecimentoViewModel Add(EmpresaEstabelecimentoViewModel model)
        {
            try
            {
                var empresa = _mapper.Map<EmpresaEstabelecimento>(model);
                _empresaRepository.Add(empresa);
                 var retorno = _empresaRepository.GetEmpresaById(model.Id);
                

                return _mapper.Map<EmpresaEstabelecimentoViewModel>(retorno);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public EmpresaEstabelecimentoViewModel Update(int id, EmpresaEstabelecimentoViewModel model)
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
                    var empresaEntity = _mapper.Map<EmpresaEstabelecimento>(model);
                    _repository.Update(empresaEntity);
                }
                var retorno = _empresaRepository.GetEmpresaById(model.Id);
                return _mapper.Map<EmpresaEstabelecimentoViewModel>(retorno);
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

        public IQueryable<EmpresaEstabelecimentoViewModel> Get()
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
                    var viewModels = new List<EmpresaEstabelecimentoViewModel>();

                    foreach (var item in empresa)
                    {
                        var viewModel = _mapper.Map<EmpresaEstabelecimentoViewModel>(item);
                        viewModel.CnaeDescricao = item.Cnae.Descricao;
                        viewModels.Add(viewModel);
                    }
                     
                    return (IQueryable<EmpresaEstabelecimentoViewModel>)viewModels;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public EmpresaEstabelecimentoViewModel GetEmpresaById(int id)
        {
            try
            {
                
                var empresa = _empresaRepository.GetEmpresaById(id);
                if (empresa == null)
                {
                    return null;
                }
                var viewModel = _mapper.Map<EmpresaEstabelecimentoViewModel>(empresa);
                viewModel.CnaeDescricao = empresa.Cnae.Descricao;
                return viewModel;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public EmpresaEstabelecimentoViewModel GetEmpresaByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return null;
                }
                var empresa = _empresaRepository.GetEmpresaByName(name);
                var viewModel = _mapper.Map<EmpresaEstabelecimentoViewModel>(empresa);
                viewModel.CnaeDescricao = empresa.Cnae.Descricao;
                return viewModel;
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
