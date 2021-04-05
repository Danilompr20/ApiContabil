using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ProdutoServico
    {
        public int id { get; set; }

        public int Codigo { get; set; }

        public string CodigoInterno { get; set; }

        public string CodigoFabricante { get; set; }

        public byte? TipoItem { get; set; }

        public bool? Ativo { get; set; }

        public string DescricaoReduzido { get; set; }

        public string DescricaoCompleta { get; set; }

        public string UnidadeMedida { get; set; }

        public string Gtin { get; set; }

        public string Ncm { get; set; }

        public bool? PisRetido { get; set; }

        public bool? CofinsRetido { get; set; }

        public bool? CsllRetido { get; set; }

        public bool? InssRetido { get; set; }

        public bool? InssAutonomoRetido { get; set; }

        public bool? IssRetido { get; set; }

        public bool? IrRetido { get; set; }

        public decimal AliquotaIpiEntrada { get; set; }

        public decimal? AliquotaIcmsEntrada { get; set; }

        public decimal? AliquotaIpiSaida { get; set; }

        public decimal? AliquotaIcmsSaida { get; set; }

        public decimal? AliquotaReducaoIpi { get; set; }

        public decimal? AliquotaReducaoIcms { get; set; }

        public decimal? AliquotaInssEntrada { get; set; }

        public decimal? AliquotaInssSaida { get; set; }

        public decimal? AliquotaIr { get; set; }

        public decimal? AliquotaPis { get; set; }

        public decimal? AliquotaCofins { get; set; }
    }
}
