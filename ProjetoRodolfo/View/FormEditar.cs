using DnsClient.Protocol;
using MongoDB.Bson;
using ProjetoRodolfo.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoRodolfo.View
{
    public partial class FormEditar : Form
    {
        private readonly ProcessoController _processoController;
        public FormEditar(ObjectId id, string processoOld, string usuarioOld, string proriOld, string cpuOld, string estadoOld, int memoriaOld)
        {
            InitializeComponent();
            CenterToScreen();

            Id = id;
            txtBoxCPU.Text = cpuOld;
            txtEspacoMem.Text = estadoOld;
            txtNomeProcesso.Text = processoOld;
            txtNomeUser.Text = usuarioOld;
            cmbEstado.Text = estadoOld;
            cmbPrioridade.Text = proriOld;
            txtEspacoMem.Text = memoriaOld.ToString();
           
            string connectionString = "mongodb://localhost:27017";
            string database = "ProjetoRodolfo";

            _processoController = new ProcessoController(connectionString,database);



        }
        
        public ObjectId Id { get; set; }

        public string processoOld { get; set; }
        public string usuarioOld { get; set; }
        public string proriOld { get; set; }
        public string cpuOld { get; set; }
        public string estadoOld { get; set; }
        public int memoriaOld { get; set; }


        private void btnInserir_Click(object sender, EventArgs e)
        {

            string processo = txtNomeProcesso.Text;
            string usuario = txtNomeUser.Text;
            string priori = cmbPrioridade.Text;
            string cpu = txtBoxCPU.Text;
            string estado = cmbEstado.Text;
            int memoria = int.Parse(txtEspacoMem.Text);



            _processoController.UpdateProcesso(Id,processo, usuario, priori, cpu, estado, memoria);

            MessageBox.Show("Atualiado com sucesso!");
            this.Close();

        }

        private void FormEditar_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.ColorTranslator.FromHtml("#008BD6");
        }

        private void btnCancelarFormAdc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}