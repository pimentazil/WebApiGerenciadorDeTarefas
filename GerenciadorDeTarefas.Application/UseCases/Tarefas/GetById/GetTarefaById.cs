using GerenciadorDeTarefas.Repository;
using GerenciadorDeTarefas.Repository.Models;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefas.GetById
{
    public class GetTarefaById
    {
        private readonly Context _ctx;

        public GetTarefaById(Context context)
        {
            _ctx = context;
        }

        public TabTarefas obterTarefa(int id)
        {
            try
            {
                return _ctx.tabTarefas.FirstOrDefault(x => x.id == id);
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
