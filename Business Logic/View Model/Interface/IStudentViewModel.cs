using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.View_Model.Interface
{
   public interface IStudentViewModel
    {

        IStudent Student { get; set; }

        List<IClub> Clubs { get; set; }

        List<ISyllabus> Syllabi { get; set; }
    }
}
