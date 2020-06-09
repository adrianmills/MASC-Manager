using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
   public interface IDataOperation<T>  where T:IBase
    {

        bool Add(T record);

        bool Update(T record);

        T Find(int id, bool isEdit);

        T Find(Expression<Func<T, bool>> filter, bool isEdit);

        void Delete(int id);

    }
}
