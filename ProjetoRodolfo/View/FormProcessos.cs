using ProjetoRodolfo.Model;
using ProjetoRodolfo.Repository;
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
    public partial class formProcessos : Form
    {
        private ProcessoRepository _processoRepository;
        public formProcessos()
        {
            InitializeComponent();

        }

        private void FormProcessos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void Processos_Load(object sender, EventArgs e)
        {
            string connectionString = "mongodb://localhost:27017";
            string database = "ProjetoRodolfo";

            _processoRepository = new ProcessoRepository(connectionString, database);

            dtGridProcessos.ColumnCount = 6; 

            dtGridProcessos.Columns[0].Name = "Nome do Processo";
            dtGridProcessos.Columns[1].Name = "Memoria (Mbs)";
            dtGridProcessos.Columns[2].Name = "Uso da CPU (%)";
            dtGridProcessos.Columns[3].Name = "Nome do Usuario";
            dtGridProcessos.Columns[4].Name = "Prioridade";
            dtGridProcessos.Columns[5].Name = "Estado";


           
            LoadProcessosToDataGridView();
        }

        private void dtGridProcessos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadProcessosToDataGridView()
        {
            List<Processo> processos = _processoRepository.GetAllProcessos();

            // Limpar os dados existentes no DataGridView
            dtGridProcessos.Rows.Clear();

            // Preencher o DataGridView com os dados dos processos
            foreach (Processo processo in processos)
            {
                dtGridProcessos.Rows.Add(processo.NomeProcesso,processo.Memoria, processo.UsoCpu, processo.NomeUsuario, processo.Prioridade, processo.Estado);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FormAdicionar X = new FormAdicionar();
            X.Show();
        }
    }

}
