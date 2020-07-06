using Business_Logic.View_Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.View_Model
{
    public class SyllabusViewModel : ISyllabusViewModel
    {
        public long SyllabusID { get;set; }
        public string SyllabusName { get;set; }
        public ICollection<IStudentViewModel> Students { get;set; }
        public ICollection<IGradeViewModel> Grades { get;set; }

        public SyllabusViewModel()
        {
            Students = new List<IStudentViewModel>();
            Grades =new List<IGradeViewModel>();
        }
    }
}
