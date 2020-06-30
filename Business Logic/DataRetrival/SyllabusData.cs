using AutoMapper;
using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO;
using Business_Logic.DTO.Interface;
using Business_Logic.View_Model.Interface;
using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Business_Logic.DataRetrival
{
    public class SyllabusData : BaseData, ISyllabusData
    {
 

        public SyllabusData(MASCContext context,IMapper mapper, IUser user) : base(context,mapper, user)
        {
            

        }

        public IEnumerable<ISyllabusDTO> Syllabi => throw new NotImplementedException();

        public bool Add(ISyllabusViewModel record)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ISyllabusViewModel record)
        {
            throw new NotImplementedException();
        }

        public ISyllabusViewModel Find(long id, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public ISyllabusViewModel Find(Expression<Func<ISyllabusViewModel, bool>> filter, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public bool ProccessSyllabi(ISyllabusDataItems dataItems)
        {
            throw new NotImplementedException();
        }

        public bool Update(ISyllabusViewModel record)
        {
            throw new NotImplementedException();
        }
    }


    
}
