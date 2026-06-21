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
    public partial class FrmViagem : Form
    {
        int idViagem = 0;
        public FrmViagem()
        {
            InitializeComponent();
        }
        conexao Conexao = new conexao();

        private void TxtEstado_TextChanged(object sender, EventArgs e)
        {

        }
        private void LimparCampos()
        {
            cmbVeiculo.SelectedIndex = -1;
            cmbMotorista.SelectedIndex = -1;
            cmbRota.SelectedIndex = -1;

            txtPrecoCombustivel.Clear();
           

            dtpData.Value = DateTime.Now;

            idViagem = 0;
        }
        private void CarregarVeiculos()
        {
            SqlConnection cn = Conexao.ObterConexao();

            cn.Open();

            SqlDataAdapter da =
            new SqlDataAdapter(
            "SELECT IdVeiculo,Matricula FROM Veiculo",
            cn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            cmbVeiculo.DataSource = dt;

            cmbVeiculo.DisplayMember = "Matricula";

            cmbVeiculo.ValueMember = "IdVeiculo";

            cn.Close();
        }
        private void CarregarMotoristas()
        {
            SqlConnection cn = Conexao.ObterConexao();

            cn.Open();

            SqlDataAdapter da =
            new SqlDataAdapter(
            "SELECT IdMotorista,Nome FROM Motorista",
            cn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            cmbMotorista.DataSource = dt;

            cmbMotorista.DisplayMember = "Nome";

            cmbMotorista.ValueMember = "IdMotorista";

            cn.Close();
        }
        private void CarregarRotas()
        {
            SqlConnection cn = Conexao.ObterConexao();

            cn.Open();

            SqlDataAdapter da =
            new SqlDataAdapter(
            "SELECT IdRota,Origem+' - '+Destino AS Rota FROM Rota",
            cn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            cmbRota.DataSource = dt;

            cmbRota.DisplayMember = "Rota";

            cmbRota.ValueMember = "IdRota";

            cn.Close();
        }
        private void FrmViagem_Load(object sender, EventArgs e)
        {
            
            CarregarViagens();
            CarregarVeiculos();
            CarregarMotoristas();
            CarregarRotas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cn = Conexao.ObterConexao();

            cn.Open();

            SqlCommand cmd =
            new SqlCommand(
            @"SELECT
      V.Consumo,
      R.Distancia
      FROM Veiculo V
      INNER JOIN Rota R
      ON R.IdRota=@IdRota
      WHERE V.IdVeiculo=@IdVeiculo",
              cn);

            cmd.Parameters.AddWithValue(
            "@IdVeiculo",
            cmbVeiculo.SelectedValue);

            cmd.Parameters.AddWithValue(
            "@IdRota",
            cmbRota.SelectedValue);

            SqlDataReader dr =
            cmd.ExecuteReader();

            if (dr.Read())
            {
                double consumo =
                Convert.ToDouble(dr["Consumo"]);

                double distancia =
                Convert.ToDouble(dr["Distancia"]);

                double preco =
                Convert.ToDouble(
                txtPrecoCombustivel.Text);

                double custo =(distancia / 100)* consumo* preco;

                txtCusto.Text = custo.ToString("N2");
            }

            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn =
   Conexao.ObterConexao();

            cn.Open();

            string sql =@"INSERT INTO Viagem(IdVeiculo,IdMotorista,IdRota,DataViagem,PrecoCombustivel,CustoTotal)VALUES(@IdVeiculo,@IdMotorista,@IdRota,@Data,@Preco,@Custo)";

            SqlCommand cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@IdVeiculo",cmbVeiculo.SelectedValue);
            cmd.Parameters.AddWithValue("@IdMotorista",cmbMotorista.SelectedValue);
            cmd.Parameters.AddWithValue("@IdRota",cmbRota.SelectedValue);
            cmd.Parameters.AddWithValue("@Data",dtpData.Value);
            cmd.Parameters.AddWithValue("@Preco",Convert.ToDouble(txtPrecoCombustivel.Text));
            cmd.Parameters.AddWithValue("@Custo",Convert.ToDouble(txtCusto.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Viagem registada.");

            cn.Close();
        }
        private void CarregarViagens()
        {
            SqlConnection cn = Conexao.ObterConexao();

            string sql = @"
    SELECT
    Vg.IdViagem,
    V.Matricula,
    M.Nome,
    R.Origem + ' - ' + R.Destino AS Rota,
    Vg.DataViagem,
    Vg.PrecoCombustivel,
    Vg.CustoTotal
    FROM Viagem Vg
    INNER JOIN Veiculo V ON V.IdVeiculo=Vg.IdVeiculo
    INNER JOIN Motorista M ON M.IdMotorista=Vg.IdMotorista
    INNER JOIN Rota R ON R.IdRota=Vg.IdRota";

            SqlDataAdapter da = new SqlDataAdapter(sql, cn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvViagens.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvViagens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
    if (e.RowIndex >= 0)
    {
        var valor = dgvViagens.Rows[e.RowIndex].Cells["IdViagem"].Value;
        if (valor != null && valor != DBNull.Value) 
        {
            idViagem = Convert.ToInt32(valor);
        }
        
    }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idViagem == 0)
            {
                MessageBox.Show("Seleccione uma viagem.");
                return;
            }

            SqlConnection cn = Conexao.ObterConexao();

            cn.Open();

            string sql = @"
    UPDATE Viagem
    SET
    IdVeiculo=@IdVeiculo,
    IdMotorista=@IdMotorista,
    IdRota=@IdRota,
    DataViagem=@Data,
    PrecoCombustivel=@Preco,
    CustoTotal=@Custo
    WHERE IdViagem=@Id";

            SqlCommand cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@Id", idViagem);
            cmd.Parameters.AddWithValue("@IdVeiculo", cmbVeiculo.SelectedValue);
            cmd.Parameters.AddWithValue("@IdMotorista", cmbMotorista.SelectedValue);
            cmd.Parameters.AddWithValue("@IdRota", cmbRota.SelectedValue);
            cmd.Parameters.AddWithValue("@Data", dtpData.Value);

            cmd.Parameters.AddWithValue("@Preco",
                Convert.ToDouble(txtPrecoCombustivel.Text));

            cmd.Parameters.AddWithValue("@Custo",
                Convert.ToDouble(txtCusto.Text));

            cmd.ExecuteNonQuery();

            cn.Close();

            MessageBox.Show("Viagem actualizada.");

            CarregarViagens();

            LimparCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (idViagem == 0)
            {
                MessageBox.Show("Seleccione uma viagem.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Deseja eliminar a viagem?",
                "Confirmação",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                SqlConnection cn = Conexao.ObterConexao();

                cn.Open();

                SqlCommand cmd =
                    new SqlCommand(
                    "DELETE FROM Viagem WHERE IdViagem=@Id",
                    cn);

                cmd.Parameters.AddWithValue("@Id", idViagem);

                cmd.ExecuteNonQuery();

                cn.Close();

                MessageBox.Show("Viagem eliminada.");

                CarregarViagens();

                LimparCampos();
            }
        }
    }
}
