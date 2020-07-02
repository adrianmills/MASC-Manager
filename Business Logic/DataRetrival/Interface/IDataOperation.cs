﻿using Business_Logic.View_Model.Interface;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IDataOperationFindAndDelete<T> where T : IViewModelBase
    {

       

        T Find(long id);



    }
}
