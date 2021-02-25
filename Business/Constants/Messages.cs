using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string ProductAdded = " ürün eklendi";
        public static string ProductNameInValid = "ürün ismi geçersiz";
        public static string Maintenancetime = "sistem bakımda";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductsListed = "ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 15 ürün olabilir";
        public static string ProductNameAlreadyExists = "bu Adda bir ürün bulunmaktadır";
        public static string CategoryLimitExceded = " kategori limiti aşıldığı için yeni ürün eklenemiyor";
    }
}
