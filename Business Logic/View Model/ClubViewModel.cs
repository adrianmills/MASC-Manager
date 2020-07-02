using Business_Logic.View_Model.Interface;
using Masc_Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Logic.View_Model
{
    public class ClubViewModel : IClubViewModel
    {
     public  long ClubID { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Club Name")]
        public string ClubName { get; set; }

        public string Manager { get; set; }

        [Required]
        [Display(Name = "Manager")]
        public long? ManagerID { get; set; }

        public IEnumerable<IStudentViewModel> Students { get; set; }
    }
}
