using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Razor.Generator;

namespace Business_Logic.View_Model.Interface
{
    public interface IGradeViewModel : IViewModelBase
    {
        long GradeID { get; set; }

        string GradeName { get; set; }

        string Syllabus { get; set; }


        List<IStudentViewModel> Students
        {
            get;set;
        }
    }
}
