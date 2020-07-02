using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Masc_Model.Model
{
    public class Club : BaseModel, IClub, IStudentCollection
    {
        [Required]
        [StringLength(15)]
        public string Name { get;set;}
        public ICollection<Student> Students { get;set;}

        [Required]
      public  long ManagerID { get; set; }

        [ForeignKey("ManagerID")]
        public virtual User Manager { get; set; }
    }
}
