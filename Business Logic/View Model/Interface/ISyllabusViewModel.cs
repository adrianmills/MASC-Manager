using System.Collections.Generic;

namespace Business_Logic.View_Model.Interface
{
    public interface ISyllabusViewModel: IViewModelBase
    {

        long SyllabusID { get; set; }
        string SyllabusName { get; set; }

        ICollection<IStudentViewModel> Students { get; set; }

        ICollection<IGradeViewModel> Grades { get; set; }
    }
}
