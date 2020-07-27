using Business_Logic.View_Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Logic.View_Model
{
    public class SyllabusViewModel : ISyllabusViewModel
    {

        [Required]
        public long SyllabusID { get;set; }

        [Required]
        [StringLength(20,ErrorMessage ="Syllbus Name Cannot be more than 20 characters.")]
        [Display(Name = "Syllabus Name")]
        public string SyllabusName { get;set; }
        public IEnumerable<IStudentViewModel> Students { get;set; }
        public IEnumerable<IGradeViewModel> Grades { get;set; }

        public SyllabusViewModel()
        {
            Students = new List<IStudentViewModel>();
            Grades =new List<IGradeViewModel>();
        }
    }
}
