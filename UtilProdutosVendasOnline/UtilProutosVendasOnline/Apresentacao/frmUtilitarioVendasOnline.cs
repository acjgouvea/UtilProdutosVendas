using ClosedXML.Excel;
using Newtonsoft.Json;
using UtilitarioProdutoVendasOnline.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UtilitarioProdutoVendasOnline.Transferencia;
using UtilsNeobetel;
using UtilitarioProdutoVendasOnline.Services;
using UtilProutosVendasOnline.Apresentacao;
using System.Reflection;
using UtilitarioProdutosVendasOnline.Erros;
using UtilitarioProdutosVendasOnline.Apresentacao;

namespace UtilProutosVendasOnline {
    public partial class frmUtilitarioVendasOnline : Form {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private Size tamanhoOriginal;
        private bool ordemAscendente = true;
        public bool formAberto = false;

        Filtros filtros = new Filtros();

        DataSet dataSetDadosFiltro = new DataSet();
        DataSet dataSetDadosAlteracao = new DataSet();
        DataSet dataSetDesativarMkupProduto = new DataSet();
        DataSet dataSetDadosLogProdutos = new DataSet();
        DataSet dataSetAlteracoMkupPadrao = new DataSet();
        DataSet dataSetLogAlteracoMkupPadrao = new DataSet();

        List<LojaOnline> objLstLojas = new List<LojaOnline>();
        List<Empresa> objLstEmpresas = new List<Empresa>();
        List<Familia> objLstFamilia = new List<Familia>();
        List<Grupo> objLstGrupo = new List<Grupo>();
        List<SubGrupo> objLstSubGrupo = new List<SubGrupo>();
        List<Temp> objLstTemp = new List<Temp>();
        List<DadosAlteracao> objLstDadosSel = new List<DadosAlteracao>();
        List<DadosGrid> objLstDadosGrid = new List<DadosGrid>();
        List<DadosLog> objLstDadosLog = new List<DadosLog>();
        List<MotivoMkup> objLstMotivos = new List<MotivoMkup>();

        DadosNeg lojasVendasOnlineNegocio = new DadosNeg();
        DadosNeg empresasVendasOnlineNegocio = new DadosNeg();
        DadosNeg familiaVendasOnlineNegocio = new DadosNeg();
        DadosNeg grupoVendasOnlineNegocio = new DadosNeg();
        DadosNeg produtosDesativarNegocio = new DadosNeg();
        DadosNeg subgrupoVendasOnlineNegocio = new DadosNeg();
        DadosNeg produtosGraeNegocio = new DadosNeg();

        DadosGrid objDadosGridSel = new DadosGrid();

        public static string nomeProjeto = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();
        public static string pastaArquivoConfig = "C:\\NEOBETEL\\ConfigColunas" + nomeProjeto;
        public static string CaminhoArquivoConfiguracao = pastaArquivoConfig + "\\" + "configGrid" + nomeProjeto + ".json";


        public frmUtilitarioVendasOnline() {
            InitializeComponent();
        }

        private void frmUtilitarioVendasOnline_Load(object sender, EventArgs e) {
            tamanhoOriginal = this.Size;
            CarregarOrdemColunas();

            UtilGeral.Maximizar(this);
            UtilGeral.carregaVisualComponente(pnlFiltro);
            UtilGeral.formataPadrao_Grid(dgvProdutos);
            UtilGeral.formataPadrao_Grid(dgvLogAlteracoes);


            txtDescricao.TextChanged += txtDescricao_TextChanged;
            configuraMarcarDesmarcarTodos();
            ajustarCamposData();
            carregaComboLojas();
            carregaComboFamilia();
            carregaEmpresas();
            carregarComboLojasMkupPadrao();
            carregarComboMotivosMkupPreco();
            carregarMkupPadrao();
            CarregarDadosBanco();
        }

        private void CarregarDadosBanco() {
            DadosServices dadosServices = new DadosServices();

            var filtros = CarregarFiltros();

            if (chkGrade.Checked == true) {
                dataSetDadosFiltro = dadosServices.carregaObjetoFiltroGrade(filtros);
            } else {
                dataSetDadosFiltro = dadosServices.carregaObjetoFiltro(filtros);
            }


            objLstDadosGrid = dataSetDadosFiltro.Tables[0].ToList<DadosGrid>();
        }


        private void ajustarCamposData() {
            dtpDataVigencia.Format = DateTimePickerFormat.Custom;
            dtpDataVigencia.CustomFormat = " ";
            dtpDataVigencia.Checked = false;

            dtpDataVigenciaDe.Format = DateTimePickerFormat.Custom;
            dtpDataVigenciaDe.CustomFormat = " ";
            dtpDataVigenciaDe.Checked = false;
            dtpDataVigenciaAte.Format = DateTimePickerFormat.Custom;
            dtpDataVigenciaAte.CustomFormat = " ";
            dtpDataVigenciaAte.Checked = false;
        }

        private void MarcarTodos(bool marcado) {
            foreach (DataGridViewRow row in dgvProdutos.Rows) {
                row.Cells["campo_selecao"].Value = marcado;
            }
            dgvProdutos.Refresh();
        }

        private void carregaEmpresas() {
            objLstEmpresas = RetornaEmpresasVendasOnline();

            if (objLstEmpresas != null) {
                cboEmpresa.DisplayMember = "DescricaoEmpresaCompleta";
                cboEmpresa.ValueMember = "emp_empresa_IN";
                cboEmpresa.DataSource = objLstEmpresas;

                // Selecionar empresa como default
                var empresaSelecionada = objLstEmpresas.FirstOrDefault(empresa => empresa.emp_empresa_IN == 9);
                cboEmpresa.SelectedItem = empresaSelecionada;
            } else {
                cboEmpresa.DataSource = null;
            }
        }

        private void configuraMarcarDesmarcarTodos() {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem marcarTodosItem = new ToolStripMenuItem("Marcar Todos");
            ToolStripMenuItem desmarcarTodosItem = new ToolStripMenuItem("Desmarcar Todos");

            contextMenu.Items.Add(marcarTodosItem);
            contextMenu.Items.Add(desmarcarTodosItem);

            dgvProdutos.ContextMenuStrip = contextMenu;

            marcarTodosItem.Click += (s, ev) => MarcarTodos(true);
            desmarcarTodosItem.Click += (s, ev) => MarcarTodos(false);
        }

        private void carregaComboLojas() {
            objLstLojas = RetornaLojasVendasOnline();

            // Configurar o ComboBox para ser digitável
            cboLoja.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboLoja.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (objLstLojas != null) {
                cboLoja.DisplayMember = "DescricaoLojaCompleta";
                cboLoja.ValueMember = "loj_codigo_IN";
                cboLoja.DataSource = objLstLojas;

                // Definir o valor padrão, por exemplo, o código da loja 1
                cboLoja.SelectedValue = 40;
            } else {
                cboLoja.DataSource = null;
            }
        }

        private void carregaComboFamilia() {
            objLstFamilia = RetornaFamiliaVendasOnline();

            cboFamilia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboFamilia.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (objLstFamilia != null) {
                cboFamilia.DisplayMember = "fam_descricao";
                cboFamilia.ValueMember = "pro_familia";
                cboFamilia.DataSource = objLstFamilia;
                cboFamilia.SelectedIndex = -1;
            } else {
                cboFamilia.DataSource = null;
            }
        }

        private void carregaComboGrupo() {
            int familiaSelecionada = cboFamilia.SelectedValue != null ? Convert.ToInt32(cboFamilia.SelectedValue) : 0;

            objLstGrupo = RetornaGrupoVendasOnline(familiaSelecionada);

            cboGrupo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboGrupo.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (objLstGrupo != null) {
                cboGrupo.DisplayMember = "gru_descricao";
                cboGrupo.ValueMember = "pro_grupo";
                cboGrupo.DataSource = objLstGrupo;
                cboGrupo.SelectedIndex = -1;
            } else {
                cboGrupo.DataSource = null;
            }
        }

