// Importa o namespace do Entity Framework Core (ORM), fornecendo DbContext, DbSet e ferramentas de persistência
using Microsoft.EntityFrameworkCore;

// Importa o namespace das entidades de domínio para permitir o mapeamento da classe Produto
using Korp.Estoque.Api.Entities;

// Namespace: Reflete a estrutura física de pastas da camada de acesso a dados (Korp.Estoque.Api > Data)
namespace Korp.Estoque.Api.Data;

// Classe de Contexto: Herda de DbContext para representar a sessão com o banco de dados SQLite e gerenciar as operações de banco
public class EstoqueDbContext : DbContext
{
    // Construtor: Recebe as opções de configuração do banco (driver SQLite e Connection String) via Injeção de Dependência
    // ': base(options)' repassa essas configurações para inicializar a classe pai (DbContext)
    public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options) : base(options)
    {
    }

    // Mapeamento de Tabela: DbSet<Produto> representa a tabela física 'Produtos' no banco de dados.
    // É por meio dessa propriedade que realizaremos operações de CRUD e consultas LINQ.
    // '=> Set<Produto>()' inicializa o conjunto de forma segura, garantindo que a propriedade nunca fique nula.
    public DbSet<Produto> Produtos => Set<Produto>();
}