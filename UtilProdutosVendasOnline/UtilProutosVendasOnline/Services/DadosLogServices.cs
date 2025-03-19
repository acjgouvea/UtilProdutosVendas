using UtilitarioProdutoVendasOnline.Negocio;
using System;
using System.Data;
using UtilitarioProdutoVendasOnline.Transferencia;

namespace UtilitarioProdutoVendasOnline.Services
{
    public class DadosLogServices
    {


        public DataSet carregaObjetoLogProdutos(DadosLog Produto_ID)
        {
            try
            {
                DadosNeg dados = new DadosNeg();
                DataSet ds = new DataSet();

                ds = dados.SelecionarProdutoLog(Produto_ID);

                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }

        public DataSet carregaObjetoLogProdutosGrade(DadosLog Produto_ID)
        {
            try
            {
                DadosNeg dados = new DadosNeg();
                DataSet ds = new DataSet();

                ds = dados.SelecionarProdutoLogGrade(Produto_ID);

                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }
    }
}
