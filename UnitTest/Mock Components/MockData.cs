using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO;
using Business_Logic.DTO.Interface;
using Business_Logic.View_Model.Interface;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.VisualBasic;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;

namespace UnitTest.Mock_Components
{
    public class MockData
    {


        internal List<IUser> Users
        {
            get
            {
                var users = new List<IUser>();

                users.Add(new User { ID = 1, UserName = "Test User 1", Manager = true }) ;
                users.Add(new User { ID = 2, UserName = "Test User 2", Manager=false });

                return users;
            }
        }

      internal List<IClub> MockClubs
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

       internal List<IStudent> MockStudents
        {
            get
            {
                var students = new List<IStudent>();

                students.Add(new Student { ClubID = 1, DateofBirth = new DateTime(1973, 8, 3),Forename="Marty",Surname="Mcfly",ContactPhoneNumber="Test1" });
                students.Add(new Student { ClubID = 1, DateofBirth = new DateTime(2004, 11, 29), Forename = "George", Surname = "Mcfly", ContactPhoneNumber = "Test2" });
                students.Add(new Student { ClubID = 1, DateofBirth = new DateTime(2004, 11, 29), Forename = "George", Surname = "Mcfly", ContactPhoneNumber = "Test2" });


                return students;
            }

        }
        internal List<ISyllabus> MockSyllabi
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
        internal List<IClubViewModel> MockClubsViewData
        {
            get
            {
                var clubs = new List<IClubViewModel>();

                return clubs;
            }
        }

        internal List<ISyllabusDTO> MOCKSyllabusDTOs
        {
            get
            {
                var syallbi = new List<ISyllabusDTO>();


                foreach(var s in MockSyllabi.Where(s=>!s.Deleted))
                {
                    syallbi.Add(new SyllabusDTO { ID = s.ID, SyllabusName = s.Name });
                }


                return syallbi;


            }
        }

      

    }
}
