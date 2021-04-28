using ConsoleApp.src.entities;

namespace ConsoleApp.src.interfaces
{   
    public interface ICustomer
    { 
        string codigo { get; set; }
        string nome { get; set; }

        void Save();
    }
}