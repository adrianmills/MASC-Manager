using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model
{
    public class Student : BaseModel, IStudent
    {
        public Address Address {get;set; }
        public long AddressId {get;set; }

        public bool Adult => throw new NotImplementedException();

        public int Age => throw new NotImplementedException();

        public Club Club {get;set; }
        public long ClubID {get;set; }
        public string ContactPhoneNumber {get;set; }
        public DateTime? DateofBirth {get;set; }
        public ICollection<StudentDisability> Disabilities {get;set; }
        public string EmailAddress {get;set; }
        public string Forename {get;set; }

        public string Fullname => throw new NotImplementedException();

        public string Grade {get;set; }
        public ICollection<GradingHistory> GradingHistories {get;set; }
        public DateTime? LastAttended {get;set; }
        public DateTime? LicenceRenewelDate {get;set; }
        public string ParentGuardian {get;set; }
        public string ReferralSource {get;set; }
        public DateTime? Started {get;set; }
        //public ICollection<StudentAward> StudentAwards {get;set; }
        public string Surname {get;set; }
        public Syllabus Syllabus {get;set; }
        public long SyllabusID {get;set; }
        public DateTime? UpdateDoneOn {get;set; }
    }
}
