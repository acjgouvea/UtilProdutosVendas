using Falco.BancoDados;
using UtilProutosVendasOnline;
using System;
using System.Windows.Forms;
using UtilitarioProdutosVendasOnline.Apresentacao;

namespace UtilitarioProdutoVendasOnline {
    internal static class Program {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (args.Length > 0) {
                clsBancoDados.Servidor = args[0];
                clsBancoDados.Banco = args[1];
                clsBancoDados.Usuario = args[2];
                clsBancoDados.Senha = args[3];
            } else {
                clsBancoDados.Servidor = "";
                clsBancoDados.Banco = "";
                clsBancoDados.Usuario = "";
                clsBancoDados.Senha = "";
                clsBancoDados.Conectar(true);
            }

            Application.Run(new frmUtilitarioVendasOnline());
        }
    }
}
