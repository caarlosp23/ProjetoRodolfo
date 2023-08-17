using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjetoRodolfo
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "mongodb://localhost:27017";
            string database = "ProjetoRodolfo";

            UsuarioController usuarioController = new UsuarioController(connectionString, database);

            string usuario = txtUser.Text;
            string senha = txtSenha.Text;
            

            Usuario user = usuarioController.autenticarUsuario(usuario, senha);

            if (user !=null)
            {
                MessageBox.Show("Login efetuado com sucesso");
            } else
            {
                MessageBox.Show("Usuario ou senha incorretas");
            }



        }

        private void button1_Click(object sender, EventArgs e)

        {

            string connectionString = "mongodb://localhost:27017";
            string database = "ProjetoRodolfo";

            UsuarioController usuarioController = new UsuarioController(connectionString, database);

            string usuario = txtUser.Text;
            string senha = txtSenha.Text;

            

            Usuario newUser = new Usuario
            {
                Nome = usuario,
                Senha = senha
            };

            usuarioController.RegisterUser(newUser);
            MessageBox.Show("Novo usuário registrado com sucesso!");
        }
        
    }
}
