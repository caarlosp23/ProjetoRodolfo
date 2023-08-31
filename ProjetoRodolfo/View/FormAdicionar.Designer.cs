namespace ProjetoRodolfo.View
{
    partial class FormAdicionar
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
            this.txtNomeProcesso = new System.Windows.Forms.TextBox();
            this.txtNomeUser = new System.Windows.Forms.TextBox();
            this.cmbPrioridade = new System.Windows.Forms.ComboBox();
            this.txtBoxCPU = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtEspacoMem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnCancelarFormAdc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNomeProcesso
            // 
            this.txtNomeProcesso.Location = new System.Drawing.Point(214, 69);
            this.txtNomeProcesso.Name = "txtNomeProcesso";
            this.txtNomeProcesso.Size = new System.Drawing.Size(100, 22);
            this.txtNomeProcesso.TabIndex = 0;
            // 
            // txtNomeUser
            // 
            this.txtNomeUser.Location = new System.Drawing.Point(214, 97);
            this.txtNomeUser.Name = "txtNomeUser";
            this.txtNomeUser.Size = new System.Drawing.Size(100, 22);
            this.txtNomeUser.TabIndex = 1;
            // 
            // cmbPrioridade
            // 
            this.cmbPrioridade.FormattingEnabled = true;
            this.cmbPrioridade.Items.AddRange(new object[] {
            "ALTA",
            "MÉDIA",
            "COMUM"});
            this.cmbPrioridade.Location = new System.Drawing.Point(214, 125);
            this.cmbPrioridade.Name = "cmbPrioridade";
            this.cmbPrioridade.Size = new System.Drawing.Size(100, 24);
            this.cmbPrioridade.TabIndex = 2;
            // 
            // txtBoxCPU
            // 
            this.txtBoxCPU.Location = new System.Drawing.Point(214, 155);
            this.txtBoxCPU.Name = "txtBoxCPU";
            this.txtBoxCPU.Size = new System.Drawing.Size(100, 22);
            this.txtBoxCPU.TabIndex = 3;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "PRONTO",
            "EXECUÇÃO",
            "ESPERA"});
            this.cmbEstado.Location = new System.Drawing.Point(214, 183);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(100, 24);
            this.cmbEstado.TabIndex = 4;
            // 
            // txtEspacoMem
            // 
            this.txtEspacoMem.Location = new System.Drawing.Point(214, 213);
            this.txtEspacoMem.Name = "txtEspacoMem";
            this.txtEspacoMem.Size = new System.Drawing.Size(100, 22);
            this.txtEspacoMem.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome do Processo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nome do Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Prioridade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Uso da cpu(%)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Estado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Espaço de memória";
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(333, 303);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 12;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnCancelarFormAdc
            // 
            this.btnCancelarFormAdc.Location = new System.Drawing.Point(414, 303);
            this.btnCancelarFormAdc.Name = "btnCancelarFormAdc";
            this.btnCancelarFormAdc.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarFormAdc.TabIndex = 13;
            this.btnCancelarFormAdc.Text = "Cancelar";
            this.btnCancelarFormAdc.UseVisualStyleBackColor = true;
            this.btnCancelarFormAdc.Click += new System.EventHandler(this.btnCancelarFormAdc_Click);
            // 
            // FormAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 338);
            this.Controls.Add(this.btnCancelarFormAdc);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEspacoMem);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtBoxCPU);
            this.Controls.Add(this.cmbPrioridade);
            this.Controls.Add(this.txtNomeUser);
            this.Controls.Add(this.txtNomeProcesso);
            this.Name = "FormAdicionar";
            this.Text = "Adicionar";
            this.Load += new System.EventHandler(this.FormAdicionar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeProcesso;
        private System.Windows.Forms.TextBox txtNomeUser;
        private System.Windows.Forms.ComboBox cmbPrioridade;
        private System.Windows.Forms.TextBox txtBoxCPU;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtEspacoMem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnCancelarFormAdc;
    }
}