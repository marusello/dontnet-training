using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entidades
{
    public class CategoriaModel
    {
        public CategoriaModel() { }
        public CategoriaModel(string codigo, string descricao) 
        {
            Codigo = codigo;
            Descricao = descricao;
            CriadoEm = DateTime.Now;
        }

        [Key]
        [Required]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Codigo")]
        [MinLength(4, ErrorMessage = "Deve conter exatamente 4 caracteres")]
        [MaxLength(4, ErrorMessage = "Deve conter exatamente 4 caracteres")]
        public string Codigo { get; set; }

        [Required]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data da criacao")]
        public DateTime CriadoEm { get; set; }
       // public List<ProdutoModel> Produtos { get; set; }
        
    }
}
