using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TreinoWebAPI.models
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) {}

        public DbSet<Produto> Produtos {get; set;}

        internal Task FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        internal Task FindAsync(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}