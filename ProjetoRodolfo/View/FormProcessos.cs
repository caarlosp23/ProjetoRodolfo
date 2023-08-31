using MongoDB.Bson;
using ProjetoRodolfo.Controller;
using ProjetoRodolfo.Model;
using ProjetoRodolfo.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ProjetoRodolfo.View
{
    public partial class formProcessos : Form
    {
        private ProcessoController _processoController;
        public formProcessos()
        {
            InitializeComponent();
            CenterToScreen();


        }

        private void FormProcessos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void Processos_Load(object sender, EventArgs e)
        {
           
            BackColor = System.Drawing.ColorTranslator.FromHtml("#008BD6");
            string connectionString = "mongodb://localhost:27017";
            string database = "ProjetoRodolfo";

            _processoController = new ProcessoController(connectionString, database);

            dtGridProcessos.ColumnCount = 7;

            dtGridProcessos.Columns[0].Name = "Id";
            dtGridProcessos.Columns[1].Name = "Nome do Processo";
            dtGridProcessos.Columns[2].Name = "Memoria (Mbs)";
            dtGridProcessos.Columns[3].Name = "Uso da CPU (%)";
            dtGridProcessos.Columns[4].Name = "Nome do Usuario";
            dtGridProcessos.Columns[5].Name = "Prioridade";
            dtGridProcessos.Columns[6].Name = "Estado";


           
            LoadProcessosToDataGridView();

            //dtGridProcessos.CellClick += dtGridProcessos_CellClick;
            //dtGridProcessos.SelectionMode = DataGridViewSelectionMode.CellSelect; // Modo de seleção de célula
            //dtGridProcessos.MultiSelect = false;
        }

        private void dtGridProcessos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtGridProcessos.Rows.Count)
            {
                dtGridProcessos.Rows[e.RowIndex].Selected = true;
            }

            
        }

        public void LoadProcessosToDataGridView()
        {
            this.dtGridProcessos.Columns["Id"].Visible = false;
            List<Processo> processos = _processoController.GetAllProcessos();

            // Limpar os dados existentes no DataGridView
            dtGridProcessos.Rows.Clear();

            // Preencher o DataGridView com os dados dos processos
            foreach (Processo processo in processos)
            {
                dtGridProcessos.Rows.Add(processo.Id,processo.NomeProcesso,processo.Memoria, processo.UsoCpu, processo.NomeUsuario, processo.Prioridade, processo.Estado);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //FormAdicionar X = new FormAdicionar();
            //X.Show();
            using (var form = new FormAdicionar())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProcessosToDataGridView();
                }
                LoadProcessosToDataGridView();
            }
            
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            //FormEditar X = new FormEditar();
            //X.Show();

            if (dtGridProcessos.SelectedRows.Count > 0)
            {
                var selectedRow = dtGridProcessos.SelectedRows[0];

                string id = selectedRow.Cells["Id"].Value.ToString();
                string nome = selectedRow.Cells["Nome do Processo"].Value.ToString();
                int memoria = int.Parse(selectedRow.Cells["Memoria (Mbs)"].Value.ToString());
                string cpu = selectedRow.Cells["Uso da CPU (%)"].Value.ToString();
                string nomeUsuario = selectedRow.Cells["Nome do Usuario"].Value.ToString();
                string prioridade = selectedRow.Cells["Prioridade"].Value.ToString();
                string estado = selectedRow.Cells["Estado"].Value.ToString();


                using (var form2 = new FormEditar(ObjectId.Parse(id), nome, nomeUsuario, prioridade, cpu, estado,memoria))
                {
                    form2.Id = ObjectId.Parse(id);
                    form2.processoOld = nome;
                    form2.memoriaOld = memoria;
                    form2.cpuOld = cpu;
                    form2.usuarioOld = nomeUsuario;
                    form2.proriOld = prioridade;
                    form2.estadoOld = estado;


                    if (form2.ShowDialog() == DialogResult.OK)
                    {
                        LoadProcessosToDataGridView();
                    }
                }
            }
            LoadProcessosToDataGridView();
        }

        private void dtGridProcessos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Verifica se não é um cabeçalho de coluna ou linha
            //{
            //    dtGridProcessos.CurrentCell = dtGridProcessos.Rows[e.RowIndex].Cells[e.ColumnIndex]; // Define a célula atual
            //    dtGridProcessos.BeginEdit(true); // Inicia a edição da célula (o que também a seleciona)
            //}

            if (e.RowIndex >= 0 && e.RowIndex < dtGridProcessos.Rows.Count)
            {
                dtGridProcessos.Rows[e.RowIndex].Selected = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadProcessosToDataGridView();
            txtBoxPesquisa.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busca =txtBoxPesquisa.Text;
            Processo x = new Processo();

            x = _processoController.GetProcesso(busca);
            dtGridProcessos.Rows.Clear();
            dtGridProcessos.Rows.Add(x.Id,x.NomeProcesso, x.Memoria, x.UsoCpu, x.NomeUsuario, x.Prioridade, x.Estado);
        }

        private void button4_Click(object sender, EventArgs e)
        {
          

                if (dtGridProcessos.SelectedRows.Count > 0)
                {
                    var selectedRow = dtGridProcessos.SelectedRows[0];
                    string objectIdStr = selectedRow.Cells["Nome do Processo"].Value.ToString(); // Obter o valor do ID como string
                    if (objectIdStr!= null)
                    {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja excluir o processo?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                       _processoController.DeleteProcesso(objectIdStr.ToString());
                        LoadProcessosToDataGridView();


                    }
                    
                        
                    }
                    else
                    {
                        MessageBox.Show("ID inválido.");
                    }
                }
            
        }
    }
}


