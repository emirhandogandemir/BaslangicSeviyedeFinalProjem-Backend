using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //test amaçlı bir token vermek isteyebiliriz , yada farklı bir araçla kullanmak isteyebiliriz diye interface
  public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaim);



    }
}
