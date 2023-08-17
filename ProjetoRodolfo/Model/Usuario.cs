using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoRodolfo.Model
{
    public class Usuario
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
