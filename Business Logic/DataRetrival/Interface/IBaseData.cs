using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IBaseData
    {
        void AddDetails(IBase record,bool newRecord);
    }
}
