using AutoMapper;
using Business_Logic.View_Model.Interface;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest.Mock_Components
{
    public class MockData
    {

        IMapper _mapper;

        public MockData(IMapper mapper)
        {
            _mapper = mapper;
            }

        internal List<IUser> Users
        {
            get
            {
                var users = new List<IUser>();

                users.Add(new User { ID = 1, UserName = "Test User 1", Manager = true }) ;
                users.Add(new User { ID = 2, UserName = "Test User 2", Manager=false });
                users.Add(new User { ID = 3, UserName = "Test User 3", Manager = false });

                return users;
            }
        }

     
      internal List<IClub> Clubs
        {
            get
            {
                var clubs = new List<IClub>();
                clubs.Add(new Club { ID = 1, Name = "Club Test 1", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = false,ManagerID=1 });
                clubs.Add(new Club { ID = 2, Name = "Club Test 2", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = false, ManagerID = 2 });
                clubs.Add(new Club { ID = 3, Name = "Club Test 3", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = true,ManagerID=1 });

                return clubs;
            }
        }

       internal List<IStudent> Students
        {
            get
            {
                var students = new List<IStudent>();

                students.Add(new Student { ClubID = 1, DateofBirth = new DateTime(1973, 8, 3),Forename="Marty",Surname="Mcfly",ContactPhoneNumber="Test1" ,SyllabusID=1});
                students.Add(new Student { ClubID = 1, DateofBirth = new DateTime(2012, 11, 29), Forename = "George", Surname = "Mcfly", ContactPhoneNumber = "Test2", SyllabusID = 2 });
                students.Add(new Student { ClubID = 1, DateofBirth = new DateTime(1958, 11, 29), Forename = "George", Surname = "Mcfly", ContactPhoneNumber = "Test2", SyllabusID = 1 });
                students.Add(new Student { ClubID = 1, DateofBirth = new DateTime(2004, 11, 29), Forename = "George", Surname = "Mcfly", ContactPhoneNumber = "Test2", SyllabusID = 2, Deleted=true });
                students.Add(new Student { ClubID = 2, DateofBirth = new DateTime(1973, 8, 3), Forename = "Marty", Surname = "Mcfly", ContactPhoneNumber = "Test1", SyllabusID = 1 });
                students.Add(new Student { ClubID = 2, DateofBirth = new DateTime(1956, 11, 29), Forename = "Jack", Surname = "Sparrow", ContactPhoneNumber = "Test2", SyllabusID = 2 });
                students.Add(new Student { ClubID = 2, DateofBirth = new DateTime(1980, 11, 29), Forename = "William", Surname = "Turner", ContactPhoneNumber = "Test2", SyllabusID = 2 });
                students.Add(new Student { ClubID = 3, DateofBirth = new DateTime(2012, 06, 30), Forename = "George", Surname = "Mcfly", ContactPhoneNumber = "Test2", SyllabusID = 1  });


                return students;
            }

        }

        internal List<IGrade> Grades
        {
            get
            {
                var grades = new List<IGrade>();

                grades.Add(new Grade { ID = 1, Name = "White", SyllabusID = 1 });
                grades.Add(new Grade { ID = 2, Name = "Blue", SyllabusID = 1 });
                grades.Add(new Grade { ID = 3, Name = "Purple", SyllabusID = 2 });
                grades.Add(new Grade { ID = 4, Name = "Orange", SyllabusID = 2 });
                grades.Add(new Grade { ID = 5, Name = "Brown", SyllabusID = 3 });
                grades.Add(new Grade { ID = 6, Name = "Brown Gold Tag", SyllabusID = 2 });

                return grades;
            }
        }
        internal List<ISyllabus> Syllabi
        {
            get
            {

                var syllabi = new List<ISyllabus>();

                syllabi.Add(new Syllabus { ID = 1, Name = "Syllabus Test 1", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = false });
                syllabi.Add(new Syllabus { ID = 2, Name = "Syllabus Test 2", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = false });
                syllabi.Add(new Syllabus { ID = 3, Name = "Syllabus Test 3", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = true });

                return syllabi;
            }
        }
        internal List<IClubViewModel> ClubsViewData
        {
            get
            {
                var clubs = new List<IClubViewModel>();

                foreach(var club in Clubs.Where(c=>!c.Deleted))
                {
                    var clubVM = _mapper.Map<IClub, IClubViewModel>(club);
                    clubs.Add(clubVM);
                }
                return clubs;
            }
        }

        internal List<IStudentViewModel> StudentsViewData
        {
            get
            {
                var students = new List<IStudentViewModel>();
                foreach(var student in Students.Where(s=>!s.Deleted))
                {
                    var studentVM = _mapper.Map<IStudent, IStudentViewModel>(student);
                    students.Add(studentVM);
                }
                return students;


            }
        }

        internal List<ISyllabusViewModel> SyllabiViewData
        {
            get
            {
                var syllabi = new List<ISyllabusViewModel>();
                foreach (var syllabus in Syllabi.Where(s => !s.Deleted))
                {
                    var viewModel = _mapper.Map<ISyllabus, ISyllabusViewModel>(syllabus);
                    syllabi.Add(viewModel);
                }
                return syllabi;
            }
        }
      

    }
}
