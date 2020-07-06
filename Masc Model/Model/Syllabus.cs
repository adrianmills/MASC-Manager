using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Masc_Model.Model
{
    public class Syllabus : BaseModel, ISyllabus
    {
        [Required]
        [StringLength(30)]
        public string Name { get;set; }
        public ICollection<Student> Students { get;set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
