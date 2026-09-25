using Agendamento.Data;
using Agendamento.Models;

namespace Agendamento.Services
{
    public class PacienteService
    {
        private readonly AppDbContext _context;

        public PacienteService(AppDbContext context)
        {
            _context = context;
        }

        public List<Paciente> Listar() => _context.Pacientes.OrderBy(p => p.Nome).ToList();

        public Paciente? EncontrarId(int id) => _context.Pacientes.Find(id);

        public void Inserir(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public void Atualizar(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }

        public void Remover(Paciente paciente)
        {
            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
        }
    }
}
