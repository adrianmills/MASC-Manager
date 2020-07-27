using Business_Logic.View_Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
   public interface IPopulateLists<T> where T : IViewModelBase
    {

        void PopulateList(T viewModel);
    }
}
