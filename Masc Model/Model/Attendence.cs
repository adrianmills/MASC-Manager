using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model
{
    public class Attendence : BaseModel, IAttendance
    {
        public long StudentID { get;set; }
        public DateTime Date { get;set; }
        public Student Student { get;set; }
    }
}
