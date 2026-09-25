# Trabalho 1 - Desenvolvimento Web com .NET

Cadastro de pacientes acrescentado ao projeto [Agendamento do professor Lucas Teodoro](https://github.com/teodorolucaas/DesenvolvimentoWebDotNet/tree/main/Agendamento). O cadastro de médicos e a organização MVC das aulas foram preservados.

## Funcionalidades

- Paciente com nome, CPF, telefone, endereço e data de nascimento.
- Validações por Data Annotations, com mensagens nos formulários. CPF validado quanto ao formato; não consulta cadastro nem verifica dígitos verificadores.
- Migrations do EF Core para PostgreSQL e seeding com dois pacientes fictícios.
- Telas para listar, inserir, editar e confirmar a remoção de pacientes.

Os dados iniciais, inclusive documentos e contatos, são fictícios para demonstração.

## Executar

Requisitos: SDK .NET 9 e PostgreSQL. Crie um banco chamado `agendamento_trabalho_web` no pgAdmin. Na pasta raiz deste repositório, abra o PowerShell:

```powershell
$env:ConnectionStrings__DefaultConnection = 'Host=localhost;Port=5432;Database=agendamento_trabalho_web;Username=postgres;Password=SUA_SENHA'
dotnet restore Agendamento/Agendamento.csproj
dotnet run --project Agendamento -- --migrar
dotnet run --project Agendamento --launch-profile http
```

Substitua `SUA_SENHA` somente no seu terminal. O projeto não contém a senha real. A conexão por variável de ambiente vale apenas para esse terminal.

Abra http://localhost:5169/Paciente. As migrations são aplicadas com `--migrar`; ao iniciar no perfil de desenvolvimento, o seeding insere dados somente se a respectiva tabela estiver vazia. Para encerrar, pressione Ctrl+C.

## Conferência

Compilação sem erros ou avisos. Testados cadastro, edição e remoção com persistência no banco, campos obrigatórios, tamanhos e formatos inválidos, datas inválidas, identificadores inexistentes e proteção antiforgery. As páginas de médicos continuam acessíveis.
