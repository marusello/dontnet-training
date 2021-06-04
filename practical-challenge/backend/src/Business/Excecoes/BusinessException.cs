using System;

namespace Business.Excecoes
{
    public class BusinessException : Exception
    {
        public BusinessException() { }
        public BusinessException(string errorMessage) : base(errorMessage) { }
    }
}