using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entidades
{
    public class ProdutoInputModel
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string UnidadeMedida { get; set; }
        public CategoriaModel Categoria { get; set; }
    
    }
}
