using GerenciadorDeTarefas.Repository;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefas.Delete
{
    public class DeleteTarefaUseCase
    {
        private readonly Context _ctx;

        public DeleteTarefaUseCase (Context context)
        {
            _ctx = context;
        }

        public bool deletarTarefa(int tarefaId)
        {
            try
            {
                var tarefa = _ctx.tabTarefas.Find(tarefaId);

                if (tarefa != null)
                {
                    _ctx.tabTarefas.Remove(tarefa);
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
