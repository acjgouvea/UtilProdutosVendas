using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitarioProdutosVendasOnline.Services;
using UtilitarioProdutoVendasOnline.Negocio;
using UtilitarioProdutoVendasOnline.Services;
using UtilitarioProdutoVendasOnline.Transferencia;
using UtilsNeobetel;

namespace UtilitarioProdutosVendasOnline.Apresentacao {
    public partial class frmCadastroCategoriaAdicinalLojaOnline : Form {
        private bool ordemAscendente = true;
        DataSet dataSetGridCategoriaAdicional = new DataSet();
        DataSet dataSetGridProdutosVendasOnline = new DataSet();

        List<DadosGridCaregoriaAdicional> objLstDadosProdutosCategoriaAdicional = new List<DadosGridCaregoriaAdicional>();
        List<DadosGridprodutosVendasOnline> objLstDadosProdutosVendasOnline = new List<DadosGridprodutosVendasOnline>();


        public frmCadastroCategoriaAdicinalLojaOnline() {
            InitializeComponent();
        }

        private void CarregaGridProdutosCategoriaAdicionalVendasONLINE() {
            DadosGridCaregoriaAdicional dadosGridCaregoriaAdicional = new DadosGridCaregoriaAdicional();
            CategoriaAdicional categoriaAdicional = new CategoriaAdicional();

            dadosGridCaregoriaAdicional = new DadosGridCaregoriaAdicional();

            dataSetGridCategoriaAdicional = categoriaAdicional.carregaObjCategoriaAdicional();

            objLstDadosProdutosCategoriaAdicional = dataSetGridCategoriaAdicional.Tables[0].ToList<DadosGridCaregoriaAdicional>();

            UtilGeral.formataPadrao_Grid(dgvProdutosCategoriaAdicionalVendasONLINE);
            UtilGeral.carregaGrid(dgvProdutosCategoriaAdicionalVendasONLINE, ref objLstDadosProdutosCategoriaAdicional);
        }



        private void CarregarGridProdutosVendasONLINE() {

            DadosGridprodutosVendasOnline dadosGridprodutosVendasOnline = new DadosGridprodutosVendasOnline();
            CategoriaAdicional categoriaAdicional = new CategoriaAdicional();

            dadosGridprodutosVendasOnline = new DadosGridprodutosVendasOnline();
            dataSetGridProdutosVendasOnline = categoriaAdicional.carregaObjProdutosLojaOn();

            objLstDadosProdutosVendasOnline = dataSetGridProdutosVendasOnline.Tables[0].ToList<DadosGridprodutosVendasOnline>();

            UtilGeral.formataPadrao_Grid(dgvProdutosVendasONLINE);
            UtilGeral.carregaGrid(dgvProdutosVendasONLINE, ref objLstDadosProdutosVendasOnline);



        }

        private void frmCadastroCategoriaAdicinalLojaOnline_Load(object sender, EventArgs e) {
            CarregaGridProdutosCategoriaAdicionalVendasONLINE();
            //CarregarGridProdutosVendasONLINE();
        }

        private void frmCadastroCategoriaAdicinalLojaOnline_Load_1(object sender, EventArgs e) {
            CarregaGridProdutosCategoriaAdicionalVendasONLINE();
            CarregarGridProdutosVendasONLINE();
        }

        private void btnSair_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void bntMini_Click(object sender, EventArgs e) {

            this.WindowState = FormWindowState.Minimized;
        }

