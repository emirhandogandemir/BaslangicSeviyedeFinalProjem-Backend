using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IProductDao :IEntityRepository<Product> // sen IRepositoryi Product İçin Yapılandırdın Demek
   {
       

   }
}
