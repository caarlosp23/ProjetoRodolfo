using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRodolfo.Model
{
    public class Processo
    {
        public ObjectId Id { get; set; }
        public string NomeProcesso { get; set; }
        public string NomeUsuario { get; set; }
        public string Prioridade { get; set; }
        public string UsoCpu { get; set; }
        public string Estado { get; set; }
        public int Memoria { get; set; }
    }
}
