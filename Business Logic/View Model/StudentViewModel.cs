using Business_Logic.View_Model.Interface;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.View_Model
{
    public class StudentViewModel : IStudentViewModel
    {
        public string Grade { get;set;}

        public bool Adult {
            get 
            {
                bool adult = false;
            if(Age>=18)
                { adult = true; }

                return adult;
            }

        }

        public int Age
        {
            get
            {
                int age = 0;

                if (DateofBirth.HasValue)
                {
                    DateTime dob = DateofBirth.Value;
                    age = DateTime.Now.Year - dob.Year;

                    if (DateTime.Now.DayOfYear < dob.DayOfYear)
                        age = age - 1;
                }

                return age;
            }
        }

        public string Fullname {get;}

        public SelectList Clubs { get;set;}
        public SelectList Syllabi { get;set;}


        public Address Address { get;set;}
        public long AddressId { get;set;}
        public Club Club { get;set;}
        public long ClubID { get;set;}
        public string ContactPhoneNumber { get;set;}
        public DateTime? DateofBirth { get;set;}
        public ICollection<StudentDisability> Disabilities { get;set;}
        public string EmailAddress { get;set;}
        public string Forename { get;set;}
        public ICollection<GradingHistory> GradingHistories { get;set;}
        public DateTime? LastAttended { get;set;}
        public DateTime? LicenceRenewelDate { get;set;}
        public string ParentGuardian { get;set;}
        public string ReferralSource { get;set;}
        public DateTime? Started { get;set;}
        public string Surname { get;set;}
        public Syllabus Syllabus { get;set;}
        public long SyllabusID { get;set;}
        public DateTime? UpdateDoneOn { get;set;}
        public long ID { get;set;}
        public bool Deleted { get;set;}
    }
}
