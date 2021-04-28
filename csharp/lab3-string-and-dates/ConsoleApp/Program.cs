using System;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {      
            FormatarParaMaiusculaESubstituirPalavra("treinamento de dot net na cit.");
            AdicionarProximosNoveNumeros(1);
            FormatarData("22/03/2019 00:30:00");
            IncrementarData("22/03/2019 00:00:00");
        }

        static void FormatarParaMaiusculaESubstituirPalavra(string message) {
            
            var newMessage = message.Replace("DOT NET", ".NET").ToUpper();

            Console.WriteLine(newMessage);
        }

        static void AdicionarProximosNoveNumeros(int texto) {
             StringBuilder newTexto = new StringBuilder(texto); 
             
             for (int i = texto; i<= 9; i++) 
             {
                 newTexto = (i == texto) ? newTexto.Append(i) : newTexto.Append("," + i); 
             }
             Console.WriteLine(newTexto);
        }

        static void FormatarData(string date) {
            var newDate = DateTime.Parse(date);
               
                Console.WriteLine($"{newDate.ToShortDateString()} {newDate.ToShortTimeString()} {newDate.ToLongDateString()}");
                
        }

        static void IncrementarData(string date) {
           
            var newDate = DateTime.Parse(date);            
            Console.WriteLine($"{newDate.AddDays(1).AddHours(4).AddMinutes(30)}");                            
        }
    }
}
