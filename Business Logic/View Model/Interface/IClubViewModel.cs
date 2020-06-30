using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.View_Model.Interface
{
    public interface IClubViewModel: IViewModelBase
    {
        long ClubID { get; set; }
        
        string ClubName { get; set; }

        string Manager { get; set; }

        long ManagerID { get; set; }

        IEnumerable<IStudentViewModel> Students { get; set; }
    }
}
