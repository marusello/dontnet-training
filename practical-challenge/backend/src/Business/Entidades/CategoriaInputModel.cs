using System;

namespace Business.Entidades
{
    public class CategoriaInputModel
    {
        public CategoriaInputModel() { }
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
