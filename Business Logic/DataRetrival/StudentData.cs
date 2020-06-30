using AutoMapper;
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
  

        public StudentData(MASCContext context,IMapper mapper, IUser user) : base(context, mapper, user)
        {
            
            
        }

        public IEnumerable<IStudentViewModel> Students => throw new NotImplementedException();

        public bool Add(IStudentViewModel record)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(IStudentViewModel record)
        {
            throw new NotImplementedException();
        }

        public IStudentViewModel Detail(long ID)
        {
            throw new NotImplementedException();
        }

        public IStudentViewModel Find(long id, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public IStudentViewModel Find(Expression<Func<IStudentViewModel, bool>> filter, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public void PopulateLists(IStudentViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public bool Update(IStudentViewModel record)
        {
            throw new NotImplementedException();
        }
    }
}
