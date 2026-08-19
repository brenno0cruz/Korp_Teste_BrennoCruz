// Namespace: Espaço de nomes lógico que reflete a estrutura física de diretórios (Korp.Estoque.Api > Entities)
namespace Korp.Estoque.Api.Entities;

// Entidade de Domínio: Representa o modelo de negócio de Produto e o mapeamento da tabela no banco de dados
public class Produto
{
    // Chave Primária (Primary Key) com identificador numérico inteiro (int) e auto-incremental por convenção do EF Core
    public int Id { get; set; }
    
    // Código comercial do produto: tipo string (texto), com leitura (get) e escrita (set).
    // Inicializado com string.Empty para atender ao Nullable Reference Types e evitar NullReferenceException
    public string Codigo { get; set; } = string.Empty;
    
    // Descrição/Nome do produto: tipo string (texto), inicializado com string.Empty para garantir que não inicie nulo
    public string Descricao { get; set; } = string.Empty;
    
    // Saldo disponível em estoque: tipo decimal (ponto fixo de 128 bits), garantindo precisão matemática exata para quantidades
    public decimal Saldo { get; set; }
}