using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
  public  interface IStudentAward
    {

        long AwardID { get; set; }

        long StudentID { get; set; }

        DateTime Attained { get; set; }

        
         Student Student { get; set; }
Award Award { get; set; }
    }
}
