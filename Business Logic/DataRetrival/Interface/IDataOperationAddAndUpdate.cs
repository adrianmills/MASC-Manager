using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IDataOperationAddAndUpdate<T> where T : IBase
    {
        bool Add(T record);

        bool Update(T record);
    }
}
