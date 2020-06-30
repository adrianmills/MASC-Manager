using Business_Logic.DTO.Interface;
using Business_Logic.View_Model.Interface;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IDatabaseOperationDetail<T> where T: IViewModelBase
    {

        T Detail(long ID);
    }
}
