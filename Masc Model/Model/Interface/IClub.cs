using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Masc_Model.Model.Interface
{
    public interface IClub : IBase
    {
        [Required]
        [StringLength(15)]
        string Name { get; set; }
        
        [Required]
        long? ManagerID { get; set; }


        User Manager { get; set; }

        ICollection<Student> Students { get; set; }
    }
}
