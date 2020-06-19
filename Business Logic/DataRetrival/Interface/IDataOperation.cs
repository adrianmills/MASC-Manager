using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
   public interface IDataOperationFindAndDelete<T>  where T:IBase
    {

       

        T Find(long id, bool isEdit);

        T Find(Expression<Func<T, bool>> filter, bool isEdit);

        void Delete(long id);

        void Delete(T record);

    }
}
