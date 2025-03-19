using UtilitarioProdutoVendasOnline.Negocio;
using System;
using System.Data;
using System.Collections.Generic;
using UtilitarioProdutoVendasOnline.Transferencia;


namespace UtilitarioProdutoVendasOnline.Services
{
    public class MkupPadraoServices
    {

        public DataSet gravarMkupPadraLoja(MkupLoja dadosAlteracao)
        {
            try
            {
                DadosNeg mkupPadraoLojas = new DadosNeg();
                DataSet ds = new DataSet();

                ds = mkupPadraoLojas.GravarMkupPadraoLoja(dadosAlteracao);

                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public DataSet gravarLogMkupPadraLoja(LogMkupLoja dadosLogAlteracao)
        {
            try
            {
                DadosNeg mkupPadraoLojas = new DadosNeg();
                DataSet ds = new DataSet();

                ds = mkupPadraoLojas.GravarLogMkupPadraoLoja(dadosLogAlteracao);

                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
