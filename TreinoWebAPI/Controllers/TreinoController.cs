using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TreinoWebAPI.models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TreinoWebAPI.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class TreinoController : ControllerBase
    {    
        private readonly ProdutoContext _context;
        
        public TreinoController(ProdutoContext context)
        {
            _context = context;
        }

        // GET: api/Treino
        [HttpGet] // POR ROTA
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/Treino/5
        [HttpGet("{id:int}")] // POR ROTA
        public async Task<ActionResult<Produto>> GetProdutosById(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }


       //api/Treino/Nome
        [HttpGet("{nome}")] // Via QUERYSTRING.....
        public async Task<ActionResult<Produto>> GetProdutosByName(string nome)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Nome.Contains(nome));
            if (produto == null) return BadRequest("O produto " + nome + " não foi localizado !");

            return Ok(produto);
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