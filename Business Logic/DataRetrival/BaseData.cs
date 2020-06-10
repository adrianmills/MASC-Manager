using Business_Logic.DataRetrival.Interface;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival
{
    public abstract class BaseData : IBaseData
    {

        IUser _user;

        public BaseData(IUser user)
        {
            _user = user;
        }
        public void AddDetails(IBase record, bool newRecord)
        {
           
            if (newRecord)
            {
                record.CreatedBy = _user.UserName;
                record.DateCreated = DateTime.Now;
            }
            else
            {
                record.ModifiedBy = _user.UserName;
                record.ModifiedOn = DateTime.Now;
            }
        }
    }
}
