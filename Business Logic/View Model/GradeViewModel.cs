using Business_Logic.View_Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.View_Model
{
    public class GradeViewModel : IGradeViewModel

    {
        public long GradeID { get;set; }
        public string GradeName { get;set; }
        public string Syllabus { get;set; }
        public List<IStudentViewModel> Students { get;set; }
    }
}
