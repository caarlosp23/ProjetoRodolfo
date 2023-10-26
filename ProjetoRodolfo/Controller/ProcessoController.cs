using MongoDB.Bson;
using ProjetoRodolfo.Model;
using ProjetoRodolfo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRodolfo.Controller
{
    public class ProcessoController
    {
        private ProcessoRepository _processoRepository;

        public ProcessoController(string connectionString, string dataBase)
        {
            _processoRepository = new ProcessoRepository(connectionString, dataBase); ;
        }

       
        public void AddProcesso(Processo novoProcesso)
        {

            _processoRepository.AddProcesso(novoProcesso);
        }
        public Processo GetProcesso(string novoProcesso)
        {

            return _processoRepository.GetProcesso(novoProcesso);
        }

     
        public void UpdateProcesso(ObjectId id,string nomeProcesso, string novoUser, string nPriori, string nUso, string nEstado, int nMememoria)
        {


            var processo = new Processo
            {
                    Id = id,
                    NomeProcesso = nomeProcesso,
                    NomeUsuario = novoUser,
                    Prioridade = nPriori,
                    UsoCpu = nUso,
                    Estado = nEstado,
                    Memoria= nMememoria
                };

                _processoRepository.UpdateProcesso(processo);
           
        }
        public void DeleteProcesso(string processo)
        {

            _processoRepository.DeleteProcesso(processo);
        }

        public void DeleteTermino(string processo)
        {

            _processoRepository.DeleteTermino(processo);
        }

        public List<Processo> GetAllProcessos()
        {
            return _processoRepository.GetAllProcessos();
        }

    }
}
