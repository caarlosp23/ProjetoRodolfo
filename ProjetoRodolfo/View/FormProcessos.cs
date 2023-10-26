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
using System.Threading;
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

            //ProcessoExecucao();


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

        private async Task DelayAsync(int milliseconds)
        {
            await Task.Delay(milliseconds);
        }

        public async void ProcessoExecucao()
        {
            var pegaProcessos = _processoController.GetAllProcessos();

            alteraEstado();
            

        }

        public async void alteraEstado()

        {
            
                    var espera = GetEspera();
                    var inicio = GetInicio();

                    if (espera != null)
                    {
                        _processoController.UpdateProcesso(espera.Id, espera.NomeProcesso, espera.NomeUsuario, espera.Prioridade, espera.UsoCpu, espera.Estado = "PRONTO", espera.Memoria);
                    }

                if (inicio != null)
                {
                _processoController.UpdateProcesso(inicio.Id, inicio.NomeProcesso, inicio.NomeUsuario, inicio.Prioridade, inicio.UsoCpu, inicio.Estado = "PRONTO", inicio.Memoria);
                }

            var execucao = GetExec();
                    if (execucao == null)
                    {
                        var pronto = GetPronto();
                        pronto.Estado = "EXECUÇÃO";
                        _processoController.UpdateProcesso(pronto.Id, pronto.NomeProcesso, pronto.NomeUsuario, pronto.Prioridade, pronto.UsoCpu, pronto.Estado, pronto.Memoria);

                        btnListar.PerformClick();
                             DelayAsync(5000);
                    }
                    else
                    {
                        string[] estados = { "PRONTO", "ESPERA", "TERMINO" };
                        var pronto = GetPronto();
                        execucao.Estado = GerarNomeAleatorio(estados);

                        if (execucao.Estado == "TERMINO")
                        {
                            _processoController.DeleteProcesso(execucao.NomeProcesso);
                            criaProcesso();
                            //_processoController.UpdateProcesso(pronto.Id, pronto.NomeProcesso, pronto.NomeUsuario, pronto.Prioridade, pronto.UsoCpu, pronto.Estado = "EXECUÇÃO", pronto.Memoria);
                            btnListar.PerformClick();
                            DelayAsync(5000);
                        }
                        else
                        {
                            _processoController.UpdateProcesso(execucao.Id, execucao.NomeProcesso, execucao.NomeUsuario, execucao.Prioridade, execucao.UsoCpu, execucao.Estado, execucao.Memoria);
                            _processoController.UpdateProcesso(pronto.Id, pronto.NomeProcesso, pronto.NomeUsuario, pronto.Prioridade, pronto.UsoCpu, pronto.Estado = "EXECUÇÃO", pronto.Memoria);
                            btnListar.PerformClick();
                            DelayAsync(5000);
                         }
                    }

    }

        public void criaProcesso()
        {
            Random x = new Random();

             string[] processos = { "Editor", "Calculadora", "Navegador", "Terminal", "Jogo" };
             string[] usuarios = { "Alice", "Bob", "Charlie", "David", "Eve" };
             string[] prioridades = { "ALTA", "MÉDIA", "BAIXA" };
             int memoria = x.Next(256, 8192);

            var nProcessosTela = _processoController.GetAllProcessos();

            if(nProcessosTela.Count() < 10)
            {
                var processo = new Processo
                {

                    NomeProcesso = GerarNomeAleatorio(processos),
                    NomeUsuario = GerarNomeAleatorio(usuarios),
                    Prioridade = GerarNomeAleatorio(prioridades),
                    UsoCpu = $"{x.Next(0, 101)}%",
                    Estado = "INICIO",
                    Memoria = memoria
                };
                _processoController.AddProcesso(processo);
                LoadProcessosToDataGridView();
            }
            
        }

        public string GerarNomeAleatorio(string[] opcoes)
        {
            Random x = new Random();
            int indiceAleatorio = x.Next(opcoes.Length);
            return opcoes[indiceAleatorio];
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

           // ProcessoExecucao();
        }

        private async void btnAdicionar_Click(object sender, EventArgs e)
        {


            await RunLoopAsync();
            
            
            
        }

        private async Task RunLoopAsync()
        {
            while (true)
            {
                ProcessoExecucao();

                // Aguarde um pequeno intervalo para evitar uso intensivo da CPU
                await Task.Delay(2000);
            }
        }
        public Processo GetPronto()
        {
            var processosProntos = _processoController.GetAllProcessos().Where(p => p.Estado == "PRONTO").ToList();

            if (processosProntos.Count > 0)
            {
                // Ordene os processos prontos por alguma lógica, se necessário
                // Aqui, estou assumindo uma ordem aleatória
                Random random = new Random();
                int indiceAleatorio = random.Next(processosProntos.Count);
                return processosProntos[indiceAleatorio];
            }

            return null;
        }

        public Processo GetInicio()
        {
            var processosProntos = _processoController.GetAllProcessos().Where(p => p.Estado == "INICIO").ToList();

            if (processosProntos.Count > 0)
            {
                // Ordene os processos prontos por alguma lógica, se necessário
                // Aqui, estou assumindo uma ordem aleatória
                Random random = new Random();
                
                return processosProntos[0];
            }

            return null;
        }
        public Processo GetExec()
        {
            var processosProntos = _processoController.GetAllProcessos().Where(p => p.Estado == "EXECUÇÃO").ToList();

            if (processosProntos.Count > 0)
            {
                // Ordene os processos prontos por alguma lógica, se necessário
                // Aqui, estou assumindo uma ordem aleatória
                Random random = new Random();
                int indiceAleatorio = random.Next(processosProntos.Count);
                return processosProntos[0];
            }

            return null;
        }

        public Processo GetEspera()
        {
            var processosProntos = _processoController.GetAllProcessos().Where(p => p.Estado == "ESPERA").ToList();

            if (processosProntos.Count > 0)
            {
                // Ordene os processos prontos por alguma lógica, se necessário
                // Aqui, estou assumindo uma ordem aleatória
                Random random = new Random();
                int indiceAleatorio = random.Next(processosProntos.Count);
                return processosProntos[indiceAleatorio];
            }

            return null;
        }
        


        public bool HasMoreProcessesReady()
        {
            return _processoController.GetAllProcessos().Any(p => p.Estado == "PRONTO");
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


