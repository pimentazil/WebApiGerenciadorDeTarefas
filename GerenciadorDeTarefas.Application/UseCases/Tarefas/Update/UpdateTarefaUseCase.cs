using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Repository;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefas.Update
{
    public class UpdateTarefaUseCase
    {
        private readonly Context _ctx;

        public UpdateTarefaUseCase(Context context)
        {
            _ctx = context;
        }

        public bool atualizarTarefa(int tarefaId, RequestTarefaJson request)
        {
            try
            {
                var tarefa = _ctx.tabTarefas.Find(tarefaId);

                if (tarefa != null)
                {
                    tarefa.nome = request.nome;
                    tarefa.descricao = request.descricao;
                    tarefa.prioridade = request.prioridade;
                    tarefa.prazo = request.prazo;
                    tarefa.status = request.status;

                    _ctx.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
