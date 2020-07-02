using AutoMapper;
using Business_Logic.DataRetrival.Interface;
using Masc_Model.DAL;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival
{
    public abstract class BaseData
    {

        protected IUser _user;
        protected IMapper _mapper;
        protected MASCContext _context;

        public BaseData(MASCContext context, IMapper mapper, IUser user)
        {
            _context = context;
            _mapper = mapper;
            _user = user;
        }
        protected void AddDetails(IBase record, bool newRecord = false)
        {

            if (newRecord)
            {
                record.CreatedBy = _user.UserName;
                record.CreatedOn = DateTime.Now;
            }
            else
            {
                record.ModifiedBy = _user.UserName;
                record.ModifiedOn = DateTime.Now;
            }
        }
    }
}
