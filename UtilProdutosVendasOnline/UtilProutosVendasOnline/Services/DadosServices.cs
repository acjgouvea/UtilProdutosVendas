using UtilitarioProdutoVendasOnline.Negocio;
using System;
using System.Data;
using UtilitarioProdutoVendasOnline.Transferencia;

namespace UtilitarioProdutoVendasOnline.Services
{
    public class DadosServices
    {
        public DataSet carregaObjetoFiltro(Filtros filtros)
        {
            try
            {
                DadosNeg dados = new DadosNeg();
                DataSet ds = new DataSet();

                ds = dados.SelecionarProdutosFiltroVendasOnline(filtros);

                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }
        public DataSet carregaObjetoFiltroGrade(Filtros filtros)
        {
            try
            {
                DadosNeg dados = new DadosNeg();
                DataSet ds = new DataSet();

                ds = dados.SelecionarProdutosFiltroVendasOnlineGrade(filtros);

                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }

    }
}
