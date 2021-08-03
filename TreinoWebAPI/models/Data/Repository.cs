using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TreinoWebAPI.models.Data
{
    public class Repository : IRepository
    {
        private readonly ProdutoContext _context;
        
        public Repository(ProdutoContext context)
        {
            _context = context;
        }       

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }       

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >0);
        }

        //=====================================================================

        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking()
                         .OrderBy (p=> p.Nome);
            
            return (await query.ToArrayAsync());
        }

       public async Task<Produto> GetProdutosByNameAsync(string name) // o false deixa o parâmetro como opcional.
        {
            IQueryable<Produto> query = _context.Produtos; 

               query = query.AsNoTracking()
                      .Where(p => p.Nome.ToLower().Contains(name.ToLower())); // Consultar por meio do nome.
                   

               return (await query.FirstOrDefaultAsync());
        }

       
        public async Task<Produto> GetProdutoByIdAsync(int ProdutoId)
        {
            IQueryable<Produto> query = _context.Produtos;

             query = query.AsNoTracking()
                    .Where(p => p.ProdutoId == ProdutoId); // Consultar por meio do Id.

               return await query.FirstOrDefaultAsync();

        }
       
    }
}