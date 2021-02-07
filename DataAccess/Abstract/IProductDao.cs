using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
   public interface IProductDao :IEntityRepository<Product> // sen IRepositoryi Product İçin Yapılandırdın Demek
   {
       List<ProductDetailDto> GetProductDetails();

   }
}
// Code Refactoring