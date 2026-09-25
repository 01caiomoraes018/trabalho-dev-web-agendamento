using Agendamento.Models;

namespace Agendamento.Data
{
    public class SeedingService
    {
        // Declara uma referência para o contexto do banco de dados.
        // O AppDbContext permite consultar, adicionar, atualizar e remover registros.
        // O modificador readonly impede que essa referência seja substituída
        // depois que o objeto SeedingService for construído.
        private readonly AppDbContext _context;

        // O AppDbContext é recebido pelo construtor por meio da
        // injeção de dependência (DI).
        // O ASP.NET Core cria a instância configurada do AppDbContext
        // e a fornece automaticamente quando cria o SeedingService.
        public SeedingService(AppDbContext context)
        {
            // Armazena a instância recebida para que ela possa ser utilizada
            // pelos outros métodos da classe.
            _context = context;
        }

        // Popula o banco de dados com os registros iniciais.
        public void Popula()
        {
            // Dados fictícios de demonstração, independentes do cadastro de médicos.
            if (!_context.Pacientes.Any())
            {
                _context.Pacientes.AddRange(
                    new Paciente { Nome = "Caio Moraes", Cpf = "111.111.111-11", Telefone = "(11) 90000-0001", Endereco = "Rua Exemplo, 10", DataNascimento = new DateOnly(2000, 5, 15) },
                    new Paciente { Nome = "Ana Exemplo", Cpf = "222.222.222-22", Telefone = "(11) 90000-0002", Endereco = "Rua Exemplo, 20", DataNascimento = new DateOnly(1995, 8, 20) });
                _context.SaveChanges();
            }

            // Utiliza o contexto para consultar a tabela Medicos.
            // Any() retorna true quando a tabela já possui pelo menos um registro.
            if (_context.Medicos.Any())
            {
                // Encerra o método para evitar a inserção de dados duplicados.
                return;

            }
            else
            {
                // Cria o primeiro objeto que será inserido no banco.
                Medico m1 = new Medico
                {
                    Nome = "Luiza",
                    Crm = "123456",
                    Especialidade = "Vascular"
                };

                // Cria o segundo objeto que será inserido no banco.
                Medico m2 = new Medico
                {
                    Nome = "João",
                    Crm = "456789",
                    Especialidade = "Ortopedista"
                };

                // Adiciona os dois médicos ao contexto de uma única vez.
                // Mas ainda não salva no banco de dados
                _context.Medicos.AddRange(m1, m2);

                // Confirma as alterações pendentes.
                // O EF Core gera e executa os comandos INSERT no banco de dados.
                _context.SaveChanges();

            }
        }
    }
}
