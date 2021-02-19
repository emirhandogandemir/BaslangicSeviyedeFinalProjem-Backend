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
          
            ProductTest();

        } 

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDao());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDao());

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
