using UtilitarioProdutoVendasOnline.Negocio;
using System;
using System.Data;
using UtilitarioProdutoVendasOnline.Transferencia;

namespace UtilitarioProdutoVendasOnline.Services
{
    public class LogMkupLojaServices
    {

        public DataSet retornaGridLogMkupLoja()
        {
            try
            {
                DadosNeg motivoMkupLojas = new DadosNeg();
                DataSet ds = new DataSet();

                ds = motivoMkupLojas.RetornaVendasONline_LogMkupLoja();

                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }   
    }
}
