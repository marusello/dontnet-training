using System;

namespace lab3.Controllers
{
    public class TesteException : Exception
    {
        public TesteException()
        {
            
        }
        public TesteException(string errorMessage) : base(errorMessage)
        {
            
        }
    }
}