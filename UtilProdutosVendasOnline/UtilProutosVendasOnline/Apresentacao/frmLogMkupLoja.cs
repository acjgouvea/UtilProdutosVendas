using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitarioProdutoVendasOnline.Services;
using UtilitarioProdutoVendasOnline.Transferencia;
using UtilProutosVendasOnline;
using UtilsNeobetel;

namespace UtilitarioProdutosVendasOnline.Apresentacao
{
    public partial class frmLogMkupLoja : Form
    {
        public frmUtilitarioVendasOnline FormularioPai { get; set; }
        public DataSet dataSetLogMkupLoja = new DataSet();
        List<LogMkupLoja> objLstLogMkupLoja = new List<LogMkupLoja>();

        public frmLogMkupLoja()
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

        private void frmLogMkupLoja_Load(object sender, EventArgs e)
        {
            UtilGeral.formataPadrao_Grid(dgvLogMkup);

            CarregaGridLogMkupLoja();
        }

        private void CarregaGridLogMkupLoja()
        {
            LogMkupLoja dadosLogMkuoLoja = new LogMkupLoja();
            LogMkupLojaServices dadosMkupServices = new LogMkupLojaServices();

            dadosLogMkuoLoja = new LogMkupLoja();

            dataSetLogMkupLoja = dadosMkupServices.retornaGridLogMkupLoja();

            objLstLogMkupLoja = dataSetLogMkupLoja.Tables[0].ToList<LogMkupLoja>();
            UtilGeral.formataPadrao_Grid(dgvLogMkup);
            UtilGeral.carregaGrid(dgvLogMkup, ref objLstLogMkupLoja);
        }
    }
}
