using Business_Logic.DataRetrival.Interface;
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
   public class StudentData:BaseData,IStudentData
    {
        MASCContext _context;

        public StudentData(MASCContext context, IUser user) : base(user)
        {
            _context = context;
        }

        public IEnumerable<IStudent> Students
        {
            get
            {
                return _context.Students.Where(s => !s.Deleted);
            }
        }

        public bool Add(IStudent record)
        {
            try
            {
                AddDetails(record, true);
                _context.Students.Add((Student)record);
               _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(long id)
        {
            throw new NotImplementedException(); 
        }

        public void Delete(IStudent record)
        {
            throw new NotImplementedException();
        }

        public IStudent Find(long id, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public IStudent Find(Expression<Func<IStudent, bool>> filter, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public void PopulateLists(IStudentViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public bool Update(IStudent record)
        {
            throw new NotImplementedException();
        }
    }
}
