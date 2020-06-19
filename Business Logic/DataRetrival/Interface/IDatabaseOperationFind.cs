using Business_Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IDatabaseOperationFind<T> where T:IBaseDTO
    {

        T Detail(long ID);
    }
}
