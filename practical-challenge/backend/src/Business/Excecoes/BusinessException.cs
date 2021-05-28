using System;

using Business.Entidades;

namespace Business.Excecoes
{
    public class BusinessException : Exception
    {
        public BusinessException() { }
        public BusinessException(string errorMessage) : base(errorMessage) { }

        public static void ValidacaoInputCategoria(CategoriaInputModel categoria)
        {
            //if (categoria.id == guid.empty)
            //{
            //    throw new businessexception("id � obrigatorio");
            //}

            if (categoria.Descricao == null || categoria.Descricao == "")
            {
                throw new BusinessException("Descri��o � obrigatorio");
            }

            if (categoria.Codigo == null)
            {
                throw new BusinessException("C�digo  n�o pode ser null");
            }

            if (categoria.Codigo.Length < 4 || categoria.Codigo.Length > 4)
            {
                throw new BusinessException("C�digo deve conter exatamente 4 caracteres");
            }
           
        }

    }

}