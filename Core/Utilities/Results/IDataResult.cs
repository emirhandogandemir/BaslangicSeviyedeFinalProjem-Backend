using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public interface IDataResult<T>: IResult // T ye kısıtlama yazmadık burada her şey olabilir T çünkü
    {
        T Data { get; }

    }
}
