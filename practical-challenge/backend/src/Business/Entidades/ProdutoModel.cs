using System;

namespace Business.Entidades
{
    public class ProdutoModel
    {
        public ProdutoModel() { }
        public ProdutoModel(ProdutoInputModel model) 
        {
            Codigo = model.Codigo;
            Descricao = model.Descricao;
            Preco = model.Preco;
            UnidadeMedida = model.UnidadeMedida;
            CategoriaId = model.Categoria.Id;
        }
             
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }
                
        public decimal Preco { get; set; }
               
        public string UnidadeMedida { get; set; }
                
        public Guid CategoriaId { get; set; }
        public CategoriaModel Categoria { get; set; }

        public void UpdateProduto(string codigo, string descricao, decimal preco, string unidadeMedida, CategoriaModel categoria)
        {
            Codigo = codigo == null ? Codigo : codigo;
            Descricao = descricao == null ? Descricao : descricao;
            Preco = preco == 0 ? Preco : preco;
            UnidadeMedida = unidadeMedida == null ? UnidadeMedida : unidadeMedida;
            CategoriaId = categoria.Id == Guid.Empty ? CategoriaId : categoria.Id;
        }
    }
}
