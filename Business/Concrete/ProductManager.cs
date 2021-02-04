using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDao _productDao;

        public ProductManager(IProductDao productDao)
        {
            _productDao = productDao;
        }
        public List<Product> GetAll()
        {
          // iş kodlari
          // Yetkisi var mmı ?

          return _productDao.GetAll();


        }

        public List<Product> GetAllByCategory(int id)
        {
            return _productDao.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDao.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
