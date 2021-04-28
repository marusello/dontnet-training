using System;
using ConsoleApp.src.interfaces;
using ConsoleApp.src.entities;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();

            customer.Save("123", "teste");
        }
    }
}
