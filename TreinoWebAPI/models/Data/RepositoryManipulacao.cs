using System.Threading.Tasks;

namespace TreinoWebAPI.models.Data
{
    public class RepositoryManipulacao : IRepositoryManipulacao
    {
        private readonly ProdutoContext _Produtocontext;
        
        public RepositoryManipulacao(ProdutoContext context)
        {
            _Produtocontext = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _Produtocontext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _Produtocontext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _Produtocontext.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _Produtocontext.RemoveRange(entityArray);
        }

         public async Task<bool> SaveChangesAsync()
        {
            return (await _Produtocontext.SaveChangesAsync()) > 0; // Se > 0 Retorna True.
        }

       
    }
}