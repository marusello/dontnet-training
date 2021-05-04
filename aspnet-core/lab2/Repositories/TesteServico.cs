
namespace lab2.Repositories
{
  public class TesteServico : ITesteServico
  {
    public string Teste()
        {
            var message = "";

            try
            {
                message = "Teste DI";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return message;
        }
  }
}
