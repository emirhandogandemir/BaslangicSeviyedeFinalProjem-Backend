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
            ProductManager productManager = new ProductManager(new EfProductDao());
            productManager.Update(new Product
            {
                ProductId = 10,
                CategoryId = 7,
                ProductName = "güncelleme",
                UnitPrice = 100,
                UnitsInStock = 3
            });


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

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName+" /"+product.CategoryName);
            }
        }
    }
}
