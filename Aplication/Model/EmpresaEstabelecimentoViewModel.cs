using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.Model
{
    public class EmpresaEstabelecimentoViewModel
    {
        public int Id { get; set; }

        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string InscricaoEstadual { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Cep { get; set; }

        public string Endereco { get; set; }

        public string NumeroComplemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string NomeFantasia { get; set; }

        public DateTime DataAbertura { get; set; }

        public decimal? Fap { get; set; }

       
        public int CnaePreponderanteId { get; set; }

        public string CnaeDescricao { get; set; }

        public string CnaeEmpresa { get; set; }

        public string NaturezaJuridica { get; set; }

        public string CodigoTerceiros { get; set; }

        public decimal PercentualTerceiros { get; set; }

        public decimal PercentualEmpresa { get; set; }

        public decimal? Rat { get; set; }

       
        public int? UsuarioId { get; set; }
    //    public Usuario Usuario { get; set; }
    }
}
