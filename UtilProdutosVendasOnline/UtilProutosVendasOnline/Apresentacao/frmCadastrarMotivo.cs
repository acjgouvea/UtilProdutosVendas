using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UtilitarioProdutoVendasOnline.Services;
using UtilitarioProdutoVendasOnline.Transferencia;
using UtilsNeobetel;

namespace UtilProutosVendasOnline.Apresentacao
{
 
    public partial class frmCadastrarMotivo : Form
    {
        MotivoMkup objDadosMotivoSel = new MotivoMkup();

        DataSet dataSetMotivoMkup = new DataSet();
        MotivoMkup objDadosGridMotivo = new MotivoMkup();
        DataSet dataSetMotivoMkupPreco = new DataSet();
        List<MotivoMkup> objLstDadosMotivoMkup = new List<MotivoMkup>();
        public frmUtilitarioVendasOnline FormularioPai { get; set; }

        public frmCadastrarMotivo()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FormularioPai?.carregarComboMotivosMkupPreco();
            this.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            FormularioPai?.carregarComboMotivosMkupPreco();
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                MessageBox.Show("Campo motivo vazio.");
            }
            else
            {
                GravarMotivo();
                FormularioPai?.carregarComboMotivosMkupPreco();
            }
        }


        private void GravarMotivo()
        {
            MotivoMkup motivo = new MotivoMkup();
            MotivoMkupServices mkuppadrao = new MotivoMkupServices();

            motivo.mmp_motivo_VC = string.IsNullOrEmpty(txtMotivo.Text) ? null : txtMotivo.Text;

            try
            {
                dataSetMotivoMkup = mkuppadrao.gravarMotivoMkupPreco(motivo);
                MessageBox.Show("Motivo cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregaGridMotivos();
            }
            catch (Exception)
            {
                // Exibe a mensagem de erro retornada pela stored procedure ou outro erro
                MessageBox.Show("Motivo já foi cadastrado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmCadastrarMotivo_Load(object sender, EventArgs e)
        {
            UtilGeral.formataPadrao_Grid(dgvMotivos);
           
            CarregaGridMotivos();
            configuraMarcarDesmarcarTodos();
        }

        private void CarregaGridMotivos()
        {
            MotivoMkup dadosMotivo = new MotivoMkup();
            MotivoMkupServices dadosMkupServices = new MotivoMkupServices();

            dadosMotivo = new MotivoMkup();

            dataSetMotivoMkupPreco = dadosMkupServices.retornaGridMotivo();

            objLstDadosMotivoMkup = dataSetMotivoMkupPreco.Tables[0].ToList<MotivoMkup>();
            UtilGeral.formataPadrao_Grid(dgvMotivos);
            UtilGeral.carregaGrid(dgvMotivos, ref objLstDadosMotivoMkup);
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtMotivo.Text.ToLower();

            var listaFiltrada = objLstDadosMotivoMkup
            .Where(item => (item.mmp_motivo_VC.ToString() ?? "").ToLower().Contains(filtro))
            .ToList();

            UtilGeral.carregaGrid<MotivoMkup>(dgvMotivos, ref listaFiltrada);

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;        
            DeletaMotivos();
            Cursor = Cursors.Default;
        }

        private bool VerificarItemSelecionado()
        {
            foreach (DataGridViewRow row in dgvMotivos.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private void DeletaMotivos()
        {
            try
            {
                MotivoMkup dadosMkup = new MotivoMkup();

                if (dgvMotivos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Nenhum motivo selecionado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var dadosMkupServices = new MotivoMkupServices();
                bool sucesso = true;

                foreach (var item in objLstDadosMotivoMkup.Where(x => x.sel == true).ToList())
                {
                    try
                    {
                        var retOutPut = dadosMkupServices.deletaMotivo(item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao deletar o motivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sucesso = false;
                    }
                }


                if (sucesso)
                {
                    MessageBox.Show("Motivo(s) excluído(s) com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Alguns motivos não puderam ser excluídos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtMotivo.Text = "";
                CarregaGridMotivos();

                foreach (DataGridViewRow row in dgvMotivos.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["campo_selecao"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {
                        checkBoxCell.Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao excluir o motivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Marcação do campo de seleção do grid
        private void dgvMotivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMotivos.Columns["campo_selecao"].Index)
            {
                // Obter a célula do CheckBox
                var checkBoxCell = dgvMotivos.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null)
                {
                    // Garantir que o valor não seja nulo, definindo um padrão caso necessário
                    if (checkBoxCell.Value == null || checkBoxCell.Value == DBNull.Value)
                    {
                        checkBoxCell.Value = false; // Define o valor padrão como falso
                    }

                    // Alterar o estado do CheckBox
                    bool novoValor = !(bool)checkBoxCell.Value;
                    checkBoxCell.Value = novoValor;

                    // Atualizar o campo `sel` no objeto vinculado
                    var motivoSelecionado = dgvMotivos.Rows[e.RowIndex].DataBoundItem as MotivoMkup;
                    if (motivoSelecionado != null)
                    {
                        motivoSelecionado.sel = novoValor;
                    }

                    // Alterar a seleção da linha com base no estado do CheckBox
                    dgvMotivos.Rows[e.RowIndex].Selected = novoValor;
                }
                else
                {
                    MessageBox.Show("Erro ao acessar a célula do CheckBox.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void configuraMarcarDesmarcarTodos()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem marcarTodosItem = new ToolStripMenuItem("Marcar Todos");
            ToolStripMenuItem desmarcarTodosItem = new ToolStripMenuItem("Desmarcar Todos");

            contextMenu.Items.Add(marcarTodosItem);
            contextMenu.Items.Add(desmarcarTodosItem);

            dgvMotivos.ContextMenuStrip = contextMenu;

            marcarTodosItem.Click += (s, ev) => MarcarTodos(true);
            desmarcarTodosItem.Click += (s, ev) => MarcarTodos(false);
        }

        private void MarcarTodos(bool marcado)
        {
            foreach (DataGridViewRow row in dgvMotivos.Rows)
            {
                row.Cells["campo_selecao"].Value = marcado;
            }
            dgvMotivos.Refresh();
        }

        private void dgvMotivos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMotivos.SelectedRows.Count == 0)
            {
                return;
            }

            objDadosMotivoSel = dgvMotivos.SelectedRows[0].DataBoundItem as MotivoMkup;
        }

        private void btnMinimizar_Click(object sender, EventArgs e) {

        }
    }
}
