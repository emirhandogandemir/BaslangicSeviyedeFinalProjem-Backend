using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
          ProductManager productManager= new ProductManager(new EfProductDao());

          foreach (var product in productManager.GetByUnitPrice(10,20))
          {
              Console.WriteLine(product.ProductName);
          }

        }
    }
}
