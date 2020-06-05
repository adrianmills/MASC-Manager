using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
 public    interface IAttendance
    {
        long StudentID { get; set; }

        DateTime Date { get; set; }

        Student Student { get; set; }
    }
}
