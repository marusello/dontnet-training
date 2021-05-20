using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entidades
{
    public class ProdutoModel
    {
        public ProdutoModel() { }
        public ProdutoModel(string codigo, string descricao, decimal preco, string unidadeMedida, Guid categoriaId) 
        {
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
            UnidadeMedida = unidadeMedida;
            CategoriaId = categoriaId;
        }

        [Key]
        [Required]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Deve conter exatamente 4 caracteres")]
        [MaxLength(4, ErrorMessage = "Deve conter exatamente 4 caracteres")]
        public string Codigo { get; set; }

        [Required]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Preco")]
        public decimal Preco { get; set; }

        [Required]
        [Display(Name = "Unidade de medida")]
        public string UnidadeMedida { get; set; }

        [Required]
        public Guid CategoriaId { get; set; }
        public CategoriaModel Categoria { get; set; }
    }
}
