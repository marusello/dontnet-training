using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //RepositorioGenerico<Cliente> T = new RepositorioGenerico<Cliente>();
            RepositorioGenerico<Produto> T = new RepositorioGenerico<Produto>();
        }
    }

    public class RepositorioGenerico<T> where T : class, new()
    {  

        public T Save(T obj)
        {
            return obj;
        }

        public void Update(T obj)
        {

        }

        public void Delete(T obj)
        {
            
        }

        public T Get(T id)
        {
            return id;
        }
    }

    public class Cliente
    {    
    }

    public class Produto
    {
    }
}
