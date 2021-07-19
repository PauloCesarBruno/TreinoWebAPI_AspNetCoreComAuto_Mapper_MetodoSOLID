using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TreinoWebAPI.models;
using System;

namespace TreinoWebAPI.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class TreinoController : ControllerBase
    {        
        // CRIADO ESTE OBJETO PARA TESTES.
        public List<Produto> Produtos = new List<Produto> ()
        {
            new Produto(){
                ProdutoId = 1,
                Nome = "Pacote de Bom-Brill",
                DataValidade = DateTime.Parse("28/05/2022"),
                Valor = (decimal)1529.50,
                Ativo = true

            },

             new Produto() {
                ProdutoId = 2,
                Nome = "Sabão em pó Tixam-Ipe",
                DataValidade = DateTime.Parse("04/12/2023"),
                Valor = (decimal)29.03,
                Ativo = true

            },

             new Produto() {
                ProdutoId = 3,
                Nome = "Detergente Ipe-Eucaliptum",
                DataValidade = DateTime.Parse("10/08/2002"),
                Valor = (decimal)5.99,
                Ativo = false

            },

             new Produto() {
                ProdutoId = 4,
                Nome = "Sabão de Côco Karatê 100g.",
                DataValidade = DateTime.Parse("26/11/2001"),
                Valor = (decimal)0.99,
                Ativo = true

            },
        };
       
       private readonly ProdutoContext _context;
        
        public TreinoController(ProdutoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Produtos);
        }
    }
}