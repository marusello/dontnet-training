//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Business.Excecoes
//{
//    public class ErrorResponse
//    {
//        public int CodigoErro { get; set; }
//        public string Messagem { get; set; }
//        public static ErrorResponse From(Exception e)
//        {
//            if (e == null)
//            {
//                return null;
//            }
//            return new ErrorResponse
//            {
//                CodigoErro = e.HResult,
//                Messagem = e.Message
//            };
//        }
//    }
//}
