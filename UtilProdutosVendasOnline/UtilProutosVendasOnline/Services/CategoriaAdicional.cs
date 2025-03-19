using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitarioProdutoVendasOnline.Negocio;
using UtilitarioProdutoVendasOnline.Transferencia;

namespace UtilitarioProdutosVendasOnline.Services {
    internal class CategoriaAdicional {

        public DataSet carregaObjCategoriaAdicional( ) {
        //public DataSet carregaObjCategoriaAdicional(DadosGridCaregoriaAdicional dadosGridCaregoriaAdicional) {
            try {
                DadosNeg dados = new DadosNeg();
                DataSet ds = new DataSet();

                ds = dados.SelecionarProdutosCategoriaAdicionalVendasONLINE();

                return ds;

            } catch (Exception exception) {
                throw new Exception(exception.Message);
            }

        }


       // public DataSet carregaObjProdutosLojaOn (DadosGridprodutosVendasOnline dadosGridprodutosVendasOnline) {
        public DataSet carregaObjProdutosLojaOn () {
            try {
                DadosNeg dados = new DadosNeg();
                DataSet ds = new DataSet();

                ds = dados.SelecionarProdutosVendasONLINE();

                return ds;

            } catch (Exception exception) {
                throw new Exception(exception.Message);
            }

        }
    }
}