        private void carregaComboSubGrupo() {
            int familiaSelecionada = cboFamilia.SelectedValue != null ? Convert.ToInt32(cboFamilia.SelectedValue) : 0;
            int grupoSelecionado = cboGrupo.SelectedValue != null ? Convert.ToInt32(cboGrupo.SelectedValue) : 0;

            objLstSubGrupo = RetornaSubGrupoVendasOnline(familiaSelecionada, grupoSelecionado);

            cboSubGrupo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSubGrupo.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (objLstSubGrupo != null) {
                cboSubGrupo.DisplayMember = "sub_descricao";
                cboSubGrupo.ValueMember = "sub_codigo";
                cboSubGrupo.DataSource = objLstSubGrupo;
                cboSubGrupo.SelectedIndex = -1;
            } else {
                cboSubGrupo.DataSource = null;
            }
        }

        private void carregaComboTemp() {
            int familiaSelecionada = 0;
            int.TryParse(cboFamilia.SelectedValue?.ToString(), out familiaSelecionada);

            int grupoSelecionado = 0;
            int.TryParse(cboGrupo.SelectedValue?.ToString(), out grupoSelecionado);

            int subgrupoSelelcionado = 0;
            int.TryParse(cboSubGrupo.SelectedValue?.ToString(), out subgrupoSelelcionado);

            objLstTemp = RetornaTempVendasOnline(familiaSelecionada, grupoSelecionado, subgrupoSelelcionado);

            cboTemp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTemp.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (objLstSubGrupo != null) {
                cboTemp.DisplayMember = "tem_descricao_VC";
                cboTemp.ValueMember = "tem_codigo_IN";
                cboTemp.DataSource = objLstTemp;
                cboTemp.SelectedIndex = -1;
            } else {
                cboTemp.DataSource = null;
            }
        }

        private void carregarMkupPadrao() {
            DataSet ds = null;
            string valor = null;

            int? lojaSelecionada = cboMkupPadraoLoja.SelectedValue != null ? (int?)cboMkupPadraoLoja.SelectedValue : null;

            if (lojaSelecionada.HasValue) {
                ds = lojasVendasOnlineNegocio.ConsultarMargemPadraoVendasonline(lojaSelecionada.Value);
                valor = ds.Tables[0].Rows[0]["loj_margemdelucropadrao_MN"].ToString();
            }

            if (decimal.TryParse(valor, out decimal resultado)) {
                lblMkupPadrao.Text = resultado.ToString("0.##") + "%";
            } else {
                lblMkupPadrao.Text = "0";
            }
        }

        private void carregarComboLojasMkupPadrao() {
            objLstLojas = RetornaLojasVendasOnline();

            if (objLstLojas != null) {
                cboMkupPadraoLoja.DisplayMember = "DescricaoLojaCompleta";
                cboMkupPadraoLoja.ValueMember = "loj_codigo_IN";
                cboMkupPadraoLoja.DataSource = objLstLojas;
                cboMkupPadraoLoja.SelectedValue = 40;
            } else {
                cboMkupPadraoLoja.DataSource = null;
            }
        }

        public void carregarComboMotivosMkupPreco() {
            objLstMotivos = RetornaMotivosMkupPreco();

            cboMotivos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMotivos.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (objLstMotivos != null) {
                cboMotivos.DisplayMember = "mmp_motivo_VC";
                cboMotivos.ValueMember = "mmp_codigo_IN";
                cboMotivos.DataSource = objLstMotivos;
                cboMotivos.SelectedIndex = -1;
            } else {
                cboMotivos.DataSource = null;
            }
        }

        private List<Empresa> RetornaEmpresasVendasOnline() {
            DataSet ds = null;
            var empresas = new List<Empresa>();

            try {
                ds = empresasVendasOnlineNegocio.ConsultarEmpresasVendasOnline();
                empresas = ds.Tables[0].ToList<Empresa>();
                return empresas;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna empresas vazio em caso de falha
                return empresas;
            }
        }

        private List<LojaOnline> RetornaLojasVendasOnline() {
            DataSet ds = null;
            var lojas = new List<LojaOnline>();

            try {
                ds = lojasVendasOnlineNegocio.ConsultarLojasVendasOnline();
                lojas = ds.Tables[0].ToList<LojaOnline>();
                return lojas;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna lojas vazio em caso de falha
                return lojas;
            }
        }

        private List<Familia> RetornaFamiliaVendasOnline() {
            DataSet ds = null;
            var familia = new List<Familia>();

            try {
                ds = familiaVendasOnlineNegocio.ConsultarFamiliaVendasOnline();
                familia = ds.Tables[0].ToList<Familia>();
                return familia;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna familia vazio em caso de falha
                return familia;
            }
        }

        private List<Grupo> RetornaGrupoVendasOnline(int familia) {
            DataSet ds = null;
            var grupo = new List<Grupo>();

            try {
                ds = grupoVendasOnlineNegocio.ConsultarGrupoVendasOnline(familia);
                grupo = ds.Tables[0].ToList<Grupo>();
                return grupo;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna grupo vazio em caso de falha
                return grupo;
            }
        }


        private List<SubGrupo> RetornaSubGrupoVendasOnline(int familia, int grupo) {
            DataSet ds = null;
            var subgrupo = new List<SubGrupo>();

            try {
                // Consulta os dados do banco
                ds = subgrupoVendasOnlineNegocio.ConsultarSubGrupoVendasOnline(familia, grupo);

                // Valida se o DataSet contém tabelas e linhas
                if (ds?.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                    subgrupo = ds.Tables[0].AsEnumerable()
                                           .Select(row => new SubGrupo {
                                               // Usa conversões seguras para evitar erros de tipo ou valores nulos
                                               sub_codigo = row["sub_codigo"] != DBNull.Value
                                                            ? Convert.ToInt32(row["sub_codigo"])
                                                            : (int?)null,
                                               sub_descricao = row["sub_descricao"] != DBNull.Value
                                                               ? row["sub_descricao"].ToString()
                                                               : null
                                           }).ToList();
                } else {
                    Console.WriteLine("Nenhum dado encontrado.");
                }
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna subgrupo vazio em caso de falha
                return subgrupo;
            }

            return subgrupo;
        }

        private List<Temp> RetornaTempVendasOnline(int familia, int grupo, int subgrupo) {
            DataSet ds = null;
            var temp = new List<Temp>();

            try {
                ds = subgrupoVendasOnlineNegocio.ConsultarTempVendasOnline(familia, grupo, subgrupo);
                temp = ds.Tables[0].ToList<Temp>();
                return temp;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna temp vazio em caso de falha
                return temp;
            }
        }

        private ProdutoDesativar RetornaProdutoParaDesativar(int? produto) {
            DataSet ds = null;

            try {
                ds = produtosDesativarNegocio.ConsultarProdutoDesativar(produto);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                    var codigo_IN = ds.Tables[0].ToList<ProdutoDesativar>();
                    return codigo_IN.FirstOrDefault();
                }
                return null;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna temp vazio em caso de falha
                return null;
            }
        }

