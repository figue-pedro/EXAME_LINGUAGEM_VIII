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
    public partial class FrmMotorista : Form
    {
        int idMotorista = 0;
        public FrmMotorista()
        {
            InitializeComponent();
        }
        private void LimparCampos()
        {
            txtNome.Clear();
            txtCarta.Clear();
            txtHabilitacoes.Clear();

            cmbEstado.SelectedIndex = -1;

            idMotorista = 0;

            txtNome.Focus();
        }
        private void CarregarMotoristas()
        {
            MotoristaBILL bll = new MotoristaBILL();

            dgvMotorista.DataSource = bll.Listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Motorista m = new Motorista();

            m.Nome = txtNome.Text;
            m.CartaConducao = txtCarta.Text;
            m.Habilitacoes = txtHabilitacoes.Text;
            m.Estado = cmbEstado.Text;

            MotoristaBILL bll = new MotoristaBILL();

            bll.Salvar(m);

            MessageBox.Show("Motorista registado.");

            CarregarMotoristas();
            LimparCampos();
        }

        private void FrmMotorista_Load(object sender, EventArgs e)
        {
            CarregarMotoristas();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvMotorista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idMotorista =
                Convert.ToInt32(
                dgvMotorista.Rows[e.RowIndex]
                .Cells["IdMotorista"].Value);

                txtNome.Text =
                dgvMotorista.Rows[e.RowIndex]
                .Cells["Nome"].Value.ToString();

                txtCarta.Text =
                dgvMotorista.Rows[e.RowIndex]
                .Cells["CartaConducao"].Value.ToString();

                txtHabilitacoes.Text =
                dgvMotorista.Rows[e.RowIndex]
                .Cells["Habilitacoes"].Value.ToString();

                cmbEstado.Text =
                dgvMotorista.Rows[e.RowIndex]
                .Cells["Estado"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idMotorista == 0)
            {
                MessageBox.Show("Seleccione um motorista.");
                return;
            }

            Motorista m = new Motorista();

            m.IdMotorista = idMotorista;
            m.Nome = txtNome.Text;
            m.CartaConducao = txtCarta.Text;
            m.Habilitacoes = txtHabilitacoes.Text;
            m.Estado = cmbEstado.Text;

            MotoristaBILL bll = new MotoristaBILL();

            bll.Actualizar(m);

            MessageBox.Show("Motorista actualizado.");

            CarregarMotoristas();

            LimparCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (idMotorista == 0)
            {
                MessageBox.Show("Seleccione um motorista.");
                return;
            }

            DialogResult resposta =
                MessageBox.Show(
                "Deseja eliminar este motorista?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                MotoristaBILL bll = new MotoristaBILL();

                bll.Eliminar(idMotorista);

                MessageBox.Show("Motorista eliminado.");

                CarregarMotoristas();

                LimparCampos();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
