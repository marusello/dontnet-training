using ConsoleApp.src.interfaces;
using System;

namespace ConsoleApp.src.entities
{
    public class Customer : ICustomer
    {
        public string codigo { get; set; }  
        public string nome { get; set; } 

        public void Save() 
        {            
            Console.WriteLine("Customer saved!");
        }
    }
}