using GerenciadorDeTarefas.Application.UseCases.Tarefas.Create;
using GerenciadorDeTarefas.Application.UseCases.Tarefas.Delete;
using GerenciadorDeTarefas.Application.UseCases.Tarefas.GetAll;
using GerenciadorDeTarefas.Application.UseCases.Tarefas.GetById;
using GerenciadorDeTarefas.Application.UseCases.Tarefas.Update;
using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Repository;
using Microsoft.AspNetCore.Mvc;


namespace GerenciadorDeTarefas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {

        private readonly Context _ctx;
        public TarefasController(Context ctx)
        {
            _ctx = ctx;
        }


        [HttpPost]
        [Route("[action]")]

        public IActionResult adicionarTarefa([FromBody] RequestTarefaJson request)
        {

            try
            {
                var tarefaService = new CreateTarefaUseCase(_ctx);
                var resultado = tarefaService.adicionarTarefa(request);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Ocorreu um erro ao processar a solicitação.", detalhes = ex.Message });
            }
        }

        [HttpGet]
        
        public IActionResult obterTarefas() 
        {
            var tarefaService = new GetAllTarefasUseCase(_ctx);
            return Ok(tarefaService.obterTarefas());
        }


        [HttpGet]
        [Route("[action]/{id}")]

        public IActionResult obterTarefa(int id)
        {
            var tarefaService = new GetTarefaById(_ctx);
            return Ok(tarefaService.obterTarefa(id));
        }


        [HttpPut]
        [Route("[action]/{id}")]

        public IActionResult atualizarTarefa(int id, [FromBody] RequestTarefaJson request) 
        { 
            var tarefaService = new UpdateTarefaUseCase(_ctx);
            var sucesso = tarefaService.atualizarTarefa(id, request);

            if (sucesso)
            {
                return Ok("Tarefa atualizada com sucesso");
            }
            else
            {
                return BadRequest("Falha ao atualizar a tarefa! ");
            }
        }


        [HttpDelete]
        [Route("[action]/{id}")]

        public IActionResult deletarTarefa(int id)
        {
            var tarefaService = new DeleteTarefaUseCase(_ctx);
            var sucesso = tarefaService.deletarTarefa(id);

            if (sucesso)
            {
                return Ok("Tarefa deletada com sucesso!");
            }
            else
            {
                return BadRequest("Falha ao deletar o livro");
            }
        }


    }
}
