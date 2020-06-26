using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO;
using Business_Logic.DTO.Interface;
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

                syllabi.AddRange(from s in _context.Syllabi
                                 where !s.Deleted
                                 select new SyllabusDTO
                                 {
                                     ID = s.ID,
                                     SyllabusName = s.Name
                                 });
                return syllabi;
            }
        }

        public void Delete(long id)
        {
            Delete(Find(id, true));
        }

        public void Delete(ISyllabus record)
        {
            AddDetails(record, false);
            record.Deleted = true;
        }

        public ISyllabus Find(long id, bool isEdit)
        {
            return Find(s => s.ID == id, isEdit);
        }

        public ISyllabus Find(Expression<Func<ISyllabus, bool>> filter, bool isEdit)
        {
            ISyllabus syllabus;

            if(isEdit)
            {
                syllabus = (from s in _context.Syllabi
                            .Where(filter)
                            select s).FirstOrDefault();
            }
            else
            {
                syllabus = (from s in _context.Syllabi
                           .Where(filter)
                           .AsNoTracking()
                            select s).FirstOrDefault();
            }

            return syllabus;
        }

        public bool ProccessSyllabi(ISyllabusDataItems dataItems)
        {
            throw new NotImplementedException();
        }
    }


    
}
