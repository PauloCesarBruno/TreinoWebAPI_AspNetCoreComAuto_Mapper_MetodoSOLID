using System.Threading.Tasks;

namespace TreinoWebAPI.models.Data
{
    public interface IRepositoryLeitura
    {
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int ProdutoId);
        Task<Produto> GetProdutosByNameAsync(string dataValidade);
    }
}