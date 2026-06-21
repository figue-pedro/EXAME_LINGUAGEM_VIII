namespace WindowsFormsApplication1.Formulario
{
    partial class FrmViagem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecoCombustivel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvViagens = new System.Windows.Forms.DataGridView();
            this.cmbVeiculo = new System.Windows.Forms.ComboBox();
            this.cmbMotorista = new System.Windows.Forms.ComboBox();
            this.cmbRota = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.txtCusto = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViagens)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(411, 387);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 42;
            this.button4.Text = "Eliminar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(503, 387);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 23);
            this.button3.TabIndex = 41;
            this.button3.Text = "Calcular Custo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(283, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 40;
            this.button2.Text = "Editar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Data";
            // 
            // txtPrecoCombustivel
            // 
            this.txtPrecoCombustivel.Location = new System.Drawing.Point(525, 94);
            this.txtPrecoCombustivel.Name = "txtPrecoCombustivel";
            this.txtPrecoCombustivel.Size = new System.Drawing.Size(100, 20);
            this.txtPrecoCombustivel.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Veiculo";
            // 
            // dgvViagens
            // 
            this.dgvViagens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViagens.Location = new System.Drawing.Point(79, 172);
            this.dgvViagens.Name = "dgvViagens";
            this.dgvViagens.Size = new System.Drawing.Size(562, 181);
            this.dgvViagens.TabIndex = 32;
            this.dgvViagens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViagens_CellClick);
            // 
            // cmbVeiculo
            // 
            this.cmbVeiculo.FormattingEnabled = true;
            this.cmbVeiculo.Location = new System.Drawing.Point(110, 54);
            this.cmbVeiculo.Name = "cmbVeiculo";
            this.cmbVeiculo.Size = new System.Drawing.Size(121, 21);
            this.cmbVeiculo.TabIndex = 43;
            // 
            // cmbMotorista
            // 
            this.cmbMotorista.FormattingEnabled = true;
            this.cmbMotorista.Location = new System.Drawing.Point(347, 54);
            this.cmbMotorista.Name = "cmbMotorista";
            this.cmbMotorista.Size = new System.Drawing.Size(121, 21);
            this.cmbMotorista.TabIndex = 44;
            // 
            // cmbRota
            // 
            this.cmbRota.FormattingEnabled = true;
            this.cmbRota.Location = new System.Drawing.Point(541, 54);
            this.cmbRota.Name = "cmbRota";
            this.cmbRota.Size = new System.Drawing.Size(121, 21);
            this.cmbRota.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Motorista";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Rota";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Preço do Combustivel";
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(130, 95);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(200, 20);
            this.dtpData.TabIndex = 49;
            // 
            // txtCusto
            // 
            this.txtCusto.AutoSize = true;
            this.txtCusto.Location = new System.Drawing.Point(179, 451);
            this.txtCusto.Name = "txtCusto";
            this.txtCusto.Size = new System.Drawing.Size(19, 13);
            this.txtCusto.TabIndex = 50;
            this.txtCusto.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(107, 451);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Custo Total:";
            // 
            // FrmViagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 516);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCusto);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRota);
            this.Controls.Add(this.cmbMotorista);
            this.Controls.Add(this.cmbVeiculo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrecoCombustivel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvViagens);
            this.Name = "FrmViagem";
            this.Text = "FrmViagem";
            this.Load += new System.EventHandler(this.FrmViagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViagens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecoCombustivel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvViagens;
        private System.Windows.Forms.ComboBox cmbVeiculo;
        private System.Windows.Forms.ComboBox cmbMotorista;
        private System.Windows.Forms.ComboBox cmbRota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label txtCusto;
        private System.Windows.Forms.Label label6;
    }
}