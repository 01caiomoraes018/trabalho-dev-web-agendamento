using Agendamento.Models;
using Agendamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public IActionResult Index() => View(_pacienteService.Listar());

        public IActionResult Inserir() => View(new Paciente());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir([Bind("Nome,Cpf,Telefone,Endereco,DataNascimento")] Paciente paciente)
        {
            if (!ModelState.IsValid) return View(paciente);
            _pacienteService.Inserir(paciente);
            TempData["Mensagem"] = "Paciente cadastrado.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            var paciente = _pacienteService.EncontrarId(id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar([FromRoute] int id, [Bind("Id,Nome,Cpf,Telefone,Endereco,DataNascimento")] Paciente paciente)
        {
            if (id != paciente.Id) return BadRequest();
            var existente = _pacienteService.EncontrarId(id);
            if (existente == null) return NotFound();
            if (!ModelState.IsValid) return View(paciente);

            existente.Nome = paciente.Nome;
            existente.Cpf = paciente.Cpf;
            existente.Telefone = paciente.Telefone;
            existente.Endereco = paciente.Endereco;
            existente.DataNascimento = paciente.DataNascimento;
            _pacienteService.Atualizar(existente);
            TempData["Mensagem"] = "Paciente atualizado.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remover(int id)
        {
            var paciente = _pacienteService.EncontrarId(id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarRemocao([FromRoute] int id)
        {
            var paciente = _pacienteService.EncontrarId(id);
            if (paciente == null) return NotFound();
            _pacienteService.Remover(paciente);
            TempData["Mensagem"] = "Paciente removido.";
            return RedirectToAction(nameof(Index));
        }
    }
}
