using MongoDB.Driver;
using ProjetoRodolfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRodolfo.Repository
{
    public class UsuarioRepository
    {

        private IMongoCollection<Usuario> _userCollection;


        public UsuarioRepository(string connectionString, string dataBase)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dataBase);
            _userCollection = database.GetCollection<Usuario>("Usuario");

        }

        public Usuario GetPorUsuario (string usuarioConsulta)
        {
            return _userCollection.Find(usuario => usuario.Nome == usuarioConsulta).FirstOrDefault();
        }

        public void AddUser(Usuario newUser)
        {
            _userCollection.InsertOne(newUser);
        }
    }
}
