using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String number = 1;   

            if (number < 1 || number > 100) {
                Console.WriteLine("Valor é inválido para o sorteio. Por favor entre com um valor de 1 a 100.");         
            } 
            else 
            {
                Console.WriteLine("Informe um número e pressione enter.");            
                number = Convert.ToInt32(Console.ReadLine());
            }

            switch (number)
            {
                case 40:
                    Console.WriteLine("Sortudo, ganhou um carro!!!.");
                    break;
                case 75:
                    Console.WriteLine("Sortudo, ganhou um carro!!!.");
                    break;
                case 90:
                    Console.WriteLine("Sortudo, ganhou um carro!!!.");
                    break;
                default:
                    Console.WriteLine("Tente novamente, quem sabe você ganha!");
                    break;
            }

        }
    }
}
