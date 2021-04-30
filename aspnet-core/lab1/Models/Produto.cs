using System;

namespace lab1.Models
{
    public class Produto
    {
        public Produto()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }
    }
}