        private void bntAtualiza_Click(object sender, EventArgs e) {
            AtualizaGrids();
        }
        private void LimpaCampos() {
            txtLoja.Text = "";
            txtCatIrroba.Text = "";
            textBox2.Text = "";
        }
        private void AtualizaGrids() {
            LimpaCampos();
            CarregaGridProdutosCategoriaAdicionalVendasONLINE();
            CarregarGridProdutosVendasONLINE();
        }
        private void txtLoja_TextChanged(object sender, EventArgs e) {
            string filtro = txtLoja.Text.ToLower();
            var listaFiltrada = objLstDadosProdutosCategoriaAdicional
            .Where(item => (item.loj_loja_IN.ToString() ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<DadosGridCaregoriaAdicional>(dgvProdutosCategoriaAdicionalVendasONLINE, ref listaFiltrada);



        }

        private void txtCatIrroba_TextChanged(object sender, EventArgs e) {
            string filtro = txtCatIrroba.Text.ToLower();
            var listaFiltrada = objLstDadosProdutosCategoriaAdicional
                .Where(item => (item.ID_CategoriaIrroba_IN.ToString() ?? "").ToLower().Contains(filtro))
                .ToList();
            UtilGeral.carregaGrid<DadosGridCaregoriaAdicional>(dgvProdutosCategoriaAdicionalVendasONLINE, ref listaFiltrada);
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            string filtro = textBox2.Text.ToLower();
            var listaFiltrada = objLstDadosProdutosVendasOnline
                .Where(item => (item.pro_descricao.ToString() ?? "").ToLower().Contains(filtro))
                .ToList();
            UtilGeral.carregaGrid<DadosGridprodutosVendasOnline>(dgvProdutosVendasONLINE, ref listaFiltrada);
        }




        private void adicionarProdutoCategoriaAdicional() {
            try {
                int loja = 0;
                int produto = 0;
                int codGrade = 0;
                int catIrroba = 0;

                var adicionaProdutoCategoriaAdicional = new DadosNeg();

                if (dgvProdutosVendasONLINE.SelectedRows.Count > 0) {
                    DataGridViewRow selectedRow = dgvProdutosVendasONLINE.SelectedRows[0];
                    loja = selectedRow.Cells["loj_loja_IN_PROD"].Value != DBNull.Value ? Convert.ToInt32(selectedRow.Cells["loj_loja_IN_PROD"].Value) : 0;
                    produto = selectedRow.Cells["pro_produto_PROD"].Value != DBNull.Value ? Convert.ToInt32(selectedRow.Cells["pro_produto_PROD"].Value) : 0;
                    codGrade = selectedRow.Cells["Codigo_GradePROD"].Value != DBNull.Value ? Convert.ToInt32(selectedRow.Cells["Codigo_GradePROD"].Value) : 0;
                    catIrroba = selectedRow.Cells["ID_CategoriaIrroba_IN_PROD"].Value != DBNull.Value ? Convert.ToInt32(selectedRow.Cells["ID_CategoriaIrroba_IN_PROD"].Value) : 0;

                    AtualizaGrids();

                    MessageBox.Show("Produto gravado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch {
                MessageBox.Show("Erro ao adicionar produto a categoria adicional", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void excluirProdutoCategoriaAdicional() {
            try {
                int loja = 0;
                int produto = 0;
                int codGrade = 0;
                int catIrroba = 0;

                var excluirProdutoCategoriaAdicional = new DadosNeg();

                if (dgvProdutosCategoriaAdicionalVendasONLINE.SelectedRows.Count > 0) {
                    DataGridViewRow selectedRow = dgvProdutosCategoriaAdicionalVendasONLINE.SelectedRows[0];
                    loja = selectedRow.Cells["loj_loja_IN"].Value != DBNull.Value ? Convert.ToInt32(selectedRow.Cells["loj_loja_IN"].Value) : 0;
                    produto = selectedRow.Cells["pro_produto"].Value != DBNull.Value ? Convert.ToInt32(selectedRow.Cells["pro_produto"].Value) : 0;
                    codGrade = selectedRow.Cells["Codigo_Grade"].Value != DBNull.Value ? Convert.ToInt32(selectedRow.Cells["Codigo_Grade"].Value) : 0;
                    catIrroba = selectedRow.Cells["ID_CategoriaIrroba_IN"].Value != DBNull.Value ? Convert.ToInt32(selectedRow.Cells["ID_CategoriaIrroba_IN"].Value) : 0;


                    var retorno = excluirProdutoCategoriaAdicional.ExcluirProdutoCategoriaAdicional(loja, produto, catIrroba, codGrade);

                    AtualizaGrids();

                    MessageBox.Show("Produto excluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch {
                MessageBox.Show("Erro ao excluir produto da categoria adicional", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e) {
            adicionarProdutoCategoriaAdicional();
        }

        private void bntExcluir_Click(object sender, EventArgs e) {
            excluirProdutoCategoriaAdicional();

        }

        private void dgvProdutosCategoriaAdicionalVendasONLINE_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            UtilGeral.ordenar(dgvProdutosCategoriaAdicionalVendasONLINE, ref objLstDadosProdutosCategoriaAdicional, ref ordemAscendente, e.ColumnIndex);
        }

        private void dgvProdutosVendasONLINE_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            UtilGeral.ordenar(dgvProdutosVendasONLINE, ref objLstDadosProdutosVendasOnline, ref ordemAscendente, e.ColumnIndex);
        }
    }
}












