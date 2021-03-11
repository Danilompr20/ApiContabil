using Microsoft.AspNetCore.Mvc;
using MovcontabilClone.Entity;
using MovcontabilClone.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovcontabilClone.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmpresaEstabelecimentoController : Controller
    {
        private readonly IRepository<EmpresaEstabelecimento> _repository;

        public EmpresaEstabelecimentoController(IRepository<EmpresaEstabelecimento> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        //ActionResult permite retornar todos tipos contidos em IActionResult mais o tipo Produto por exemplo
        public ActionResult <IEnumerable<EmpresaEstabelecimento>> Get()
        {
            // to list cria uma lista de produtos, asNotracking, so para modo consulta
            var empresaEstabelecimentos = _repository.Get().ToList();
            
            return Ok (empresaEstabelecimentos);
        }

       

        // o id da url é passado para o metodo
        [HttpGet("{id}", Name = "detalhes")]
        // recebe o id enviado pela url
        public ActionResult<EmpresaEstabelecimento> Get(int id)
        {
            // filtra se produtoId que esta no banco é igual ao id recebido pelo paramentro
            var empresaEstabelecimento = _repository.GetById(x=> x.Id == id);

            // se for null retorna notfound se não for nulo retorna produto
            if (empresaEstabelecimento == null)
            {
                return NotFound();
            }
            // mapeando produtoDTO para listar por id
            
            return empresaEstabelecimento;
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmpresaEstabelecimento empresa)
        {
            
            
            _repository.Add(empresa);
           

            //mostrar para o usuario tem que mapear para produtoDTO
          
            // retorna uma rota pra o produto criado
            return new CreatedAtRouteResult("Detalhes", new { id = empresa.Id }, empresa);


        }

        [HttpPut("{id}")]
        // recebe o id do produto e os dados do produto a ser alterado pelo fromBody
        public ActionResult Put(int id, [FromBody] EmpresaEstabelecimento empresa)
        {
            // verficar se o id passado na url é igual o id do produto que está sendo alterado
            if (id != empresa.Id)
            {
                return BadRequest();

            }
            // antes de chamar o metodo mapea o produtoDTo para produto
           
            // se o id for igual altera o produto atraves deste metodo abaixo
            _repository.Update(empresa);
           
            return Ok();
        }

        [HttpDelete("{id}")]
        // recebe o id do produto e os dados do produto a ser alterado pelo fromBody
        public ActionResult<EmpresaEstabelecimento> Delete(int id)
        {
            // verficar se o id passado na url é igual o id do produto que está sendo deletado e armazena na variavel
            var empresa = _repository.GetById(x=> x.Id == id);

            // se for null retorna notfound se não for nulo retorna produto
            if (empresa == null)
            {
                return NotFound();
            }

            _repository.Delete(empresa);
           
            // mapea antes para produtoDTO antes de retornar
           

            return empresa;
        }

    }
}
   

