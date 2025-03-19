using Falco.BancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using UtilitarioProdutoVendasOnline.Transferencia;
using UtilitarioProdutosVendasOnline.Erros;

namespace UtilitarioProdutoVendasOnline.Negocio {
    public class DadosNeg {
        public DataSet SelecionarProdutosFiltroVendasOnline(Filtros filtros) {
            try {
                clsBancoDados.LimparParametros();

                DataSet dataSet = new DataSet();

                clsBancoDados.AdicionarParametro("@_PAR_loj_loja_IN", filtros.Loja_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_codigo_IN", filtros.Produto_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_Empresa_IN", filtros.Empresa_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_descricao_VC", filtros.Descricao_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_marca_VC", filtros.Marca_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_CA_VC", filtros.CA_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_fornecedor_VC", filtros.Fornecedor_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_familia_IN", filtros.Familia_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_grupo_IN", filtros.Grupo_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_subgrupo_IN", filtros.SubGrupo_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_agrupador_VC", filtros.Agrupador_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_referencia_VC", filtros.Referencia_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_temp_IN", filtros.Temp_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_Tipo_IN", filtros.Tipo_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_VigenteDe", filtros.VigenciaDe_DT, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_VigenteAte", filtros.VigenciaAte_DT, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_MkupDe", filtros.MkupDe, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_MkupAte", filtros.MkupAte, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_CodAgrupador_IN", filtros.Codigo_Grade, ParameterDirection.Input);

                dataSet = clsBancoDados.Executar("usp_SelecionarProdutosFiltroVendasOnline", CommandType.StoredProcedure);
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet SelecionarProdutosFiltroVendasOnlineGrade(Filtros filtros) {
            try {
                clsBancoDados.LimparParametros();

                DataSet dataSet = new DataSet();

                clsBancoDados.AdicionarParametro("@_PAR_loj_loja_IN", filtros.Loja_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_codigo_IN", filtros.Produto_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_Empresa_IN", filtros.Empresa_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_descricao_VC", filtros.Descricao_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_marca_VC", filtros.Marca_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_CA_VC", filtros.CA_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_fornecedor_VC", filtros.Fornecedor_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_familia_IN", filtros.Familia_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_grupo_IN", filtros.Grupo_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_subgrupo_IN", filtros.SubGrupo_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_agrupador_VC", filtros.Agrupador_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_referencia_VC", filtros.Referencia_VC, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_temp_IN", filtros.Temp_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_Tipo_IN", filtros.Tipo_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_VigenteDe", filtros.VigenciaDe_DT, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_VigenteAte", filtros.VigenciaAte_DT, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_MkupDe", filtros.MkupDe, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_MkupAte", filtros.MkupAte, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_CodAgrupador_IN", filtros.Codigo_Grade, ParameterDirection.Input);

                dataSet = clsBancoDados.Executar("usp_SelecionarProdutosFiltroVendasOnlineGrade", CommandType.StoredProcedure);
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet SelecionarProdutoLog(DadosLog dadosLog) {
            try {
                clsBancoDados.LimparParametros();

                DataSet dataSet = new DataSet();

                clsBancoDados.AdicionarParametro("@_PAR_Produto_IN", dadosLog.ppp_produto_IN, ParameterDirection.Input);

                dataSet = clsBancoDados.Executar("usp_SelecionarLogProdutosVendasOnline", CommandType.StoredProcedure);
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }


        public DataSet SelecionarProdutoLogGrade(DadosLog dadosLog) {
            try {
                clsBancoDados.LimparParametros();

                DataSet dataSet = new DataSet();

                clsBancoDados.AdicionarParametro("@_PAR_Produto_IN", dadosLog.ppp_produto_IN, ParameterDirection.Input);

                dataSet = clsBancoDados.Executar("usp_SelecionarLogProdutosVendasOnlineGrade", CommandType.StoredProcedure);
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }
        public Dictionary<string, object> AdicionarAlterarProdutoPrecoEMkBPromocionaL(DadosAlteracao dadosAlteracao) {
            try {
                clsBancoDados.LimparParametros();

                DataSet dataSet = new DataSet();

                // Parêmetros de entrada
                clsBancoDados.AdicionarParametro("@_PAR_Loja_IN", dadosAlteracao.Loja_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_Produto_IN", dadosAlteracao.Produto_IN, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_PrecoPromocional_MN", dadosAlteracao.PrecoFixo, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_mKbpPromocional_MN", dadosAlteracao.MkUpPromocional, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_DataValidade_DT", dadosAlteracao.DataValidade, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_Motivo_VC", dadosAlteracao.Motivo, ParameterDirection.Input);

                // Parâmetros de saída
                clsBancoDados.AdicionarParametro("@_PAR_RetOutput", null, ParameterDirection.Output);

                Dictionary<string, object> result = clsBancoDados.ExecutarRetOutPut("usp_VendasONline_AdicionarAlterarProdutoPrecoEMkBPromocionaL", CommandType.StoredProcedure);

                return result;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um Dicionário vazio em caso de falha
                return new Dictionary<string, object>();
            }
        }

        public Dictionary<string, object> AtivarDesativarProdutoPrecoEMkBPromocional(ProdutoDesativar codigo_IN) {
            try {
                clsBancoDados.LimparParametros();

                // Parêmtros de entrada
                clsBancoDados.AdicionarParametro("@_PAR_Codigo_IN", codigo_IN.ppp_codigo_IN, ParameterDirection.Input);

                // Parâmetros de saída
                clsBancoDados.AdicionarParametro("@_PAR_RetOutput", null, ParameterDirection.Output);

                Dictionary<string, object> result = clsBancoDados.ExecutarRetOutPut("usp_VendasONline_AtivarDesativarProdutoPrecoEMkBPromocional", CommandType.StoredProcedure);

                return result;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um Dicionário vazio em caso de falha
                return new Dictionary<string, object>();
            }
        }

        public DataSet ConsultarEmpresasVendasOnline() {
            try {
                clsBancoDados.LimparParametros();
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_Consultarempresasvendasonline");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet ConsultarLojasVendasOnline() {
            try {
                clsBancoDados.LimparParametros();
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_Consultarlojasvendasonline");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet ConsultarFamiliaVendasOnline() {
            try {
                clsBancoDados.LimparParametros();
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_ConsultarFamiliaVendasOnline");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet ConsultarGrupoVendasOnline(int familia) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@familia", familia);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_ConsultarGrupoVendasOnline");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }
        public DataSet ConsultarSubGrupoVendasOnline(int familia, int grupo) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@familia", familia);
                clsBancoDados.AdicionarParametro("@grupo", grupo);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_ConsultarSubGrupoVendasOnline");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet ConsultarTempVendasOnline(int familia, int grupo, int subgrupo) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@Familia_IN", familia);
                clsBancoDados.AdicionarParametro("@Grupo_IN", grupo);
                clsBancoDados.AdicionarParametro("@SubGrupo_IN", subgrupo);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_ConsultarTempVendasonline");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet ConsultarMargemPadraoVendasonline(int loja) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@_PAR_loj_loja_IN", loja, ParameterDirection.Input);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_ConsultarMargemPadraoVendasonline");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet ConsultarProdutoDesativar(int? produto) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@_PAR_Produto_IN", produto);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_SelecionarProdutosProdutoPrecoEMkBPromocional");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet ConsultarProdutoDesativarGrade(int? produto) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@_PAR_Produto_IN", produto);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_SelecionarProdutosProdutoPrecoEMkBPromocionalGrade");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet ConsultarMotivosMkupPreco() {
            try {
                clsBancoDados.LimparParametros();
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_RetornaVendasONline_MotivosMkupPreco");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet GravarMkupPadraoLoja(MkupLoja dadosalteracao) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@_PAR_loj_loja_IN", dadosalteracao.loj_codigo_IN);
                clsBancoDados.AdicionarParametro("@_PAR_ValorMkupPadrao_MN", dadosalteracao.loj_margemdelucropadrao_MN);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_AlterarMkupPadraoLoja");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet GravarLogMkupPadraoLoja(LogMkupLoja dadoslogalteracao) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@_PAR_Loja_IN", dadoslogalteracao.loj_loja_IN);
                clsBancoDados.AdicionarParametro("@_PAR_MkupPadrao_MN", dadoslogalteracao.MkupPadrao);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_GravarLogMkupPadraoLoja");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet GravarMotivoMkupPreco(MotivoMkup motivoMkup) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@_PAR_Motivo_VC", motivoMkup.mmp_motivo_VC);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_GravaMotivoMkupPreco");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet RetornaVendasONline_MotivosMkupPreco() {
            try {
                clsBancoDados.LimparParametros();
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_RetornaVendasONline_MotivosMkupPreco");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet RetornaVendasONline_LogMkupLoja() {
            try {
                clsBancoDados.LimparParametros();
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_RetornaVendasONline_LogMkupLoja");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet DeletarMotivosMkupPreco(MotivoMkup motivoMkup) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@_PAR_Codigo_IN", motivoMkup.mmp_codigo_IN);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_DeletarMotivoMkupPreco");
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }

        public DataSet RetornarProdutosGrade(int codigograde, int loja) {
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@_PAR_Codigo_Grade_IN", codigograde, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@_PAR_loj_loja_IN", loja, ParameterDirection.Input);
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_VendasONLINE_ConsultarProdutosGrade", CommandType.StoredProcedure);
                return dataSet;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }


        public DataSet SelecionarProdutosCategoriaAdicionalVendasONLINE() {
            try {
                clsBancoDados.LimparParametros();
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_SelecionarProdutosCategoriaAdicionalVendasONLINE");
                return dataSet;
            } catch (Exception ex) {

                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }


        public DataSet SelecionarProdutosVendasONLINE() {
            try {
                clsBancoDados.LimparParametros();
                DataSet dataSet = new DataSet();
                dataSet = clsBancoDados.Executar("usp_SelecionarProdutosVendasONLINE");
                return dataSet;
            } catch (Exception ex) {

                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return new DataSet();
            }
        }



        public Dictionary<string, object> AdicionaProdutoCategoriaAdicional(int loja, int produto, int catIrroba, int codGrade) {
           // int retOutPut = 0;
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("@CAC_loj_loja_IN", loja, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@CAC_pro_produto_IN", produto, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@CAC_ID_CategoriaIrroba_IN", catIrroba, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@CAC_gdp_codigo_IN", codGrade, ParameterDirection.Input);
                //clsBancoDados.AdicionarParametro("@CAC_RetOutPut", retOutPut, ParameterDirection.Output);

                return clsBancoDados.ExecutarRetOutPut("usp_AdicionarProdutoNaCategoriaAdicional", CommandType.StoredProcedure);

            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return null;
            }
        }

        public Dictionary<string, object> ExcluirProdutoCategoriaAdicional(int loja, int produto, int catIrroba, int codGrade) {
            //int retOutPut = 0;
            try {
                clsBancoDados.LimparParametros();
                clsBancoDados.AdicionarParametro("CAC_loj_loja_IN ", loja, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@CAC_pro_produto_IN", produto, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@CAC_ID_CategoriaIrroba_IN", catIrroba, ParameterDirection.Input);
                clsBancoDados.AdicionarParametro("@CAC_gdp_codigo_IN", codGrade, ParameterDirection.Input);


                return clsBancoDados.ExecutarRetOutPut("usp_ExcluirProdutoNaCategoriaAdicional", CommandType.StoredProcedure);

            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um DataSet vazio em caso de falha
                return null;
            }
        }


    }
}
