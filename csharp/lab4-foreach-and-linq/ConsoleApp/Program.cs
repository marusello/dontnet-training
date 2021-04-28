using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Compra
    {
        public string Cliente { get; set; }
        public decimal Valor { get; set; }
        public bool PagamentoRealizado { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var compras = new List<Compra>
            {
                new Compra { Valor = 20, PagamentoRealizado = true , Cliente = "João" },
                new Compra { Valor = 10, PagamentoRealizado = true , Cliente = "Maria" },
                new Compra { Valor = 80, PagamentoRealizado = false, Cliente = "Tereza" },
                new Compra { Valor = 30, PagamentoRealizado = true , Cliente = "José" },
                new Compra { Valor = 10, PagamentoRealizado = false, Cliente = "João" },
                new Compra { Valor = 20, PagamentoRealizado = true , Cliente = "João" },
                new Compra { Valor = 20, PagamentoRealizado = false, Cliente = "Tereza" },
                new Compra { Valor = 40, PagamentoRealizado = true, Cliente = "Maria" },
                new Compra { Valor = 30, PagamentoRealizado = true , Cliente = "João" },
                new Compra { Valor = 10, PagamentoRealizado = false, Cliente = "Tereza" }
            };

            Console.WriteLine($"Valor total a receber: {ValorTotalAReceber(compras)}");
            Console.WriteLine($"Devedores: {string.Join(", ", ClientesDevedores(compras))}");
        }

        // Soma o valor de todas compras não pagas.
        // Resultado esperado: 120
        private static decimal ValorTotalAReceber(List<Compra> compras)
        {
            /*/return compras.Where(x => !x.PagamentoRealizado)
                             .Sum(x => x.Valor);
            */
            
            decimal valorTotal = 0;

            foreach (var compra in compras) {
                if (!compra.PagamentoRealizado) {
                    valorTotal = valorTotal + compra.Valor;
                }
            }
            return valorTotal;
        }

        // Seleciona os nomes dos clientes que têm compras não pagas.
        // Resultado esperado: Tereza, João
        private static IEnumerable<string> ClientesDevedores(List<Compra> compras)
        {
            /*
            var devedores = new List<string>();

            foreach (var compra in compras)
            {
                if (!compra.PagamentoRealizado)
                {
                    if (!devedores.Contains(compra.Cliente))
                    {
                        devedores.Add(compra.Cliente);
                    }
                }
            }

            return devedores;
            */
            return compras
                      .Where(c => !c.PagamentoRealizado)
                      .Select(c => c.Cliente)
                      .Distinct();
                      
        }
    }
}