using UtilitarioProdutoVendasOnline.Negocio;
using System;
using System.Data;
using UtilitarioProdutoVendasOnline.Transferencia;
using System.Windows.Forms;
using System.Collections.Generic;


namespace UtilitarioProdutoVendasOnline.Services
{
    public class ProdutosGradeServices
    {

        public DataSet carregaProdutosGrade(int codigograde, int loja)
        {
            try
            {
                DadosNeg dadosalteracao = new DadosNeg();

                var result = dadosalteracao.RetornarProdutosGrade(codigograde, loja);
                return result;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
