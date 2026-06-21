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

namespace WindowsFormsApplication1.Formulario
{
    public partial class FrmManutenção : Form
    {
        int idManutencao = 0;
        public FrmManutenção()
        {
            InitializeComponent();
        }

        conexao Conexao = new conexao();
        private void LimparCampos()
        {
            cmbVeiculo.SelectedIndex = -1;

          
            txtCusto.Clear();

            cmbEstado.SelectedIndex = -1;

            dtpData.Value = DateTime.Now;

            idManutencao = 0;
        }
        private void CarregarManutencoes()
        {
            SqlConnection cn = Conexao.ObterConexao();

            string sql = @"
    SELECT
    M.IdManutencao,
    V.Matricula,
    M.TipoManutencao,
    M.DataManutencao,
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

            dgvManutencao.DataSource = dt;
        }

        private void CarregarVeiculos()
        {
            SqlConnection cn = Conexao.ObterConexao();

            cn.Open();

            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT IdVeiculo,Matricula FROM Veiculo",
            cn);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            cmbVeiculo.DataSource = dt;

            cmbVeiculo.DisplayMember =
            "Matricula";

            cmbVeiculo.ValueMember =
            "IdVeiculo";

            cn.Close();
        }
        private void FrmManutenção_Load(object sender, EventArgs e)
        {
            CarregarManutencoes();
            CarregarVeiculos();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection cn = Conexao.ObterConexao();

            cn.Open();

            string sql = @"INSERT INTO Manutencao(IdVeiculo,TipoManutencao,DataManutencao,Custo,Estado)VALUES(@IdVeiculo,@Tipo,@Data,@Custo,@Estado)";

            SqlCommand cmd =
            new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@IdVeiculo", cmbVeiculo.SelectedValue);

            cmd.Parameters.AddWithValue("@Tipo", txtTipo.Text);

            cmd.Parameters.AddWithValue("@Data", dtpData.Value);

            cmd.Parameters.AddWithValue("@Custo", txtCusto.Text);

            cmd.Parameters.AddWithValue("@Estado", cmbEstado.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show(
            "Manutenção registada.");

            cn.Close();

        }

        private void dgvManutencao_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                idManutencao =
                Convert.ToInt32(
                dgvManutencao.Rows[e.RowIndex]
                .Cells["IdManutencao"].Value);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (idManutencao == 0)
            {
                MessageBox.Show("Seleccione uma manutenção.");
                return;
            }

            SqlConnection cn = Conexao.ObterConexao();

            cn.Open();

            string sql = @"
    UPDATE Manutencao
    SET
    IdVeiculo=@IdVeiculo,
    TipoManutencao=@Tipo,
    DataManutencao=@Data,
    Custo=@Custo,
    Estado=@Estado
    WHERE IdManutencao=@Id";

            SqlCommand cmd =
            new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@Id", idManutencao);
            cmd.Parameters.AddWithValue("@IdVeiculo", cmbVeiculo.SelectedValue);
            cmd.Parameters.AddWithValue("@Tipo", txtTipo.Text);
            cmd.Parameters.AddWithValue("@Data", dtpData.Value);
            cmd.Parameters.AddWithValue("@Custo",
                Convert.ToDouble(txtCusto.Text));
            cmd.Parameters.AddWithValue("@Estado", cmbEstado.Text);

            cmd.ExecuteNonQuery();

            cn.Close();

            MessageBox.Show("Manutenção actualizada.");

            CarregarManutencoes();

            LimparCampos();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (idManutencao == 0)
            {
                MessageBox.Show("Seleccione uma manutenção.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Deseja eliminar esta manutenção?",
                "Confirmação",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                SqlConnection cn = Conexao.ObterConexao();

                cn.Open();

                SqlCommand cmd =
                new SqlCommand(
                "DELETE FROM Manutencao WHERE IdManutencao=@Id",
                cn);

                cmd.Parameters.AddWithValue("@Id", idManutencao);

                cmd.ExecuteNonQuery();

                cn.Close();

                MessageBox.Show("Manutenção eliminada.");

                CarregarManutencoes();

                LimparCampos();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
