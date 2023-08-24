using MongoDB.Driver;
using ProjetoRodolfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRodolfo.Repository
{
    public class ProcessoRepository
    {

        private IMongoCollection<Processo> _processoCollection;


        public ProcessoRepository(string connectionString, string dataBase)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dataBase);
            _processoCollection = database.GetCollection<Processo>("Processo");

        }


       
        public List<Processo> GetAllProcessos()
        {
            return _processoCollection.Find(_ => true).ToList();
        }

        public Processo GetProcesso(string processoConsulta)
        {
            return _processoCollection.Find(processo => processo.NomeProcesso == processoConsulta).FirstOrDefault();
        }

        public void AddProcesso(Processo newProcesso)
        {
            _processoCollection.InsertOne(newProcesso);
        }
        public void UpdateProcesso(Processo updateProcesso)
        {
           
        }
        public void DeleteProcesso(Processo newProceso)
        {
            
        }
    }
}
