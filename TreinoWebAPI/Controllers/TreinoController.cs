using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TreinoWebAPI.models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreinoWebAPI.models.Data;
using Microsoft.AspNetCore.Http;

namespace TreinoWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreinoController : ControllerBase
    {    
        private readonly ProdutoContext _context;
        private readonly IRepository _repo;
        
        public TreinoController(ProdutoContext context, IRepository repo)
        {    
            _context = context;       
            _repo = repo;
        }

        // GET: api/Treino
        [HttpGet] // POR ROTA
        public async Task<ActionResult<Produto>> GetAllProdutosAsync()
        {
           var results = await _repo.GetAllProdutosAsync();

            if (results == null)
            {
                return BadRequest("O Produtos não localizados !");
            }

            return Ok(results);
        }

        // GET: api/Treino/5
        [HttpGet("{IdProduto:int}")] // POR ROTA
        public async Task<ActionResult<Produto>> GetProdutoByIdAsync(int IdProduto)
        {
            var results = await _repo.GetProdutoByIdAsync(IdProduto);

            if (results == null)
            {
                return BadRequest("O Produto " + IdProduto + " não foi localizado !");
            }

            return Ok(results);
        }

       //api/Treino/Nome
        [HttpGet("{nome}")] // Via QUERYSTRING.....
        public async Task<ActionResult<Produto>> GetAllProdutosByNameAsync(string nome)
        {
            var results = await _repo.GetProdutosByNameAsync(nome);
            if (results == null) return BadRequest("O produto " + nome + " não foi localizado !");

            return Ok(results);
        }

         // POST: api/Treino
        [HttpPost] // POR ROTA
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            _repo.Add(produto);
            await _repo.SaveChangesAsync();

            return Ok(produto);
        }

         // PUT: api/Treino/5
        [HttpPut("{ProdutoId}")] // POR ROTA
        public async Task<IActionResult> Put(int ProdutoId, Produto produto)
        {
            var prod = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p=> p.ProdutoId == ProdutoId);

            if (prod == null) BadRequest("Produto não Encontrado !!!");

           
            _repo.Update(produto);

            if (await _repo.SaveChangesAsync())
            {
                return Ok(produto);
            }
            return BadRequest("Falha ao atualizar o  registro do Produto !!!");

        }
        
         // PATCH: api/Treino/5
        [HttpPatch("{ProdutoId}")] // POR ROTA
        public async Task<ActionResult<Produto>> Patch(int ProdutoId, Produto produto)
        {
          var prod = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p=> p.ProdutoId == ProdutoId);

            if (prod == null) BadRequest("Produto não Encontrado !!!");

           
            _repo.Update(produto);

            if (await _repo.SaveChangesAsync())
            {
                return Ok(produto);
            }
            return BadRequest("Falha ao atualizar o  registro do Produto !!!");
        }

         // DELETE: api/Treino/5
        [HttpDelete("{ProdutoId}")] // POR ROTA
        public async Task<ActionResult<Produto>> Delete(int ProdutoId)
        {   var prod = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p=> p.ProdutoId == ProdutoId);

            if (prod == null ) return BadRequest("Produto não Encontrado !!!");

           
            _repo.Remove(prod);

            if (await _repo.SaveChangesAsync())
            {
                return Ok("Produto Excluido com Sucesso !!!");
            }
            return BadRequest("Falha ao Excluir o  registro do Produto !!!");      
        }

        //============================================================================================================//

        // CRIADO ESTE OBJETO PARA TESTES.
       /* public List<Produto> Produtos = new List<Produto> ()
        {
            new Produto(){
                ProdutoId = 1,
                Nome = "Pacote de Bom-Brill",
                DataValidade = DateTime.Parse("28/05/2022"),
                Valor = (double)1529.50,
                Ativo = true

            },

             new Produto() {
                ProdutoId = 2,
                Nome = "Sabão em pó Tixam-Ipe",
                DataValidade = DateTime.Parse("04/12/2023"),
                Valor = (double)29.03,
                Ativo = true

            },

             new Produto() {
                ProdutoId = 3,
                Nome = "Detergente Ipe-Eucaliptum",
                DataValidade = DateTime.Parse("10/08/2022"),
                Valor = (double)5.99,
                Ativo = false

            },

             new Produto() {               
                ProdutoId = 4,
                Nome = "Sabão de Côco Karatê 100g.",
                DataValidade = DateTime.Parse("26/11/2021"),
                Valor = (double)0.99,
                Ativo = true

            },
        };

         //============================================================================================================//
        

         [HttpGet]
        public IActionResult Get()
        { 
            return Ok(Produtos); // Produto com P Maiusculo e no plural = Objeto.
        }

        //api/Treino/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var produto = Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto == null) return BadRequest("O produto " + id + " não foi localizado !");

            return Ok(produto);
        }

        //api/Treino/Nome
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var produto = Produtos.FirstOrDefault(p => p.Nome.Contains(nome));
            if (produto == null) return BadRequest("O produto " + nome + " não foi localizado !");

            return Ok(produto);
        }*/
    }
}