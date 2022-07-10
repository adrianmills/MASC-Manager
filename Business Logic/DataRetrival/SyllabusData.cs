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

namespace Business_Logic.DataRetrival
{
    public class SyllabusData : BaseData, ISyllabusData
    {


        public SyllabusData(MASCContext context, IMapper mapper, IUser user) : base(context, mapper, user)
        {


        }
        public SyllabusData(MASCContext context, IMapper mapper) : base(context, mapper)
        {


        }
        public IEnumerable<ISyllabusViewModel> Syllabi
        {
            get
            {
                var syllabi = new List<ISyllabusViewModel>();

                syllabi.AddRange(from s in _context.Syllabi
                                 where !s.Deleted
                                 select _mapper.Map<ISyllabus, ISyllabusViewModel>(s));
                return syllabi;
            }
        }

        public void Add(ISyllabusViewModel record)
        {
            var syllabus = _mapper.Map<ISyllabusViewModel, Syllabus>(record);
            AddDetails(syllabus, true);
            _context.Syllabi.Add(syllabus);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var syllabus = RetrieveSyllabus(id,true);
            syllabus.Deleted = true;
            AddDetails(syllabus);
            _context.Syllabi.Update((Syllabus)syllabus);
            _context.SaveChanges();

        }

        public ISyllabusViewModel Detail(long id)
        {
            var rawData = RetrieveSyllabus(id, true);

            var syllabus = _mapper.Map<ISyllabus, ISyllabusViewModel>(rawData);

            var students = new List<IStudentViewModel>();
            var grades = new List<IGradeViewModel>();

 
            if (rawData.Grades != null)
            {
                foreach (var grade in rawData.Grades.Where(g => !g.Deleted))
                {
                    grades.Add(_mapper.Map<IGrade, IGradeViewModel>(grade));

                    if(grade.Students !=null)
                    {
                        foreach(var student in grade.Students.Where(s=>!s.Deleted))
                        {
                            students.Add(_mapper.Map<IStudent, IStudentViewModel>(student));
                        }
                    }
                }
            }
            syllabus.Students = students;
            syllabus.Grades = grades;
            return syllabus;
        }

        public void Update(ISyllabusViewModel record)
        {
            var updateSyllabus = RetrieveSyllabus(record.SyllabusID, true);
            _mapper.Map(record, updateSyllabus);

            if(_context.ChangeTracker.HasChanges())
            {
                AddDetails(updateSyllabus);
                _context.Update(updateSyllabus);
                _context.SaveChanges();
            }
        }

        ISyllabus RetrieveSyllabus(long id, bool forEdit)
        {
            var query = from syllabus in _context.Syllabi
                           .Include(s => s.Grades)
                           .ThenInclude(g=>g.Students)
                        where syllabus.ID == id
                        select syllabus;


            if (!forEdit)
            {
                query = query.AsNoTracking();
            }

            return query.FirstOrDefault();

        }
    }



}
