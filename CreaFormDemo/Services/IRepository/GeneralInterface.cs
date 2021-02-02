using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.IRepository
{
  public  interface GeneralInterface<T>
    {
        Task<T> isExist(int ID);
    }
}
