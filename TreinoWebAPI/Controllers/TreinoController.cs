using Microsoft.AspNetCore.Mvc;
using TreinoWebAPI.models;
using System.Threading.Tasks;
using TreinoWebAPI.models.Data;
using AutoMapper;
using System.Collections.Generic;
using TreinoWebAPI.Dto;

namespace TreinoWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreinoController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;

        public TreinoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // GET: api/Treino
        [HttpGet] // POR ROTA
        public async Task<ActionResult<Produto>> GetAllProdutosAsync()
        {
            var produtos = await _repo.GetAllProdutosAsync();            

            return Ok(_mapper.Map<IEnumerable<ProdutoDto>>(produtos));
        }

        // GET: api/Treino/5
        [HttpGet("{id:int}")] // POR ROTA
        public async Task<ActionResult<Produto>> GetProdutoByIdAsync(int id)
        {
            var produto = await _repo.GetProdutoByIdAsync(id);

            if (produto == null)
            {
                return BadRequest("O Produto " + id + " não foi localizado !");
            }

            var produtoDto = _mapper.Map<ProdutoDto>(produto);

            return Ok(produtoDto);
        }

        //api/Treino/Nome
        [HttpGet("{nome}")] // Via QUERYSTRING.....
        public async Task<ActionResult<Produto>> GetAllProdutosByNameAsync(string nome)
        {
            var produto = await _repo.GetProdutosByNameAsync(nome);
            if (produto == null) return BadRequest("O produto " + nome + " não foi localizado !");

            var produtoDto = _mapper.Map<ProdutoDto>(produto);

            return Ok(produtoDto);
        }

        // POST: api/Treino
        [HttpPost] // POR ROTA                  //Post(Produto produto) Era Assimm...Agora quero Mapear o Dto.
        public async Task<ActionResult<Produto>> Post(ProdutoDto model)
        {
            //o (Var) abaixo é para Mapeamento do DTO:
            var produto = _mapper.Map<Produto>(model);

            _repo.Add(produto);
            if (await _repo.SaveChangesAsync())
            {
                // Ao Ivés do OK (cód. 200, o Created retorna um 201).
                return Created($"/api/treino/{model.ProdutoId}", _mapper.Map<ProdutoDto>(produto));
            }

            return BadRequest("Produto não cadastrado !!!");
        }

        // PUT: api/Treino/5
        [HttpPut("{id}")] // POR ROTA          //Put(Produto produto) Era Assimm...Agora quero Mapear o Dto.
        public async Task<IActionResult> Put(int id, ProdutoDto model)
        {
            var produto = await _repo.GetProdutoByIdAsync(id);

            if (produto == null) BadRequest("Produto não Encontrado !!!");

            //Abaixo Mapeamento para o PUT.
            _mapper.Map(model, produto);

            _repo.Update(produto);

            if (await _repo.SaveChangesAsync())
            {
                // Ao Ivés do OK (cód. 200, o Created retorna um 201).
                return Created($"/api/treino/{model.ProdutoId}", _mapper.Map<ProdutoDto>(produto));
            }
            return BadRequest("Falha ao atualizar o  registro do Produto !!!");

        }

        // PATCH: api/Treino/5
        [HttpPatch("{id}")] // POR ROTA              //Patch(Produto produto) Era Assimm...Agora quero Mapear o Dto.
        public async Task<ActionResult<Produto>> Patch(int id, ProdutoDto model)
        {
            var produto = await _repo.GetProdutoByIdAsync(id);

            if (produto == null) BadRequest("Produto não Encontrado !!!");

            //Abaixo Mapeamento para o PUT.
            _mapper.Map(model, produto);

            _repo.Update(produto);

            if (await _repo.SaveChangesAsync())
            {
               // Ao Ivés do OK (cód. 200, o Created retorna um 201).
                return Created($"/api/treino/{model.ProdutoId}", _mapper.Map<ProdutoDto>(produto));
            }
            return BadRequest("Falha ao atualizar o  registro do Produto !!!");
        }

        // DELETE: api/Treino/5
        [HttpDelete("{id}")] // POR ROTA
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            var produto = await _repo.GetProdutoByIdAsync(id);

            if (produto == null) return BadRequest("Produto não Encontrado !!!");


            _repo.Remove(produto);

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