        private ProdutoDesativar RetornaProdutoParaDesativarGrade(int? produto) {
            DataSet ds = null;

            try {
                ds = produtosDesativarNegocio.ConsultarProdutoDesativarGrade(produto);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                    var codigo_IN = ds.Tables[0].ToList<ProdutoDesativar>();
                    return codigo_IN.FirstOrDefault();
                }
                return null;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna temp vazio em caso de falha
                return null;
            }
        }

        private List<MotivoMkup> RetornaMotivosMkupPreco() {
            DataSet ds = null;
            var lojas = new List<MotivoMkup>();

            try {
                ds = lojasVendasOnlineNegocio.ConsultarMotivosMkupPreco();
                lojas = ds.Tables[0].ToList<MotivoMkup>();
                return lojas;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna temp vazio em caso de falha
                return null;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            ValidaCampos();

            if (chkGrade.Checked == true) {
                CarregarGridProdutosGrade();
            } else {
                CarregarGridProdutos();
            }

            foreach (DataGridViewColumn col in dgvProdutos.Columns) {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void ValidaCampos() {
            int mkupDe, mkupAte;
            if (int.TryParse(txtMkupDe.Text, out mkupDe) && int.TryParse(txtMkupAte.Text, out mkupAte)) {
                if (mkupDe > mkupAte) {

                    MessageBox.Show("O valor 'Mkup De' não pode ser maior que 'Mkup Até'.");
                }
            }

            DateTime dataDe, dataAte;
            if (DateTime.TryParse(dtpDataVigenciaDe.Text, out dataDe) && DateTime.TryParse(dtpDataVigenciaAte.Text, out dataAte)) {
                if (dataDe > dataAte) {
                    MessageBox.Show("A data 'De' não pode ser maior que a data 'Até'.");
                }
            }
        }

        private void CarregarGridProdutos() {
            Cursor = Cursors.WaitCursor;
            try {
                DadosServices dadosServices = new DadosServices();

                // Carrega um objeto de filtros em vez de uma lista
                var filtros = CarregarFiltros();
                dataSetDadosFiltro = dadosServices.carregaObjetoFiltro(filtros);

                List<DadosGrid> objLstDadosGrid = new List<DadosGrid>();

                // Converte o DataSet para uma lista de DadosGrid
                objLstDadosGrid = dataSetDadosFiltro.Tables[0].ToList<DadosGrid>();

                // Formata e carrega o grid se houver dados
                UtilGeral.carregaGrid(dgvProdutos, ref objLstDadosGrid);

                // Atualiza a contagem de itens
                AtualizarQuantidadeItens();
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
        }

        private void CarregarGridProdutosGrade() {
            Cursor = Cursors.WaitCursor;
            try {
                DadosServices dadosServices = new DadosServices();

                // Carrega um objeto de filtros em vez de uma lista
                var filtros = CarregarFiltros();
                dataSetDadosFiltro = dadosServices.carregaObjetoFiltroGrade(filtros);

                List<DadosGrid> objLstDadosGrid = new List<DadosGrid>();

                // Converte o DataSet para uma lista de DadosGrid
                objLstDadosGrid = dataSetDadosFiltro.Tables[0].ToList<DadosGrid>();

                // Formata e carrega o grid se houver dados
                UtilGeral.carregaGrid(dgvProdutos, ref objLstDadosGrid);

                // Atualiza a contagem de itens
                AtualizarQuantidadeItens();
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
        }

        private void CarregarGridLogAlteracoes() {
            try {
                DadosLog dadosLog = new DadosLog();
                DadosLogServices dadosLogServices = new DadosLogServices();

                if (dgvProdutos.SelectedRows.Count > 0) {
                    // Seleciona o item selecionado no DataGridView
                    objDadosGridSel = dgvProdutos.SelectedRows[0].DataBoundItem as DadosGrid;

                    if (objDadosGridSel != null) {
                        if (chkGrade.Checked == true) {
                            // Define o produto a ser utilizado no log - Grade
                            dadosLog.ppp_produto_IN = objDadosGridSel.pro_codigo;

                            // Carrega os dados do log para o produto - Grade
                            dataSetDadosLogProdutos = dadosLogServices.carregaObjetoLogProdutosGrade(dadosLog);
                        } else {
                            // Define o produto a ser utilizado no log - Produto Unitário
                            dadosLog.ppp_produto_IN = objDadosGridSel.pro_produto;

                            // Carrega os dados do log para o produto - Unitário
                            dataSetDadosLogProdutos = dadosLogServices.carregaObjetoLogProdutos(dadosLog);
                        }




                        // Converte os dados do DataSet em uma lista de DadosLog
                        objLstDadosLog = dataSetDadosLogProdutos.Tables[0].ToList<DadosLog>();

                        // Formata e carrega os dados no DataGridView de logs
                        UtilGeral.formataPadrao_Grid(dgvLogAlteracoes);
                        UtilGeral.carregaGrid(dgvLogAlteracoes, ref objLstDadosLog);
                    }
                }
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlterarPrecoProduto(DadosAlteracao dadosAlteracao) {
            try {
                DadosAlteracaoServices dadosServices = new DadosAlteracaoServices();
                var result = dadosServices.carregaObjetosAlteracao(dadosAlteracao);
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ProdutosGrade> CarregarProdutosGrade(int codigoGrade, int loja) {
            DataSet ds = null;
            var produtos = new List<ProdutosGrade>();

            try {
                ds = produtosGraeNegocio.RetornarProdutosGrade(codigoGrade, loja);
                produtos = ds.Tables[0].ToList<ProdutosGrade>();
                return produtos;
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna temp vazio em caso de falha
                return produtos;
            }
        }

        private void CarregarDadosAlteracao() {
            try {
                DadosAlteracao dadosAlteracao = new DadosAlteracao();

                double? PrecoFixo = !string.IsNullOrEmpty(txtPrecoFixo.Text) ? Convert.ToDouble(txtPrecoFixo.Text) : (double?)null;
                double? MkUpPromocional = !string.IsNullOrEmpty(txtMargemLucro.Text) ? Convert.ToDouble(txtMargemLucro.Text) : (double?)null;
                string Motivo = string.IsNullOrEmpty(cboMotivos.Text.ToString()) ? null : cboMotivos.Text.ToString();

                DateTime? DataValidade = null;
                if (!string.IsNullOrEmpty(dtpDataVigencia.Text)) {
                    DateTime parsedDate;
                    if (DateTime.TryParse(dtpDataVigencia.Text, out parsedDate)) {
                        DataValidade = parsedDate;
                    }
                }

                DadosMkupPrecoProduto(PrecoFixo, MkUpPromocional, Motivo, DataValidade);
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DadosMkupPrecoProduto(double? PrecoFixo, double? MkupPromocional, string Motivo, DateTime? DataValidade) {
            bool sucesso = false;

            if (chkGrade.Checked == true) {
                AlterarProdutoGrade(PrecoFixo, MkupPromocional, Motivo, DataValidade, sucesso);
            } else {
                AlterarProdutoUnitario(PrecoFixo, MkupPromocional, Motivo, DataValidade, sucesso);
            }

        }

        private void AlterarProdutoGrade(double? PrecoFixo, double? MkupPromocional, string Motivo, DateTime? DataValidade, bool sucesso) {
            int countSelecionados;
            int qtdeProdutos;
            int codGrade;
            string tipoAlteracao;

            tipoAlteracao = txtMargemLucro.Text != "" ? "Mkup" : "Preço";

            //Pego o valor da grade 
            codGrade = objLstDadosGrid.Where(x => x.sel == true && x.Codigo_Grade > 0).Select(x => x.Codigo_Grade ?? 0).FirstOrDefault();

            //Pego a loja da grade
            int lojaGrade = objLstDadosGrid.Where(x => x.sel == true && x.Codigo_Grade > 0).Select(x => x.loj_codigo_IN ?? 0).FirstOrDefault();

            //Vejo quantos objetos estão selecionados 
            countSelecionados = objLstDadosGrid.Where(x => x.sel == true && x.Codigo_Grade > 0).Count();

            // Obtém os produtos da grade
            var produtosDaGrade = CarregarProdutosGrade(codGrade, lojaGrade);
            qtdeProdutos = produtosDaGrade.Count();

            //Verifica se a quatidade de itens selecionadas é a mesma quantidade de itens da grade
            if (countSelecionados == qtdeProdutos) {
                DialogResult resultProdutosGrade = MessageBox.Show("Deseja realmente alterar o " + tipoAlteracao + " do agrupador " + codGrade + " e seus " + qtdeProdutos + " produtos?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultProdutosGrade == DialogResult.Yes) {
                    foreach (var item in objLstDadosGrid.Where(x => x.sel == true).ToList()) {
                        try {
                            int codigoGrade = item.Codigo_Grade ?? 0;
                            int loja = item.loj_codigo_IN ?? 0;


                            foreach (var produto in produtosDaGrade) {
                                DadosAlteracao dadosAlteracao = new DadosAlteracao {
                                    Loja_IN = produto.loj_loja_IN,
                                    Produto_IN = produto.pgr_produto_IN,
                                    PrecoFixo = PrecoFixo,
                                    MkUpPromocional = MkupPromocional,
                                    DataValidade = DataValidade,
                                    Motivo = Motivo
                                };

                                try {
                                    // Aplica as alterações para cada produto da grade
                                    AlterarPrecoProduto(dadosAlteracao);
                                    sucesso = true;
                                } catch (Exception ex) {
                                    // Trata erros e exibe mensagem para o usuário
                                    tratarErros tratarErros = new tratarErros();
                                    string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                                    MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        } catch (Exception ex) {
                            // Trata erros e exibe mensagem para o usuário
                            tratarErros tratarErros = new tratarErros();
                            string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                            MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                } else {
                    LimparFiltros();
                    return;
                }
            } else //Entra aqui caso o usuário não selecionar todos os produtos do agrupador 
              {
                MessageBox.Show("Selecione todos os produtos do agrupador para realizar a alteração.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimparFiltros();
                return;
            }

            if (sucesso) {
                MessageBox.Show("Produto(s) atualizado(s) com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparFiltros();
                CarregarGridLogAlteracoes();

                foreach (DataGridViewRow row in dgvProdutos.Rows) {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["campo_selecao"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null) {
                        checkBoxCell.Value = false;
                    }
                }
            } else {
                MessageBox.Show("Nenhuma alteração foi realizada. Verifique os dados informados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dtpDataVigencia.Value = DateTime.Now;
                dtpDataVigencia.CustomFormat = " ";
                txtMargemLucro.Text = "";
                txtPrecoFixo.Text = "";

                foreach (DataGridViewRow row in dgvProdutos.Rows) {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["campo_selecao"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null) {
                        checkBoxCell.Value = false;
                    }
                }
            }
        }

        private void AlterarProdutoUnitario(double? PrecoFixo, double? MkupPromocional, string Motivo, DateTime? DataValidade, bool sucesso) {
            string tipoAlteracao;

            tipoAlteracao = txtMargemLucro.Text != "" ? "Mkup" : "Preço";

            int count = objLstDadosGrid.Where(x => x.sel == true).Count();
            DialogResult result2 = MessageBox.Show("Deseja realmente alterar o " + tipoAlteracao + " do(s) produto(s) selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            foreach (var item in objLstDadosGrid.Where(x => x.sel == true).ToList()) {
                if (result2 == DialogResult.Yes) {
                    try {
                        DadosAlteracao dadosAlteracao = new DadosAlteracao {
                            Loja_IN = item.loj_codigo_IN,
                            Produto_IN = item.pro_produto,
                            PrecoFixo = PrecoFixo,
                            MkUpPromocional = MkupPromocional,
                            DataValidade = DataValidade,
                            Motivo = Motivo
                        };

                        AlterarPrecoProduto(dadosAlteracao);
                        sucesso = true;
                    } catch (Exception ex) {
                        // Trata erros e exibe mensagem para o usuário
                        tratarErros tratarErros = new tratarErros();
                        string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);
                        MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    LimparFiltros();
                    return;
                }
            }

            if (sucesso) {
                MessageBox.Show("Produto(s) atualizado(s) com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparFiltros();
                CarregarGridLogAlteracoes();

                foreach (DataGridViewRow row in dgvProdutos.Rows) {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["campo_selecao"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null) {
                        checkBoxCell.Value = false;
                    }
                }
            } else {
                MessageBox.Show("Nenhuma alteração foi realizada. Verifique os dados informados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dtpDataVigencia.Value = DateTime.Now;
                dtpDataVigencia.CustomFormat = " ";
                txtMargemLucro.Text = "";
                txtPrecoFixo.Text = "";

                foreach (DataGridViewRow row in dgvProdutos.Rows) {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["campo_selecao"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null) {
                        checkBoxCell.Value = false;
                    }
                }
            }
        }

        private void GravarNovoMkupPadraoLoja() {
            try {
                MkupLoja dadosAlteracao = new MkupLoja();
                MkupPadraoServices mkuppadrao = new MkupPadraoServices();

                dadosAlteracao.loj_codigo_IN = string.IsNullOrEmpty(cboMkupPadraoLoja.SelectedValue?.ToString()) ? (int?)null : Convert.ToInt32(cboMkupPadraoLoja.SelectedValue);
                dadosAlteracao.loj_margemdelucropadrao_MN = !string.IsNullOrEmpty(txtMkupPadrao.Text) ? Convert.ToDouble(txtMkupPadrao.Text) : (double?)null;

                dataSetAlteracoMkupPadrao = mkuppadrao.gravarMkupPadraLoja(dadosAlteracao);
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarProdutosParaDesativarMkup() {
            if (chkGrade.Checked == true) {
                DesativarMkupPrecoProdutoGrade();
            } else {
                DesativarMkupPrecoUnitario();
            }

        }

        private void DesativarMkupPrecoProdutoGrade() {
            try {
                DadosAlteracao dadosAlteracao = new DadosAlteracao();
                DesativarProdutosServices dadosServices = new DesativarProdutosServices();

                //Pego o valor da grade 
                int codGrade = objLstDadosGrid
                            .Where(x => x.sel == true && x.Codigo_Grade > 0)
                            .Select(x => x.Codigo_Grade ?? 0)
                            .FirstOrDefault();

                //Pego a loja da grade
                int lojaGrade = objLstDadosGrid
                            .Where(x => x.sel == true && x.Codigo_Grade > 0)
                            .Select(x => x.loj_codigo_IN ?? 0)
                            .FirstOrDefault();

                //Vejo quantos objetos estão selecionados 
                int countSelecionados = objLstDadosGrid
                    .Where(x => x.sel == true && x.Codigo_Grade > 0)
                    .Count();


                //Traz a lista de produtos da grade através do código da grade e da loja
                var produtosDaGrade = CarregarProdutosGrade(codGrade, lojaGrade);

                //Quantidade de produtos da grade 
                int count = produtosDaGrade.Count();

                //Valido se a grade toda está marcada para ser alterada
                if (countSelecionados == count) {
                    DialogResult resultGrade = MessageBox.Show("Deseja realmente desativar o Preço ou Mkup do agrupador " + codGrade + " e seus " + count + " produtos selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultGrade == DialogResult.Yes) {
                        foreach (var item in objLstDadosGrid.Where(x => x.sel == true).ToList()) //Verfica os itens selecionados
                        {
                            try {
                                int codigoGrade = item.Codigo_Grade ?? 0;
                                int loja = item.loj_codigo_IN ?? 0;

                                foreach (var produto in produtosDaGrade) {
                                    try {
                                        dadosAlteracao = new DadosAlteracao();
                                        dadosAlteracao.Produto_IN = produto.pgr_produto_IN;

                                        //Retorna os produtos que serão desativados na tabela VendasONline_ProdutoPrecoEMkBPromocional_T
                                        var codigo_IN = RetornaProdutoParaDesativarGrade(dadosAlteracao.Produto_IN);

                                        if (codigo_IN == null) {
                                            MessageBox.Show("Produto já está com Mkup B.% ou preço fixo desativado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            DesmarcarGrid();
                                            return;
                                        }

                                        // Aplica a desativação para cada produto da grade
                                        var retOutPutGrade = dadosServices.desativaMkupProdutoGrade(codigo_IN);
                                    } catch (Exception ex) {
                                        // Trata erros e exibe mensagem para o usuário
                                        tratarErros tratarErros = new tratarErros();
                                        string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                                        MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                MessageBox.Show("Produto desativado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparFiltros();
                                return;
                            } catch (Exception ex) {
                                // Trata erros e exibe mensagem para o usuário
                                tratarErros tratarErros = new tratarErros();
                                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    } else {
                        return;
                    }
                } else {
                    MessageBox.Show("Selecione todos os produtos do agrupador para realizar a alteração.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CarregarDadosBanco();
                    DesmarcarGrid();
                    return;
                }

            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesativarMkupPrecoUnitario() {
            foreach (var item in objLstDadosGrid.Where(x => x.sel == true).ToList()) //Verfica os itens selecionados
            {
                try {
                    DadosAlteracao dadosAlteracao = new DadosAlteracao();
                    DesativarProdutosServices dadosServices = new DesativarProdutosServices();

                    dadosAlteracao = new DadosAlteracao();
                    dadosAlteracao.Produto_IN = item.pro_produto;

                    DialogResult resultUnitario = MessageBox.Show("Deseja realmente desativar o Preço ou Mkup do(s) produto(s) selecionado(s)?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultUnitario == DialogResult.Yes) {
                        var codigo_IN = RetornaProdutoParaDesativar(dadosAlteracao.Produto_IN); //Retorna os códigos dos produtos para serem desativados na tabela de VendasONline_ProdutoPrecoEMkBPromocional_T

                        if (codigo_IN == null) {
                            MessageBox.Show("Produto já está com Mkup B.% ou preço desativado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DesmarcarGrid();
                            return;
                        }

                        var retOutPut = dadosServices.desativaMkupProduto(codigo_IN); //Desativa o produto unitário na tabela VendasONline_ProdutoPrecoEMkBPromocional_T

                        foreach (var item2 in retOutPut) {
                            if (item2.Key == "@_PAR_RetOutput" && item2.Value.ToString() == "1") {
                                MessageBox.Show("Preço ou Mkup do produto desativado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            } else {
                                MessageBox.Show("Preço ou Mkup do produto não desativado, verifique os dados digitados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                } catch (Exception ex) {
                    // Trata erros e exibe mensagem para o usuário
                    tratarErros tratarErros = new tratarErros();
                    string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                    MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AtualizarQuantidadeItens() {
            int quantidade = dgvProdutos.RowCount;
            lblTotalEncontrado.Text = quantidade.ToString();
        }

        private void btnFechar_Click(object sender, EventArgs e) {
            SalvarOrdemColunas();
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e) {
            Size tamanhoAtual = this.Size;

            if (tamanhoAtual != tamanhoOriginal) {
                this.Size = tamanhoOriginal;
                return;
            }

            UtilGeral.Maximizar(this);
        }

        private void btnSair_Click(object sender, EventArgs e) {
            SalvarOrdemColunas();
            this.Close();
        }

        //Carrega as informações preenchidas dos filtros
        private Filtros CarregarFiltros() {
            DateTime? VigenciaDe_DT = null;
            if (!string.IsNullOrEmpty(dtpDataVigenciaDe.Text)) {
                DateTime vigenciaDe;
                if (DateTime.TryParse(dtpDataVigenciaDe.Text, out vigenciaDe)) {
                    VigenciaDe_DT = vigenciaDe;
                }
            }

            DateTime? VigenciaAte_DT = null;
            if (!string.IsNullOrEmpty(dtpDataVigenciaAte.Text)) {
                DateTime vigenciaAte;
                if (DateTime.TryParse(dtpDataVigenciaAte.Text, out vigenciaAte)) {
                    VigenciaAte_DT = vigenciaAte;
                }
            }
            return new Filtros {
                //Filtros ComboBox
                Empresa_IN = string.IsNullOrEmpty(cboEmpresa.SelectedValue?.ToString()) ? (int?)null : Convert.ToInt32(cboEmpresa.SelectedValue),
                Loja_IN = string.IsNullOrEmpty(cboLoja.SelectedValue?.ToString()) ? (int?)null : Convert.ToInt32(cboLoja.SelectedValue),
                Familia_IN = string.IsNullOrEmpty(cboFamilia.SelectedValue?.ToString()) ? (int?)null : Convert.ToInt32(cboFamilia.SelectedValue),
                Grupo_IN = string.IsNullOrEmpty(cboGrupo.SelectedValue?.ToString()) ? (int?)null : Convert.ToInt32(cboGrupo.SelectedValue),
                SubGrupo_IN = string.IsNullOrEmpty(cboSubGrupo.SelectedValue?.ToString()) ? (int?)null : Convert.ToInt32(cboSubGrupo.SelectedValue),
                Temp_IN = string.IsNullOrEmpty(cboTemp.SelectedValue?.ToString()) ? (int?)null : Convert.ToInt32(cboTemp.SelectedValue),

                //Filtros CheckBox
                Tipo_IN = (chkPrecoFixo.Checked && chkMkp.Checked) ? 3 : (chkPrecoFixo.Checked ? 1 : (chkMkp.Checked ? 2 : (int?)null)),
                VigenciaDe_DT = VigenciaDe_DT,
                VigenciaAte_DT = VigenciaAte_DT,
                MkupDe = string.IsNullOrEmpty(txtMkupDe.Text.ToString()) ? null : txtMkupDe.Text.ToString(),
                MkupAte = string.IsNullOrEmpty(txtMkupAte.Text.ToString()) ? null : txtMkupAte.Text.ToString(),

                //Filtos TextBox
                Produto_IN = string.IsNullOrEmpty(txtCodProduto.Text) ? (int?)null : Convert.ToInt32(txtCodProduto.Text),
                CA_VC = string.IsNullOrEmpty(txtCA.Text.ToString()) ? null : txtCA.Text.ToString(),
                Descricao_VC = string.IsNullOrEmpty(txtDescricao.Text.ToString()) ? null : txtDescricao.Text.ToString(),
                Agrupador_VC = string.IsNullOrEmpty(txtAgrupador.Text.ToString()) ? null : txtAgrupador.Text.ToString(),
                Marca_VC = string.IsNullOrEmpty(txtMarca.Text.ToString()) ? null : txtMarca.Text.ToString(),
                Fornecedor_VC = string.IsNullOrEmpty(txtFornecedor.Text.ToString()) ? null : txtFornecedor.Text.ToString(),
                Referencia_VC = string.IsNullOrEmpty(txtRef.Text.ToString()) ? null : txtRef.Text.ToString(),
                Codigo_Grade = string.IsNullOrEmpty(txtCodAgrupador.Text) ? (int?)null : Convert.ToInt32(txtCodAgrupador.Text),
            };
        }

        //Limpar todos os filtros 
        private void LimparFiltros() {
            txtCodProduto.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtFornecedor.Text = string.Empty;
            txtRef.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtCodAgrupador.Text = string.Empty;
            txtCA.Text = string.Empty;
            txtMargemLucro.Text = string.Empty;
            txtMkupDe.Text = string.Empty;
            txtMkupAte.Text = string.Empty;
            txtAgrupador.Text = string.Empty;
            txtPrecoFixo.Text = string.Empty;

            dtpDataVigenciaDe.Format = DateTimePickerFormat.Custom;
            dtpDataVigenciaDe.CustomFormat = " ";

            dtpDataVigenciaAte.Format = DateTimePickerFormat.Custom;
            dtpDataVigenciaAte.CustomFormat = " ";

            dtpDataVigencia.Format = DateTimePickerFormat.Custom;
            dtpDataVigencia.CustomFormat = " ";

            chkDesativarMkupPromo.Checked = false;
            chkPrecoFixo.Checked = false;
            chkMkp.Checked = false;

            cboFamilia.SelectedIndex = -1;
            cboGrupo.SelectedIndex = -1;
            cboSubGrupo.SelectedIndex = -1;
            cboTemp.SelectedIndex = -1;
            cboMotivos.SelectedIndex = -1;
        }

        private void SalvarOrdemColunas() {
            try {
                List<int> ordemDasColunas = new List<int>();


                //CASO A PASTA NAO EXISTA ENTÃO SERA CRIADA
                if (!Directory.Exists(pastaArquivoConfig)) {
                    Directory.CreateDirectory(pastaArquivoConfig);
                }

                StreamWriter streamWriter = new StreamWriter(CaminhoArquivoConfiguracao);

                // Obter a ordem atual das colunas
                foreach (DataGridViewColumn coluna in dgvProdutos.Columns) {
                    ordemDasColunas.Add(coluna.DisplayIndex);
                }

                // Serializar e salvar em um arquivo JSON
                var json = JsonConvert.SerializeObject(ordemDasColunas);
                streamWriter.Write(json);
                streamWriter.Flush();

            } catch (Exception ex) {
                MessageBox.Show("Erro ao salvar a ordem das colunas: " + ex.Message);
            }

        }
        private void CarregarOrdemColunas() {
            try {
                // Verificar se o arquivo de configuração existe
                if (File.Exists(CaminhoArquivoConfiguracao)) {
                    // Desserializar a ordem das colunas do arquivo JSON
                    var json = File.ReadAllText(CaminhoArquivoConfiguracao);
                    List<int> ordemDasColunas = JsonConvert.DeserializeObject<List<int>>(json);

                    // Aplicar a ordem das colunas salva
                    for (int i = 0; i < ordemDasColunas.Count; i++) {
                        DataGridViewColumn coluna = dgvProdutos.Columns[i];
                        if (coluna != null) {
                            coluna.DisplayIndex = ordemDasColunas[i];
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Erro ao carregar a ordem das colunas: " + ex.Message);
            }
        }

        private void btnRestaurarColunas_Click(object sender, EventArgs e) {
            try {
                if (MessageBox.Show("Deseja realmente restaurar as colunas?" + "\n" + "\n" +
                                    "ESSA AÇÃO FECHARÁ ESTA TELA E TODAS AS ALTERAÇÕES NÃO GRAVADAS SERÃO PERDIDAS." + "\n" + "\n" +
                                      "Deseja prosseguir com o fechamento desta tela e restauração das grades?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }

                // Remova as colunas existentes para reordená-las
                dgvProdutos.Columns.Clear();

                // Obtenha a ordem padrão das colunas
                List<int> ordemPadrao = Enumerable.Range(0, dgvProdutos.Columns.Count).ToList();

                // Reordene as colunas com base na ordem padrão
                for (int i = 0; i < ordemPadrao.Count; i++) {
                    DataGridViewColumn coluna = dgvProdutos.Columns[ordemPadrao[i]];
                    coluna.DisplayIndex = i;
                }

                btnSair.PerformClick();
            } catch (Exception ex) {
                MessageBox.Show("Erro ao restaurar a ordem das colunas: " + ex.Message);
            }
        }

        public static string exportToExcel(DataGridView dataGridView, string nomeRelatorio = "") {
            XLWorkbook xLWorkbook = new XLWorkbook();
            IXLWorksheet iXLWorksheet = xLWorkbook.Worksheets.Add("Dados");
            for (int i = 0; i < dataGridView.Columns.Count; i++) {
                iXLWorksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                iXLWorksheet.Cell(1, i + 1).Style.Font.Bold = true;
            }

            for (int j = 0; j < dataGridView.Rows.Count; j++) {
                for (int k = 0; k < dataGridView.Columns.Count; k++) {
                    object valorCelula = dataGridView.Rows[j].Cells[k].Value;

                    if (valorCelula != null && !string.IsNullOrEmpty(valorCelula.ToString())) {
                        iXLWorksheet.Cell(j + 2, k + 1).Value = valorCelula;

                        if (dataGridView.Columns[k].ValueType == typeof(decimal) || dataGridView.Columns[k].ValueType == typeof(double)) {
                            iXLWorksheet.Cell(j + 2, k + 1).Style.NumberFormat.Format = "_($ #,##0.00_);_($ (#,##0.00);_($* \"-\"??_);_(@_)";
                        } else if (dataGridView.Columns[k].ValueType == typeof(DateTime)) {
                            iXLWorksheet.Cell(j + 2, k + 1).Style.NumberFormat.Format = "dd/MM/yyyy HH:mm:ss";
                        }
                    } else {

                        iXLWorksheet.Cell(j + 2, k + 1).DataType = XLDataType.Text;
                        iXLWorksheet.Cell(j + 2, k + 1).Value = null;
                    }
                }
            }

            iXLWorksheet.Rows().AdjustToContents();
            iXLWorksheet.Columns().AdjustToContents();
            string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads", "Rel_" + nomeRelatorio + ".xlsx");
            if (File.Exists(text)) {
                File.Delete(text);
            }

            xLWorkbook.SaveAs(text);
            return text;
        }

        private void cboFamilia_SelectedIndexChanged(object sender, EventArgs e) {
            carregaComboGrupo();
        }

        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e) {
            carregaComboSubGrupo();
        }

        private void cboSubGrupo_SelectedIndexChanged(object sender, EventArgs e) {
            carregaComboTemp();
        }

        private void btnLimparFiltros_Click(object sender, EventArgs e) {
            LimparFiltros();
        }

        private void btnGravar_Click(object sender, EventArgs e) {
            //Desativação do Mkup ou Preço fixo
            if (chkDesativarMkupPromo.Checked) {
                DesativarProdutos();
                CarregarDadosBanco();
                DesmarcarGrid();
                return;
            }

            //Valida todos os campos se estão preenchidos corretamente para atualização
            if (ValidarCampos()) {
                //Verifica se possui algum item selecionado no grid 
                if (VerificarItemSelecionado()) {
                    Cursor = Cursors.WaitCursor;
                    CarregarDadosAlteracao();       // Carrega os dados digitados da alteração e atualiza o produto
                    CarregarGridLogAlteracoes();    // Carrega o grid do log de alterações                   
                    DesmarcarGrid();                //Desmarca todos os itens selecionados do grid 
                    Cursor = Cursors.Default;
                    return;
                } else {
                    if (chkDesativarMkupPromo.Checked == false) {
                        MessageBox.Show("Nenhum item está marcado. Por favor, selecione pelo menos um item.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DesmarcarGrid();
                        return;
                    }
                }
            }
        }

        private void DesativarProdutos() {
            try {
                if (!string.IsNullOrEmpty(txtMargemLucro.Text) || !string.IsNullOrEmpty(txtPrecoFixo.Text)) {
                    MessageBox.Show("Você está inserindo Mkup ou Preço para uma desativação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CarregarDadosBanco();
                    DesmarcarGrid();
                    return;
                } else {
                    // Verifica se tem algum item selecionado no grid 
                    if (VerificarItemSelecionado()) {
                        Cursor = Cursors.WaitCursor;

                        try {
                            // Carrega os produtos para serem desativados na tabela 'VendasONline_ProdutoPrecoEMkBPromocional_T' e desativa os produtos
                            CarregarProdutosParaDesativarMkup();

                            // Carrega o grid de Log atualizado após a alteração
                            CarregarGridLogAlteracoes();
                        } catch (Exception ex) {
                            MessageBox.Show($"Ocorreu um erro ao desativar os produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CarregarDadosBanco();
                            return;
                        } finally {
                            Cursor = Cursors.Default;
                        }

                        // Desmarca todos os itens no DataGridView
                        foreach (DataGridViewRow row in dgvProdutos.Rows) {
                            DataGridViewCheckBoxCell checkBoxCell = row.Cells["campo_selecao"] as DataGridViewCheckBoxCell;
                            if (checkBoxCell != null) {
                                checkBoxCell.Value = false;
                            }
                        }
                        CarregarDadosBanco();
                        return;
                    } else {
                        MessageBox.Show("Nenhum item está marcado. Por favor, selecione pelo menos um item.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CarregarDadosBanco();


                        // Desmarca todos os itens no DataGridView
                        foreach (DataGridViewRow row in dgvProdutos.Rows) {
                            DataGridViewCheckBoxCell checkBoxCell = row.Cells["campo_selecao"] as DataGridViewCheckBoxCell;
                            if (checkBoxCell != null) {
                                checkBoxCell.Value = false;
                            }
                        }
                        LimparFiltros();
                        return;
                    }
                }
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Retorna um Dicionário vazio em caso de falha
                return;
            }
        }

        private bool ValidarCampos() {
            // Valida se ao menos um dos tipos de valores estão marcados 
            if (!string.IsNullOrEmpty(txtPrecoFixo.Text) && !string.IsNullOrEmpty(txtMargemLucro.Text)) {
                MessageBox.Show("Escolha somente um tipo para ser alterado (Preço Fixo ou Mkup)", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecoFixo.Focus();
                return false;
            }

            // Valida se algum dos tipos de valores estão preenchidos e se o check desativar está desmarcado
            if (string.IsNullOrEmpty(txtPrecoFixo.Text) && string.IsNullOrEmpty(txtMargemLucro.Text) && chkDesativarMkupPromo.Checked == false) {
                MessageBox.Show("Informe pelo menos um tipo para ser alterado (Preço Fixo ou Mkup)", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMargemLucro.Focus();
                return false;
            }

            // Valida se uma data foi selecionada
            if (!dtpDataVigencia.Checked) {
                MessageBox.Show("O campo de vigência é obrigatório. Por favor, preencha-o.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDataVigencia.Focus();
                return false;
            }

            // Valida se uma data foi selecionada
            if (string.IsNullOrEmpty(cboMotivos.SelectedValue?.ToString()) || cboMotivos.SelectedIndex == -1) {
                MessageBox.Show("Por favor, selecione um motivo.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMotivos.Focus();
                return false;
            }

            return true;
        }


        private bool VerificarItemSelecionado() {
            //Virifica se o grdid possui algum item selecionado
            foreach (DataGridViewRow row in dgvProdutos.Rows) {
                if (Convert.ToBoolean(row.Cells[0].Value) == true) {
                    return true;
                }
            }
            return false;
        }

        private void dgvProdutos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            CarregarGridLogAlteracoes();
        }

        private void dtpDataVigenciaDe_ValueChanged(object sender, EventArgs e) {
            // Verifica se o usuário digitou uma data válida
            if (dtpDataVigenciaDe.Checked) {
                dtpDataVigenciaDe.Format = DateTimePickerFormat.Short;
            } else {
                // Se não tiver data volta em branco
                dtpDataVigenciaDe.Format = DateTimePickerFormat.Custom;
                dtpDataVigenciaDe.CustomFormat = " ";
            }
        }

        private void dtpDataVigenciaAte_ValueChanged(object sender, EventArgs e) {
            // Verifica se o usuário selecionou uma data válida. Caso contrário, retorna o campo para "em branco".
            if (dtpDataVigenciaAte.Checked) {
                // Data selecionada, exibe no formato curto
                dtpDataVigenciaAte.Format = DateTimePickerFormat.Short;
            } else {
                // Se não tiver data (campo vazio), volta para o formato customizado e em branco
                dtpDataVigenciaAte.Format = DateTimePickerFormat.Custom;
                dtpDataVigenciaAte.CustomFormat = " ";
            }
        }

        private void dtpDataVigencia_ValueChanged(object sender, EventArgs e) {
            // Verifica se o usuário selecionou uma data válida. Caso contrário, retorna o campo para "em branco".
            if (dtpDataVigencia.Checked) {
                // Data selecionada, exibe no formato curto
                dtpDataVigencia.Format = DateTimePickerFormat.Short;
            } else {
                // Se não tiver data (campo vazio), volta para o formato customizado e em branco
                dtpDataVigencia.Format = DateTimePickerFormat.Custom;
                dtpDataVigencia.CustomFormat = " ";
            }
        }

        private void btnCadMotivo_Click(object sender, EventArgs e) {
            var frmCadastrarMotivo = new frmCadastrarMotivo();
            frmCadastrarMotivo.FormularioPai = this; // Passa a referência do formulário atual
            frmCadastrarMotivo.Show(); // Abre o form de cadastro do motivo
        }

        private void dgvProdutos_SelectionChanged(object sender, EventArgs e) {
            // Verifica se há linhas selecionadas no DataGridView
            if (dgvProdutos.SelectedRows.Count == 0) {
                return;
            }

            objDadosGridSel = dgvProdutos.SelectedRows[0].DataBoundItem as DadosGrid;

            CarregarGridLogAlteracoes(); //Carrega o grid de log das alterações 
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == dgvProdutos.Columns["campo_selecao"].Index) {
                // Obter a linha do CheckBox
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvProdutos.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Verificar se o valor não é nulo antes de mudar o estado
                if (checkBoxCell.Value == null || checkBoxCell.Value == DBNull.Value) {
                    checkBoxCell.Value = false; // Definir como falso se estiver nulo
                }

                // mudar o valor do CheckBox
                checkBoxCell.Value = !(bool)checkBoxCell.Value;

                // Se o CheckBox for marcado, selecionar a linha
                if ((bool)checkBoxCell.Value) {
                    dgvProdutos.Rows[e.RowIndex].Selected = true;
                } else {
                    dgvProdutos.Rows[e.RowIndex].Selected = false;
                }
            }
        }

        private void chkDesativarMkupPromo_CheckedChanged(object sender, EventArgs e) {
            txtMargemLucro.Text = "";
            txtPrecoFixo.Text = "";
            dtpDataVigencia.Format = DateTimePickerFormat.Custom;
            dtpDataVigencia.CustomFormat = " ";
        }

        //==================== Validação dos campos para digitar somente números ==========================

        private void txtCA_KeyPress(object sender, KeyPressEventArgs e) {
            // Validação somente números 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) {
                e.Handled = true; // Impede a inserção de outros caracteres
            }

            if (e.KeyChar == 46 && txtCA.Text.Contains(".")) {
                e.Handled = true; // Impede a inserção de mais de um ponto
            }
        }

        private void txtCodProduto_KeyPress(object sender, KeyPressEventArgs e) {
            // Validação somente números 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) {
                e.Handled = true; // Impede a inserção de outros caracteres
            }

            if (e.KeyChar == 46 && txtCodProduto.Text.Contains(".")) {
                e.Handled = true; // Impede a inserção de mais de um ponto
            }
        }

        private void txtMkupPadrao_KeyPress_1(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) {
                e.Handled = true;
            }

            if (e.KeyChar == 46 && txtMargemLucro.Text.Contains(".")) {
                e.Handled = true;
            }

            if (int.TryParse(txtCodProduto.Text, out int resultado)) {
                CarregarGridProdutos();
            }
        }

        private void txtPrecoFixo_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) {
                e.Handled = true;
            }

            if (e.KeyChar == 46 && txtPrecoFixo.Text.Contains(".")) {
                e.Handled = true;
            }
        }

        private void txtMkupDe_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) {
                e.Handled = true;
            }

            if (e.KeyChar == 46 && txtMkupDe.Text.Contains(".")) {
                e.Handled = true;
            }

            if (int.TryParse(txtMkupDe.Text, out int resultado)) {
                CarregarGridProdutos();
            }
        }

        private void txtMkupAte_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) {
                e.Handled = true;
            }

            if (e.KeyChar == 46 && txtMkupAte.Text.Contains(".")) {
                e.Handled = true;
            }

            if (int.TryParse(txtMkupAte.Text, out int resultado)) {
                CarregarGridProdutos();
            }
        }
        private void txtCodAgrupador_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) {
                e.Handled = true;
            }

            if (e.KeyChar == 46 && txtPrecoFixo.Text.Contains(".")) {
                e.Handled = true;
            }
        }

        private void txtMargemLucro_KeyPress(object sender, KeyPressEventArgs e) {
            // Permite dígitos, Backspace (8) e vírgula (44)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',') {
                e.Handled = true;
                return;
            }

            // Permite apenas uma vírgula
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == ',' && textBox.Text.Contains(",")) {
                e.Handled = true;
                return;
            }

            // Evita vírgula como primeiro caractere
            if (e.KeyChar == ',' && string.IsNullOrEmpty(textBox.Text)) {
                e.Handled = true;
                return;
            }
        }

        private void txtPrecoFixo_KeyPress_1(object sender, KeyPressEventArgs e) {
            // Permite dígitos, Backspace (8) e vírgula (44)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',') {
                e.Handled = true;
                return;
            }

            // Permite apenas uma vírgula
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == ',' && textBox.Text.Contains(",")) {
                e.Handled = true;
                return;
            }

            // Evita vírgula como primeiro caractere
            if (e.KeyChar == ',' && string.IsNullOrEmpty(textBox.Text)) {
                e.Handled = true;
                return;
            }
        }

        //Busca ao digitar os caracteres no textbox, retorna com todos os registros ao ir apagando
        private void txtDescricao_TextChanged(object sender, EventArgs e) {
            string filtro = txtDescricao.Text.ToLower();

            var listaFiltrada = objLstDadosGrid
            .Where(item => (item.pro_descricao ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<DadosGrid>(dgvProdutos, ref listaFiltrada);

            lblTotalEncontrado.Text = listaFiltrada.Count.ToString();
        }

        private void txtFornecedor_TextChanged(object sender, EventArgs e) {
            string filtro = txtFornecedor.Text.ToLower();

            var listaFiltrada = objLstDadosGrid
            .Where(item => (item.for_razao ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<DadosGrid>(dgvProdutos, ref listaFiltrada);

            lblTotalEncontrado.Text = listaFiltrada.Count.ToString();
        }

        private void txtCodProduto_TextChanged(object sender, EventArgs e) {
            string filtro = txtCodProduto.Text.ToLower();

            var listaFiltrada = objLstDadosGrid
            .Where(item => (item.pro_produto.ToString() ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<DadosGrid>(dgvProdutos, ref listaFiltrada);

            lblTotalEncontrado.Text = listaFiltrada.Count.ToString();
        }

        private void txtCA_TextChanged(object sender, EventArgs e) {
            string filtro = txtCA.Text.ToLower();

            var listaFiltrada = objLstDadosGrid
            .Where(item => (item.Num_CA.ToString() ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<DadosGrid>(dgvProdutos, ref listaFiltrada);

            lblTotalEncontrado.Text = listaFiltrada.Count.ToString();
        }

        private void txtCodAgrupador_TextChanged(object sender, EventArgs e) {
            string filtro = txtCodAgrupador.Text.ToLower();

            var listaFiltrada = objLstDadosGrid
            .Where(item => (item.Codigo_Grade.ToString() ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<DadosGrid>(dgvProdutos, ref listaFiltrada);

            lblTotalEncontrado.Text = listaFiltrada.Count.ToString();
        }

        private void txtAgrupador_TextChanged(object sender, EventArgs e) {
            string filtro = txtAgrupador.Text.ToLower();

            var listaFiltrada = objLstDadosGrid
            .Where(item => (item.Descricao_Grade.ToString() ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<DadosGrid>(dgvProdutos, ref listaFiltrada);

            lblTotalEncontrado.Text = listaFiltrada.Count.ToString();
        }

        private void txtMarca_TextChanged(object sender, EventArgs e) {
            string filtro = txtMarca.Text.ToLower();

            var listaFiltrada = objLstDadosGrid
            .Where(item => (item.pro_marca_VC.ToString() ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<DadosGrid>(dgvProdutos, ref listaFiltrada);

            lblTotalEncontrado.Text = listaFiltrada.Count.ToString();
        }

        private void txtRef_TextChanged(object sender, EventArgs e) {
            string filtro = txtRef.Text.ToLower();

            var listaFiltrada = objLstDadosGrid
            .Where(item => (item.pro_referencia_VC.ToString() ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<DadosGrid>(dgvProdutos, ref listaFiltrada);

            lblTotalEncontrado.Text = listaFiltrada.Count.ToString();
        }

        private void btnGerarExcel_Click_1(object sender, EventArgs e) {
            exportToExcel(dgvProdutos, "Relatorio Produtos Vendas Online " + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss"));
            MessageBox.Show("Exportado para pasta Downloads", "Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtMkupPadrao_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) {
                e.Handled = true;
            }

            if (e.KeyChar == 46 && txtMkupPadrao.Text.Contains(".")) {
                e.Handled = true;
            }
        }

        private void txtMkupDe_KeyPress_1(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) {
                e.Handled = true;
            }

            if (e.KeyChar == 46 && txtMkupDe.Text.Contains(".")) {
                e.Handled = true;
            }
        }

        private void txtMkupAte_KeyPress_1(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) {
                e.Handled = true;
            }

            if (e.KeyChar == 46 && txtMkupAte.Text.Contains(".")) {
                e.Handled = true;
            }
        }

        private void cboMkupPadraoLoja_SelectedIndexChanged_1(object sender, EventArgs e) {
            carregarMkupPadrao();
        }

        private void btnGravarMkupPadrao_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(cboMkupPadraoLoja.Text) || string.IsNullOrEmpty(txtMkupPadrao.Text)) {
                MessageBox.Show("Campo Loja ou campo de Mkup estão vazios!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                return;
            } else {
                GravarNovoMkupPadraoLoja();
                GravarLogMkupLoja();
                carregarMkupPadrao();
            }
        }

        private void GravarLogMkupLoja() {
            try {
                LogMkupLoja dadosLog = new LogMkupLoja();
                MkupPadraoServices mkuppadrao = new MkupPadraoServices();

                dadosLog.loj_loja_IN = string.IsNullOrEmpty(cboMkupPadraoLoja.SelectedValue?.ToString()) ? (int?)null : Convert.ToInt32(cboMkupPadraoLoja.SelectedValue);
                dadosLog.MkupPadrao = !string.IsNullOrEmpty(txtMkupPadrao.Text) ? Convert.ToDouble(txtMkupPadrao.Text) : (double?)null;

                dataSetLogAlteracoMkupPadrao = mkuppadrao.gravarLogMkupPadraLoja(dadosLog);

                MessageBox.Show("Mkup padrão da loja gravado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                // Trata erros e exibe mensagem para o usuário
                tratarErros tratarErros = new tratarErros();
                string erroTratado = tratarErros.tratarErro(ex, MethodBase.GetCurrentMethod()?.Name.ToString(), this.GetType().Name);

                MessageBox.Show(erroTratado, "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProdutos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            UtilGeral.ordenar(dgvProdutos, ref objLstDadosGrid, ref ordemAscendente, e.ColumnIndex);
        }

        private void chkGrade_Click(object sender, EventArgs e) {
            if (chkGrade.Checked == true) {
                dgvProdutos.Columns["dgvProdutosCodigoProduto"].Visible = false;
                Cursor = Cursors.WaitCursor;
                CarregarDadosBanco();
                Cursor = Cursors.Default;
            } else {
                dgvProdutos.Columns["dgvProdutosCodigoProduto"].Visible = true;
            }

        }

        private void txtAgrupador_TextChanged_1(object sender, EventArgs e) {
            string filtro = txtAgrupador.Text.ToLower();

            var listaFiltrada = objLstDadosGrid
            .Where(item => (item.Descricao_Grade.ToString() ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<DadosGrid>(dgvProdutos, ref listaFiltrada);

            lblTotalEncontrado.Text = listaFiltrada.Count.ToString();
        }

        private void DesmarcarGrid() {
            // Desmarca todos os itens no DataGridView
            foreach (DataGridViewRow row in dgvProdutos.Rows) {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["campo_selecao"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null) {
                    checkBoxCell.Value = false;
                }
            }
        }

        private void btnLogMkupLoja_Click(object sender, EventArgs e) {
            var frmLogMkupLoja = new frmLogMkupLoja();
            frmLogMkupLoja.FormularioPai = this; // Passa a referência do formulário atual
            frmLogMkupLoja.Show(); // Abre o form de cadastro do motivo
        }

        private void bntCadCategoriaAdicinal_Click(object sender, EventArgs e) {

            var frmCadastroCategoriaAdicinalLojaOnline = new frmCadastroCategoriaAdicinalLojaOnline();
            frmCadastroCategoriaAdicinalLojaOnline.Show(); // Abre o form de cadastro do motivo
                   }
    }
}
