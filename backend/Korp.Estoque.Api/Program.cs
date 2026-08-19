// Importa os métodos de extensão do Entity Framework Core (como .UseSqlite)
using Microsoft.EntityFrameworkCore;

// Importa a camada de dados para dar acesso à classe EstoqueDbContext
using Korp.Estoque.Api.Data;

// Cria o construtor da aplicação (builder), iniciando a fase de configuração e registro de serviços
var builder = WebApplication.CreateBuilder(args);

// 1. INJEÇÃO DE DEPENDÊNCIA DO BANCO DE DADOS:
// Registra o EstoqueDbContext no contêiner de serviços (Dependency Injection).
// Lê a connection string 'DefaultConnection' do appsettings.json e configura o provedor do SQLite.
builder.Services.AddDbContext<EstoqueDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. REGISTRO DE CONTROLADORES E DOCUMENTAÇÃO:
// Registra o suporte para Controllers baseados em classes (arquitetura MVC / Web API)
builder.Services.AddControllers();

// Mapeia os metadados dos endpoints para a geração da especificação OpenAPI
builder.Services.AddEndpointsApiExplorer();

// Registra o gerador da interface interativa do Swagger
builder.Services.AddSwaggerGen();

// FINALIZAÇÃO DO BUILDER:
// Encerra a fase de configuração de serviços e constrói a instância executável da aplicação (app)
var app = builder.Build();

// 3. PIPELINE DE REQUISIÇÕES HTTP (MIDDLEWARES):
// Se a aplicação estiver rodando em ambiente de desenvolvimento local, ativa a interface visual do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware que valida permissões de segurança antes da execução das rotas
app.UseAuthorization();

// Mapeia e direciona as URLs recebidas via HTTP para os seus respectivos Controllers
app.MapControllers();

// Inicializa o servidor web Kestrel e coloca a API em execução contínua escutando na porta HTTP
app.Run();