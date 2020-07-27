using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business_Logic.View_Model.Interface
{
    public interface ISyllabusViewModel: IViewModelBase
    {

        long SyllabusID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Syllabus Name")]
        string SyllabusName { get; set; }

        IEnumerable<IStudentViewModel> Students { get; set; }

        IEnumerable<IGradeViewModel> Grades { get; set; }
    }
}
