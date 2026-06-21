using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Dal;


namespace WindowsFormsApplication1.UI
{
    public partial class FrmRelatorio : Form
    {
        public FrmRelatorio()
        {
            InitializeComponent();
        }
        conexao Conexao = new conexao();
        private void RelatorioVeiculos()
        {
            SqlConnection cn =
            Conexao.ObterConexao();

            string sql =
            "SELECT * FROM Veiculo";

            SqlDataAdapter da =
            new SqlDataAdapter(sql, cn);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            dgvRelatorio.DataSource = dt;
        }
        private void RelatorioMotoristas()
        {
            SqlConnection cn =
            Conexao.ObterConexao();

            string sql =
            "SELECT * FROM Motorista";

            SqlDataAdapter da =
            new SqlDataAdapter(sql, cn);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            dgvRelatorio.DataSource = dt;
        }
        private void RelatorioRotas()
        {
            SqlConnection cn =
            Conexao.ObterConexao();

            string sql =
            "SELECT * FROM Rota";

            SqlDataAdapter da =
            new SqlDataAdapter(sql, cn);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            dgvRelatorio.DataSource = dt;
        }
        private void RelatorioViagens()
        {
            SqlConnection cn =
            Conexao.ObterConexao();

            string sql = @"
    SELECT
    Vg.IdViagem,
    V.Matricula,
    M.Nome,
    R.Origem + ' - ' + R.Destino AS Rota,
    Vg.DataViagem,
    Vg.CustoTotal
    FROM Viagem Vg
    INNER JOIN Veiculo V
    ON V.IdVeiculo=Vg.IdVeiculo
    INNER JOIN Motorista M
    ON M.IdMotorista=Vg.IdMotorista
    INNER JOIN Rota R
    ON R.IdRota=Vg.IdRota";

            SqlDataAdapter da =
            new SqlDataAdapter(sql, cn);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            dgvRelatorio.DataSource = dt;
        }
        private void RelatorioManutencoes()
        {
            SqlConnection cn =
            Conexao.ObterConexao();

            string sql = @"
    SELECT
    M.IdManutencao,
    V.Matricula,
    M.TipoManutencao,
    M.Custo,
    M.Estado
    FROM Manutencao M
    INNER JOIN Veiculo V
    ON V.IdVeiculo=M.IdVeiculo";

            SqlDataAdapter da =
            new SqlDataAdapter(sql, cn);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            dgvRelatorio.DataSource = dt;
        }


        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (cmbRelatorio.Text == "Veículos")
            {
                RelatorioVeiculos();
            }

            if (cmbRelatorio.Text == "Motoristas")
            {
                RelatorioMotoristas();
            }

            if (cmbRelatorio.Text == "Rotas")
            {
                RelatorioRotas();
            }

            if (cmbRelatorio.Text == "Viagens")
            {
                RelatorioViagens();
            }

            if (cmbRelatorio.Text == "Manutenções")
            {
                RelatorioManutencoes();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document =  printDocument1;

            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fonte =
   new Font("Arial", 10);

            int y = 50;

            e.Graphics.DrawString(
            "RELATÓRIO TRANSPORTADORA",
            new Font("Arial", 14, FontStyle.Bold),
            Brushes.Black,
            200,
            y);

            y += 50;

            foreach (DataGridViewRow row
                    in dgvRelatorio.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string linha = "";

                    foreach (DataGridViewCell cell
                            in row.Cells)
                    {
                        linha +=
                        cell.Value + "   ";
                    }

                    e.Graphics.DrawString(
                    linha,
                    fonte,
                    Brushes.Black,
                    20,
                    y);

                    y += 25;
                }
            }
        }

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {

        }
    }
}
