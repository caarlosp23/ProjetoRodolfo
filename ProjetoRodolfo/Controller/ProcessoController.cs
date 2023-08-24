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
        public void GetProcesso(Processo novoProcesso)
        {

            _processoRepository.AddProcesso(novoProcesso);
        }

     
        public void UpdateProcesso(Processo novoProcesso)
        {

            _processoRepository.AddProcesso(novoProcesso);
        }
        public void DeleteProcesso(Processo novoProcesso)
        {

            _processoRepository.AddProcesso(novoProcesso);
        }

    }
}
