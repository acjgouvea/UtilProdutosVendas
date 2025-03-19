using UtilitarioProdutoVendasOnline.Negocio;
using System;
using System.Data;
using UtilitarioProdutoVendasOnline.Transferencia;
using System.Windows.Forms;
using System.Collections.Generic;


namespace UtilitarioProdutoVendasOnline.Services
{
    public class DadosAlteracaoServices
    {

        public Dictionary<string, object> carregaObjetosAlteracao(DadosAlteracao dadosAlteracao)
        {
            try
            {
                DadosNeg dadosalteracao = new DadosNeg();

                var retOutPut = dadosalteracao.AdicionarAlterarProdutoPrecoEMkBPromocionaL(dadosAlteracao);
                return retOutPut;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
