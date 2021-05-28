namespace Business.Entidades
{
    public class ProdutoInputModel
    {
        public ProdutoInputModel() { }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string UnidadeMedida { get; set; }
        public CategoriaModel Categoria { get; set; }
    }
}
