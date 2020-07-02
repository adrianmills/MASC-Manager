using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Logic.View_Model.Interface
{
    public interface IClubViewModel: IViewModelBase
    {
        long ClubID { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name ="Club Name")]
        string ClubName { get; set; }

        string Manager { get; set; }

        [Required]
        [Display(Name = "Manager")]
        long? ManagerID { get; set; }

        IEnumerable<IStudentViewModel> Students { get; set; }
    }
}
