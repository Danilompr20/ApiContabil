using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ClienteFornecedor
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string TipoPessoa { get; set; }
        public bool? Cliente { get; set; }
        public bool? Fornecedor { get; set; }
        public bool? Transportadora { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public bool? Ativo { get; set; }
        public string CpfCnpj { get; set; }
        public bool? SimplesNacional { get; set; }
        public string RgInscricaoEstadual { get; set; }
        public string RgInscricaoMunicipal { get; set; }
        public short? Regiao { get; set; }
        public byte Segmento { get; set; }
        public string Sexo { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string NumeroLogradouro { get; set; }
        public string ComplementoLogradouro { get; set; }
        public string Bairro { get; set; }
        public bool? PisRetido { get; set; }
        public bool? CofinsRetido { get; set; }
        public bool? CsllRetido { get; set; }
        public bool? InssRetido { get; set; }
        public bool? IssRetido { get; set; }
        public bool? IrRetido { get; set; }
        public int? Cnae { get; set; }
        public bool ContribuinteIcms { get; set; }
        public string Classificacao { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public string EmailNfe { get; set; }
        public short? TipoPix { get; set; }
        public string ChavePix { get; set; }

    }
}
