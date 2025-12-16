📅 Agendamento de Eventos

Projeto ASP.NET MVC para gerenciamento de eventos e locais, utilizando Entity Framework Core, SQL Server, Repository Pattern e Injeção de Dependência.

**📌 Visão Geral**

O sistema permite:

Cadastro, edição, visualização e exclusão de Eventos

Cadastro e gerenciamento de Locais

Associação de eventos a locais

Exibição do nome do local nos eventos

Busca dinâmica (frontend) por nome do evento, local ou CEP

O projeto segue o padrão MVC (Model–View–Controller), separando responsabilidades e facilitando manutenção e evolução.

**🛠️ Tecnologias Utilizadas**

ASP.NET Core MVC

Entity Framework Core

SQL Server

C#

JavaScript (busca dinâmica na View)

HTML / CSS

**🧱 Arquitetura do Projeto**

O projeto utiliza:

MVC para organização da aplicação

Repository Pattern para acesso a dados

Dependency Injection (DI) para desacoplamento

🗄️ **Banco de Dados**

🧾 *Tabela Eventos*

IdEvento (PK)
Nome_Evento
Descricao
Data_Inicial
Data_Final
Local (FK – IdLocal)
Status

🧾 *Tabela Locais*

IdLocal (PK)
Nome
Cep

🔹 Campo Especial: NomeLocal
[NotMapped]
public string? NomeLocal { get; set; }

Não é criado no banco de dados

Usado apenas para exibição na View

Preenchido no Controller após associação com Locais

🔌 **Injeção de Dependência**

Configurada no arquivo Program.cs:

builder.Services.AddDbContext<DbContextEventos>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IEventosRepository, EventosRepository>();
builder.Services.AddScoped<ILocaisRepository, LocaisRepository>();

Isso permite que Controllers utilizem Repositories sem criar instâncias manualmente.

🔎 **Funcionalidade de Busca (Frontend)**

A busca por nome do evento, nome do local ou CEP é feita na View, usando JavaScript:

Funciona em memória (dados já carregados)

Não faz consulta ao banco

Utiliza o atributo HTML data-search

Exemplo:

<div class="evento-card" data-search="evento x auditório central 27250000"></div>
document.getElementById('searchInput').addEventListener('input', function(e) {
    const searchTerm = e.target.value.toLowerCase();
    const cards = document.querySelectorAll('.evento-card');


    cards.forEach(card => {
        const searchData = card.getAttribute('data-search');
        card.style.display = searchData.includes(searchTerm) ? 'block' : 'none';
    });
});


🎯 Objetivo do Projeto

Projeto desenvolvido com foco em:

Aprendizado de ASP.NET MVC

Uso correto de Entity Framework Core

Separação de responsabilidades

Boas práticas de backend


Projeto desenvolvido para fins de estudo e prática em desenvolvimento web com .NET.
