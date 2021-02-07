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
            //ProductTest();
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDao());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }



        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDao());

            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
