using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Masc_Model.Model
{
    public class StudentAward : BaseModel, IStudentAward
    {
        public long AwardID { get;set;}
        public long StudentID { get;set;}
        public DateTime Attained { get;set;}
        [ForeignKey("StudentID")]
        public Student Student { get;set;}

        [ForeignKey("AwardID")]
        public Award Award { get;set;}

    }
}
