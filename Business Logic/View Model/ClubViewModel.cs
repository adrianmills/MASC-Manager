using Business_Logic.View_Model.Interface;
using Masc_Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.View_Model
{
    public class ClubViewModel : IClubViewModel
    {
     public  long ClubID { get; set; }

        public string ClubName { get; set; }

        public string Manager { get; set; }

        public long ManagerID { get; set; }

        public IEnumerable<IStudentViewModel> Students { get; set; }
    }
}
