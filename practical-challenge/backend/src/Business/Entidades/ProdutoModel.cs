using Business.Excecoes;
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

            if (model.Preco < 0)
                throw new BusinessException("Preço não pode ser menor que ZERO.");
            else
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
            Codigo = codigo == null || codigo == "" ? Codigo : codigo;
            Descricao = descricao == null || descricao == "" ? Descricao : descricao;

            if (preco < 0)
                throw new BusinessException("Preço não pode ser menor que ZERO.");
            else
                Preco = preco == 0 ? Preco : preco;

            UnidadeMedida = unidadeMedida == null || descricao == "" ? UnidadeMedida : unidadeMedida;
            CategoriaId = categoria.Id == Guid.Empty ? CategoriaId : categoria.Id;
        }
    }
}
