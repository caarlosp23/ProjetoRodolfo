namespace ProjetoRodolfo.View
{
    partial class formProcessos
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
            this.dtGridProcessos = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtBoxPesquisa = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridProcessos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridProcessos
            // 
            this.dtGridProcessos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtGridProcessos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridProcessos.Location = new System.Drawing.Point(12, 107);
            this.dtGridProcessos.Name = "dtGridProcessos";
            this.dtGridProcessos.RowHeadersWidth = 51;
            this.dtGridProcessos.RowTemplate.Height = 24;
            this.dtGridProcessos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridProcessos.Size = new System.Drawing.Size(879, 414);
            this.dtGridProcessos.TabIndex = 0;
            this.dtGridProcessos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridProcessos_CellContentClick);
            this.dtGridProcessos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridProcessos_CellContentClick);
            this.dtGridProcessos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtGridProcessos_CellFormatting);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(327, 56);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(12, 12);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(87, 23);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(816, 56);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 3;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(105, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Excluir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtBoxPesquisa
            // 
            this.txtBoxPesquisa.Location = new System.Drawing.Point(12, 57);
            this.txtBoxPesquisa.Name = "txtBoxPesquisa";
            this.txtBoxPesquisa.Size = new System.Drawing.Size(309, 22);
            this.txtBoxPesquisa.TabIndex = 5;
            this.txtBoxPesquisa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Editar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formProcessos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 541);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBoxPesquisa);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtGridProcessos);
            this.Name = "formProcessos";
            this.Text = "Processos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormProcessos_FormClosed);
            this.Load += new System.EventHandler(this.Processos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridProcessos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridProcessos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtBoxPesquisa;
        private System.Windows.Forms.Button button1;
    }
}