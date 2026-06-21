using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Bll;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Formulario
{
    public partial class FrmVeiculo : Form
    {
        int idVeiculo = 0;
        public FrmVeiculo()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            VeiculoModel v = new VeiculoModel();

            v.Matricula = txtMatricula.Text;
            v.Tipo = txtTipo.Text;
            if (string.IsNullOrWhiteSpace(txtCapacidade.Text)) 
            {
                MessageBox.Show("Preencha o campo capacidade.");
                return;
            }
            v.Capacidade = Convert.ToDouble(txtCapacidade.Text);
            if (string.IsNullOrWhiteSpace(txtConsumo.Text)) 
            {
                MessageBox.Show("Preencha o campo Consumo.");
                return;
 
            }
            v.Consumo = Convert.ToDouble(txtConsumo.Text);
            v.Estado = cmbEstado.Text;

            veiculo bll = new veiculo();

            bll.Salvar(v);

            MessageBox.Show("Veículo registado com sucesso.");
            CarregarVeiculo();
        }
        private void CarregarVeiculo()
        {

            veiculo bll = new veiculo();

            DgvVeiculo.DataSource = bll.Listar();



        }
        private void LimparCampos()
        {
            txtMatricula.Clear();
       
            txtCapacidade.Clear();
            txtConsumo.Clear();

            cmbEstado.SelectedIndex = -1;

            idVeiculo = 0;

            txtMatricula.Focus();
        }

        private void FrmVeiculo_Load(object sender, EventArgs e)
        {
            CarregarVeiculo();
        }

        private void DgvVeiculo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idVeiculo == 0)
            {
                MessageBox.Show("Seleccione um veículo.");
                return;
            }

            VeiculoModel v = new VeiculoModel();

            v.IdVeiculo = idVeiculo;
            v.Matricula = txtMatricula.Text;
            v.Tipo = txtTipo.Text;
            v.Capacidade = Convert.ToDouble(txtCapacidade.Text);
            v.Consumo = Convert.ToDouble(txtConsumo.Text);
            v.Estado = cmbEstado.Text;

            veiculo bll = new veiculo();

            bll.Actualizar(v);

            MessageBox.Show("Veículo actualizado.");

            CarregarVeiculo();

            LimparCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (idVeiculo == 0)
            {
                MessageBox.Show("Seleccione um veículo.");
                return;
            }

            DialogResult resposta =
                MessageBox.Show(
                "Deseja eliminar este veículo?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                veiculo bll = new veiculo();

                bll.Eliminar(idVeiculo);

                MessageBox.Show("Veículo eliminado.");

                CarregarVeiculo();

                LimparCampos();
            }
        }

        private void DgvVeiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                idVeiculo = Convert.ToInt32(
                    DgvVeiculo.Rows[e.RowIndex]
                    .Cells["IdVeiculo"].Value);

                txtMatricula.Text =
                    DgvVeiculo.Rows[e.RowIndex]
                    .Cells["Matricula"].Value.ToString();

                txtTipo.Text =
                    DgvVeiculo.Rows[e.RowIndex]
                    .Cells["Tipo"].Value.ToString();

                txtCapacidade.Text =
                    DgvVeiculo.Rows[e.RowIndex]
                    .Cells["Capacidade"].Value.ToString();

                txtConsumo.Text =
                    DgvVeiculo.Rows[e.RowIndex]
                    .Cells["Consumo"].Value.ToString();

                cmbEstado.Text =
                    DgvVeiculo.Rows[e.RowIndex]
                    .Cells["Estado"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
