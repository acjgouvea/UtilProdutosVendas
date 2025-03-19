using UtilitarioProdutoVendasOnline.Negocio;
using System;
using System.Data;
using UtilitarioProdutoVendasOnline.Transferencia;

namespace UtilitarioProdutoVendasOnline.Services
{
    public class MotivoMkupServices
    {

        public DataSet gravarMotivoMkupPreco(MotivoMkup motivoMkup)
        {
            try
            {
                DadosNeg mkupPadraoLojas = new DadosNeg();
                DataSet ds = new DataSet();

                ds = mkupPadraoLojas.GravarMotivoMkupPreco(motivoMkup);

                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public DataSet retornaGridMotivo()
        {
            try
            {
                DadosNeg motivoMkupLojas = new DadosNeg();
                DataSet ds = new DataSet();

                ds = motivoMkupLojas.RetornaVendasONline_MotivosMkupPreco();

                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public DataSet deletaMotivo(MotivoMkup motivo)
        {
            try
            {
                DadosNeg motivoMkupLojas = new DadosNeg();
                DataSet ds = new DataSet();

                ds = motivoMkupLojas.DeletarMotivosMkupPreco(motivo);

                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
