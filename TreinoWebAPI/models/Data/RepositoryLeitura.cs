using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TreinoWebAPI.models.Data
{
    public class RepositoryLeitura : IRepositoryLeitura
    {
        private readonly ProdutoContext _context;
        
        public RepositoryLeitura(ProdutoContext context)
        {
            _context = context;
        }    

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