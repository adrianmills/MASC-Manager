using Business_Logic.View_Model.Interface;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IDataOperationAddAndUpdate<T> where T : IViewModelBase
    {
        void Add(T record);

        void Update(T record);

        void Delete(long id);

    }
}
