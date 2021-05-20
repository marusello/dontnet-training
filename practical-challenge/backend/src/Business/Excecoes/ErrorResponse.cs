using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Excecoes
{
    public class ErrorResponse
    {
        public int Codigo { get; set; }
        public string Messagem { get; set; }
        public ErrorResponse InnerError { get; set; }


    }
}
