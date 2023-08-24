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
        private formProcessos tes_;
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

           
        }
    }
}
