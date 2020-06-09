using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
 public   interface IGradingHistory : IBase
    {
       long StudentID { get; set; }

      long? GradeID { get; set; }

      DateTime GradingDate { get; set; }

 Student Student { get; set; }
Grade Grade { get; set; }


    }
}
