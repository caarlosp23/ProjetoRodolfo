using MongoDB.Bson;
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

            var filter = Builders<Processo>.Filter.Eq(p => p.Id, updateProcesso.Id);
            var update = Builders<Processo>.Update
                .Set(p => p.NomeProcesso, updateProcesso.NomeProcesso)
                .Set(p => p.NomeUsuario, updateProcesso.NomeUsuario)
                .Set(p => p.Prioridade, updateProcesso.Prioridade)
                .Set(p => p.UsoCpu, updateProcesso.UsoCpu)
                .Set(p => p.Estado, updateProcesso.Estado)
                .Set(p => p.Memoria, updateProcesso.Memoria);
        
             _processoCollection.UpdateOne(filter, update);

        }
        public void DeleteProcesso(string idProcesso)
        {
            _processoCollection.DeleteOne(p => p.NomeProcesso == idProcesso.ToString());
     
        }

        
    }
}
