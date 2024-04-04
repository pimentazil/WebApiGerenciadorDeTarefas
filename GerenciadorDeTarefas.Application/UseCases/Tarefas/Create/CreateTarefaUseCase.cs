using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Repository.Models;
using GerenciadorDeTarefas.Repository;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefas.Create
{
    public class CreateTarefaUseCase
    {
        private readonly Context _ctx;

        public CreateTarefaUseCase(Context context)
        {
            _ctx = context;
        }

        public bool adicionarTarefa(RequestTarefaJson request)
        {
            try
            {
                var tarefa = new TabTarefas()
                {
                    nome = request.nome,
                    descricao = request.descricao,
                    prioridade = request.prioridade,
                    prazo = request.prazo,
                    status = request.status,
                };

                _ctx.tabTarefas.Add(tarefa);
                _ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}