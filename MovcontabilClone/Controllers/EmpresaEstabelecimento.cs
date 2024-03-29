﻿using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using Repositorio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Aplication.Interface;
using System.Threading.Tasks;
using Aplication.Model;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MovcontabilClone.Controllers
{
    //[Authorize]
    [Route("api/[Controller]")]
    [ApiController]
    public class EmpresaEstabelecimentoController : Controller
    {
        private readonly IEmpresaApplication _empresaApplication;
        private readonly IWebHostEnvironment _envi;

        public EmpresaEstabelecimentoController(IEmpresaApplication empresaApplication, IWebHostEnvironment envi)
        {
            _empresaApplication = empresaApplication;
            _envi = envi;
        }
        [HttpGet]
        public ActionResult <IEnumerable<EmpresaEstabelecimentoViewModel>> Get()
        
        {
            var diretorio = Directory.GetCurrentDirectory();
            var diretorio2 = _envi.ContentRootPath;
            var diretorio3 = _envi.WebRootPath;
            var empresa = new EmpresaEstabelecimento();

            var empresaEstabelecimentos = _empresaApplication.Get()?.ToList();
            if (empresaEstabelecimentos == null)
            {
                return NotFound("Nenhuma Empresa Encontrada");
            }
            return Ok (empresaEstabelecimentos);
        }
        // o id da url é passado para o metodo
        [HttpGet("{id}", Name = "detalhes")]
        public ActionResult<EmpresaEstabelecimentoViewModel> Get(int id)
        {
            var empresaEstabelecimento = _empresaApplication.GetEmpresaById(id);
            if (empresaEstabelecimento == null)
            {
                return NotFound();
            }

            
            return empresaEstabelecimento;
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmpresaEstabelecimentoViewModel empresa)
        {
            _empresaApplication.Add(empresa);
            return new CreatedAtRouteResult("Detalhes", new { id = empresa.Id }, empresa);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EmpresaEstabelecimentoViewModel empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();

            }
            _empresaApplication.Update(id,empresa);
           
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<EmpresaEstabelecimento> Delete(int id)
        {
            _empresaApplication.Delete(id);
            return Ok();
        }

        

    }
}
   

