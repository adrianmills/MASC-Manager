using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Masc_Model.Model
{
    public class StudentDisability : BaseModel, IStudentDisability
    {
        public long StudentID { get;set; }
        public string Disability { get;set;}
        [ForeignKey("StudentID")]
        public Student Student { get;set; }
    //    [ForeignKey("DisabilityID")]
    //    public Disablity Disablity { get;set; }
    }
}
