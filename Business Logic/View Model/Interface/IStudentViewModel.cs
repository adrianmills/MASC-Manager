using Masc_Model.Model.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business_Logic.View_Model.Interface
{
   public interface IStudentViewModel: IViewModelBase
    {
        string Grade { get; set; }
        bool Adult { get; }
        int Age { get; }
        string Fullname { get; }

        SelectList Clubs { get; set; }

        SelectList Syllabi { get; set; }
    }
}
