using ProjetoRodolfo.Controller;
using ProjetoRodolfo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoRodolfo.View
{
    
    
    public partial class FormAdicionar : Form
    {
        
        public Button btnInserirr;
        public FormAdicionar()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            string connectionString = "mongodb://localhost:27017";
            string database = "ProjetoRodolfo";

            ProcessoController processoController = new ProcessoController(connectionString, database);

            string processo = txtNomeProcesso.Text;
            string usuario = txtNomeUser.Text;
            string prioridadem = cmbPrioridade.Text;
            string usoDaCpu = txtBoxCPU.Text;
            string nomeEstado = cmbEstado.Text;
            int memoriaMaquina = int.Parse(txtEspacoMem.Text);



            Processo newProcesso = new Processo
            {
                NomeProcesso = processo,
                NomeUsuario = usuario,
                Prioridade = prioridadem,
                UsoCpu = usoDaCpu,
                Estado= nomeEstado,
                Memoria = memoriaMaquina
                
            };

            processoController.AddProcesso(newProcesso);

            MessageBox.Show("Processo inserido com sucesso!");

            this.Close();
        }

        private void FormAdicionar_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            BackColor = System.Drawing.ColorTranslator.FromHtml("#008BD6");
        }

        private void btnCancelarFormAdc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
