using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
           // ProductTest();
           // Ioc
            //CategoryTest();
           // ProductManager productManager = new ProductManager(new EfProductDao());
          
           // ProductTest();
           CategoryTest();
        } 

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDao());
            var result = categoryManager.GetAll();
            if (result.Success)
            {
                foreach (var category in result.Data)
                {
                    Console.WriteLine(category.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
          
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDao(),new CategoryManager(new EfCategoryDao()));

            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " /" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

           
        }
    }
}
