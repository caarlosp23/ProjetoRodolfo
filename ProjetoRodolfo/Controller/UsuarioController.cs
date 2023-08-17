using ProjetoRodolfo.Model;
using ProjetoRodolfo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRodolfo.Controller
{
    public class UsuarioController
    {
        private UsuarioRepository _usuarioRepository;

        public UsuarioController(string connectionString, string dataBase)
        {
            _usuarioRepository = new UsuarioRepository(connectionString, dataBase); ;
        }

        public Usuario autenticarUsuario (string login, string senha)
        {
            Usuario usuario = _usuarioRepository.GetPorUsuario(login);

            if (usuario != null && usuario.Senha == senha) {
            return usuario;
            }
            return null;
        }

        public void RegisterUser(Usuario novoUsuario)
        {
            
            _usuarioRepository.AddUser(novoUsuario);
        }

    }
}
