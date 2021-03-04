using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDao _productDao;
        ICategoryService _categoryService;


        public ProductManager(IProductDao productDao,ICategoryService categoryService)
        {
            _productDao = productDao;
            _categoryService = categoryService;
        }

        //Bu kullanıcının product.add veya admin claimlerinden birine sahip olması gerekiyor
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), CheckIfProductCountCategoryCorrect(product.CategoryId),
                CheckIfCategoryLimitExceded());
            if (result != result)
            {
                return result;
            }

            _productDao.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }
      //  [CacheAspect] //key, value 
        public IDataResult<List<Product>> GetAll()
        {

            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Product>>(Messages.Maintenancetime);
            }

            return new SuccessDataResult<List<Product>>(_productDao.GetAll(), Messages.ProductsListed); ;
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDao.GetAll(p => p.CategoryId == id)); ;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDao.Get(p => p.ProductId == productId));

        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDao.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max)); ;
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDao.GetProductDetails()); ;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {

            _productDao.Update(product);
            return new SuccessResult(Messages.ProductUpdated);

        }

        private IResult CheckIfProductCountCategoryCorrect(int categoryId)
        {
            //Select count(*) from products where categoryId=1
            var result = _productDao.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            //Select count(*) from products where categoryId=1
            var result = _productDao.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
