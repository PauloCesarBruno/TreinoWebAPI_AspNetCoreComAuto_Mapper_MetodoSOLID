using System.Threading.Tasks;

namespace TreinoWebAPI.models.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T:class;
        void Update<T>(T entity) where T:class;
        void Remove<T>(T entity) where T:class;

        Task<bool> SaveChangesAsync();

//=====================================================================

        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int ProdutoId);
        Task<Produto> GetProdutosByNameAsync(string dataValidade);
    }
}