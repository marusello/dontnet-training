using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {   
            var sequencia = 1;   

            while (sequencia <=10 ) 
            {
                Console.WitheLine($"Sequência: {sequencia}");

                if (sequencia % 2 == 0) 
                {
                    Console.WitheLine($"Número par: {sequencia}");
                }
            }
           
        }
    }
}
