using UtilitarioProdutoVendasOnline.Negocio;
using System;
using System.Data;
using System.Collections.Generic;
using UtilitarioProdutoVendasOnline.Transferencia;
using System.Net;
using System.Windows.Forms;


namespace UtilitarioProdutoVendasOnline.Services
{
    public class DesativarProdutosServices
    {

        public Dictionary<string, object> desativaMkupProduto(ProdutoDesativar codigo_IN)
        {
            try
            {
                DadosNeg produtosDesativar = new DadosNeg();
      
                var retOutPut = produtosDesativar.AtivarDesativarProdutoPrecoEMkBPromocional(codigo_IN);     
                return retOutPut;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Dictionary<string, object> desativaMkupProdutoGrade(ProdutoDesativar codigo_IN)
        {
            try
            {
                DadosNeg produtosDesativar = new DadosNeg();

                var retOutPut = produtosDesativar.AtivarDesativarProdutoPrecoEMkBPromocional(codigo_IN);
                return retOutPut;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
