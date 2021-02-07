using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDao _categoryDao;

        public CategoryManager(ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }

        public List<Category> GetAll()
        {
            return _categoryDao.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDao.Get(category => category.CategoryId == categoryId);
        }
    }
}
