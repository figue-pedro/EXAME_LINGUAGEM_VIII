using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Formulario;
using WindowsFormsApplication1.UI;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void veiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVeiculo Vei = new FrmVeiculo();
            Vei.ShowDialog();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void motoristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMotorista Motor = new FrmMotorista();
            Motor.ShowDialog();
        }

        private void rotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRota Rota = new FrmRota();
            Rota.ShowDialog();
        }

        private void registrarViagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmViagem Viag = new FrmViagem();
            Viag.ShowDialog();
        }

        private void manutençãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManutenção Man = new FrmManutenção();
            Man.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToShortDateString();

            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void motoristasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRelatorio Rela = new FrmRelatorio();
            Rela.ShowDialog();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
