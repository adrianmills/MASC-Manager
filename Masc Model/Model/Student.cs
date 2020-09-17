using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Schema;

namespace Masc_Model.Model
{
    public class Student : BaseModel, IStudent
    {
        public Address Address {get;set; }

        [Required]
        public long AddressId {get;set; }

        public Club Club {get;set; }
        [Required]
        public long ClubID {get;set; }
        [Required]
        [StringLength(20)]
        public string ContactPhoneNumber {get;set; }
        
        [Required]
        public DateTime? DateofBirth {get;set; }

        public ICollection<StudentDisability> Disabilities {get;set; }
        [Required]
        [StringLength(50)]
        public string EmailAddress {get;set; }
        [Required]

        public string Forename {get;set; }
   
        public ICollection<GradingHistory> GradingHistories {get;set; }
        public DateTime? LastAttended {get;set; }
        public DateTime? LicenceRenewelDate {get;set; }
        [StringLength(50)]
        public string ParentGuardian {get;set; }
        [StringLength(20)]
        public string ReferralSource {get;set; }
        public DateTime? Started {get;set; }
        //public ICollection<StudentAward> StudentAwards {get;set; }
        [Required]
        [StringLength(20)]
        public string Surname {get;set; }

        public DateTime? UpdateDoneOn {get;set; }
        public long GradeID { get; set; }

        [ForeignKey("GradeID")]
        public Grade CurrentGrade { get; set; }
    }
}
