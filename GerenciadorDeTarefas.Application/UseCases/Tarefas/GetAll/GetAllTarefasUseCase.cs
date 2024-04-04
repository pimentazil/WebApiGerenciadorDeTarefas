using GerenciadorDeTarefas.Repository;
using GerenciadorDeTarefas.Repository.Models;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefas.GetAll
{
    public class GetAllTarefasUseCase
    {
        private readonly Context _ctx;

        public GetAllTarefasUseCase(Context ctx)
        {
            _ctx = ctx;
        }

        public List<TabTarefas> obterTarefas()
        {
            try
            {
                List<TabTarefas> tarefa = new List<TabTarefas>();
                var tarefas = _ctx.tabTarefas.ToList();
                foreach (var item in tarefas)
                {

                    tarefa.Add(new TabTarefas
                    {
                        id = item.id,
                        nome = item.nome,
                        descricao = item.descricao,
                        prioridade = item.prioridade,
                        prazo = item.prazo,
                        status = item.status    
                    });
                }
                return tarefa;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
