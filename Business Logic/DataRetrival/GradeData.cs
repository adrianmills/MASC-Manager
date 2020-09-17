using AutoMapper;
using Business_Logic.DataRetrival.Interface;
using Business_Logic.View_Model;
using Business_Logic.View_Model.Interface;
using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business_Logic.DataRetrival
{
    public class GradeData : BaseData,IGradeData
    {

        public GradeData(MASCContext context, IMapper mapper, IUser user) : base(context, mapper, user)
        {


        }
        public IEnumerable<IGradeViewModel> Grades
        {
            get
            {
                var grades = new List<IGradeViewModel>();

                grades.AddRange(from grade in _context.Grades
                                .Include(g => g.Syllabus)
                                where !grade.Deleted
                                select _mapper.Map<IGrade, IGradeViewModel>(grade)
                                 );

                return grades;
            }
        }

        public void Add(IGradeViewModel record)
        {
            var grade = _mapper.Map<IGradeViewModel, Grade>(record);

            AddDetails(grade, true);
            _context.Grades.Add(grade);
            _context.SaveChanges();


        }

        public void Delete(long id)
        {
            var gradeToDelete = RetriveGrade(id, true);

            AddDetails(gradeToDelete);
            gradeToDelete.Deleted = true;

            _context.Grades.Update((Grade)gradeToDelete);
            _context.SaveChanges();

        }

        public IGradeViewModel Detail(long id)
        {
            var rawGrade = RetriveGrade(id);

            var grade = _mapper.Map<IGrade, IGradeViewModel>(rawGrade);

            grade.Students = new List<IStudentViewModel>();

            foreach(var student in rawGrade.Students.Where(s=>!s.Deleted))
            {
                var studentVM = _mapper.Map<IStudent, IStudentViewModel>(student);
                grade.Students.Add(studentVM);
            }


            return grade;



        }

        public void Update(IGradeViewModel record)
        {
            var gradeToUpdate = RetriveGrade(record.GradeID, true);

            _mapper.Map(record, gradeToUpdate);

            if(_context.ChangeTracker.HasChanges())
            {
                AddDetails(gradeToUpdate);
                _context.Grades.Update((Grade)gradeToUpdate);
                _context.SaveChanges();
            }
        }


        IGrade RetriveGrade(long id, bool forEdit = false)
        {
            var query = from grade in _context.Grades
                         .Include(g=>g.Syllabus)
                         .Include(g=>g.Students)
                        where grade.ID == id
                        select grade;


            if (!forEdit)
            {
             query=   query.AsNoTracking();
            }

            var results = query.ToList();
            var returnItem = query.FirstOrDefault();
            return query.FirstOrDefault(); 

    

        }
    }
}
