using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
          ProductManager productManager= new ProductManager(new InMemoryProductDao());

          foreach (var product in productManager.GetAll())
          {
              Console.WriteLine(product.ProductName);
          }

        }
    }
}
