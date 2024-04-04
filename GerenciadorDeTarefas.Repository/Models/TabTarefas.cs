namespace GerenciadorDeTarefas.Repository.Models
{
    public class TabTarefas
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string prioridade { get; set; }
        public DateTime prazo { get; set; }
        public string status { get; set; }
    }
}
