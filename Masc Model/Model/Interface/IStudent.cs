using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Masc_Model.Model.Interface
{
    public interface IStudent : IBase
    {
        [ForeignKey("AddressID")]
        Address Address { get; set; }
        long AddressId { get; set; }

        Club Club { get; set; }
        long ClubID { get; set; }

        string ContactPhoneNumber { get; set; }
        DateTime? DateofBirth { get; set; }
        ICollection<StudentDisability> Disabilities { get; set; }
        string EmailAddress { get; set; }
        string Forename { get; set; }
        
        
        ICollection<GradingHistory> GradingHistories { get; set; }
        DateTime? LastAttended { get; set; }
        DateTime? LicenceRenewelDate { get; set; }
        string ParentGuardian { get; set; }
        string ReferralSource { get; set; }
        DateTime? Started { get; set; }
        //ICollection<StudentAward> StudentAwards { get; set; }
        string Surname { get; set; }
        DateTime? UpdateDoneOn { get; set; }
        long GradeID { get; set; }
        Grade CurrentGrade { get; set; }

    }
}
