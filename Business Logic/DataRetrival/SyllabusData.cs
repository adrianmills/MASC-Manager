using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO.Interface;
using Masc_Model.DAL;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business_Logic.DataRetrival
{
    public class SyllabusData : BaseData, ISyllabusData
    {
        MASCContext _context;

        public SyllabusData(MASCContext context, IUser user) : base(user)
        {
            _context = context;

        }
        public IEnumerable<ISyllabusDTO> Syllabi
        {
            get
            {
                List<ISyllabusDTO> syllabi = new List<ISyllabusDTO>();

                return syllabi;
            }
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ISyllabus record)
        {
            throw new NotImplementedException();
        }

        public ISyllabus Find(long id, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public ISyllabus Find(Expression<Func<ISyllabus, bool>> filter, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public bool ProccessSyllabi(ISyllabusDataItems dataItems)
        {
            throw new NotImplementedException();
        }
    }


    
}
