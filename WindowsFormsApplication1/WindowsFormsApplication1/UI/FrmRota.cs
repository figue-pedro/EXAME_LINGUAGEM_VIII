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
using WindowsFormsApplication1.Dal;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Formulario
{
    public partial class FrmRota : Form
    {
        int idRota = 0;
        public FrmRota()
        {
            InitializeComponent();
        }
           RotaDAL dal = new RotaDAL();


           private void LimparCampos()
           {
               txtOrigem.Clear();
               txtDestino.Clear();
               txtDistancia.Clear();
               txtTempo.Clear();

               idRota = 0;

               txtOrigem.Focus();
           }

        private void button1_Click(object sender, EventArgs e)
           {
               Rota r = new Rota();

               r.Origem = txtOrigem.Text;
               r.Destino = txtDestino.Text;
               r.Distancia = Convert.ToDouble(txtDistancia.Text);
               r.TempoEstimado = txtTempo.Text;

               RotaBLL bll = new RotaBLL();

               bll.Salvar(r);

               MessageBox.Show("Rota registada.");

               CarregarRotas();
               LimparCampos();
        }
        private void CarregarRotas()
        {
            RotaBLL bll = new RotaBLL();

            dgvRotas.DataSource = bll.Listar();
        }

        private void FrmRota_Load(object sender, EventArgs e)
        {
            CarregarRotas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvRotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
    if (e.RowIndex >= 0)
    {
        idRota =
        Convert.ToInt32(
        dgvRotas.Rows[e.RowIndex]
        .Cells["IdRota"].Value);

        txtOrigem.Text =
        dgvRotas.Rows[e.RowIndex]
        .Cells["Origem"].Value.ToString();

        txtDestino.Text =
        dgvRotas.Rows[e.RowIndex]
        .Cells["Destino"].Value.ToString();

        txtDistancia.Text =
        dgvRotas.Rows[e.RowIndex]
        .Cells["Distancia"].Value.ToString();

        txtTempo.Text =
        dgvRotas.Rows[e.RowIndex]
        .Cells["TempoEstimado"].Value.ToString();
    }
}

        private void button2_Click(object sender, EventArgs e)
        {
            if (idRota == 0)
            {
                MessageBox.Show("Seleccione uma rota.");
                return;
            }

            Rota r = new Rota();

            r.IdRota = idRota;
            r.Origem = txtOrigem.Text;
            r.Destino = txtDestino.Text;
            r.Distancia = Convert.ToDouble(txtDistancia.Text);
            r.TempoEstimado = txtTempo.Text;

            RotaBLL bll = new RotaBLL();

            bll.Actualizar(r);

            MessageBox.Show("Rota actualizada.");

            CarregarRotas();

            LimparCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (idRota == 0)
            {
                MessageBox.Show("Seleccione uma rota.");
                return;
            }

            DialogResult resposta =
                MessageBox.Show(
                "Deseja eliminar esta rota?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                RotaBLL bll = new RotaBLL();

                bll.Eliminar(idRota);

                MessageBox.Show("Rota eliminada.");

                CarregarRotas();

                LimparCampos();
            }
        }
       
    
    
}
}
