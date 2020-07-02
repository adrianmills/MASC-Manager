using Masc_Model.Model.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business_Logic.View_Model.Interface
{
   public interface IStudentViewModel: IViewModelBase
    {
        string Grade { get; set; }
        bool Adult { get; }
        int Age { get; }
        string Fullname { get; }

        SelectList Clubs { get; set; }

        SelectList Syllabi { get; set; }

        long StudentID { get; set; }

        long AddressId { get; set; }

        string ClubName { get; set; }
        long ClubID { get; set; }

        string ContactPhoneNumber { get; set; }
        DateTime? DateofBirth { get; set; }
        string EmailAddress { get; set; }
        string Forename { get; set; }

        ICollection<GradingHistory> GradingHistories { get; set; }
        DateTime? LastAttended { get; set; }
        DateTime? LicenceRenewelDate { get; set; }
        string ParentGuardian { get; set; }
        string ReferralSource { get; set; }
        DateTime? Started { get; set; }
        string Surname { get; set; }
        string SyllabusName { get; set; }
        long SyllabusID { get; set; }
        DateTime? UpdateDoneOn { get; set; }
    }
}
