using System;
using System.ComponentModel.DataAnnotations;

namespace TreinoWebAPI.Dto
{
    public class ProdutoDto
    {
        public ProdutoDto() { }

        public ProdutoDto(int produtoId, string nome, DateTime dataValidade, double valor)
        {
            this.ProdutoId = produtoId;
            this.Nome = nome;
            this.DataValidade = dataValidade;
            this.Valor = valor;

        }
        
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [StringLength(50, MinimumLength = 03, ErrorMessage = "Minimo 03 caracteres !"), MaxLength(50, ErrorMessage = "Máximo 50 caracteres !")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Data de Validade")]
        //ABAIXO FORMATAR A DATA SEM A HORA
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataValidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Valor do Produto")]
        [DataType(DataType.Currency)]
        public double Valor { get; set; }
    }
}