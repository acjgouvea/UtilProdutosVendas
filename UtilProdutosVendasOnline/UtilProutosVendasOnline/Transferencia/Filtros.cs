using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitarioProdutoVendasOnline.Transferencia
{
    public class Filtros
    {
        public int? Loja_IN { get; set; }

        public int? Produto_IN { get; set; }

        public int? Empresa_IN { get; set; }

        public string Descricao_VC { get; set; }

        public string Marca_VC { get; set; }

        public string CA_VC { get; set; }

        public string Referencia_VC { get; set; }

        public string Agrupador_VC { get; set; }

        public string Fornecedor_VC { get; set; }
        
        public int? Familia_IN { get; set; }

        public int? Grupo_IN { get; set; }
       
        public int? SubGrupo_IN { get; set; }

        public int? Temp_IN { get; set; }   
        
        public int? Tipo_IN {  get; set; }
        
        public DateTime? VigenciaDe_DT { get; set; }
        
        public DateTime? VigenciaAte_DT { get; set; }
        
        public string MkupDe { get; set; }
        
        public string MkupAte { get; set; }

        public int? Codigo_Grade { get; set; } 

    }
}
