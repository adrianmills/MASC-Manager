using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Masc_Model.Model
{
 public   class Grade : BaseModel, IGrade
    {
        [Required]
        [StringLength(20)]
        public string Name { get;set;}

        [Required]
        public long SyllabusID { get;set;}
        public ICollection<GradingHistory> GradingHistories { get;set;}

        [ForeignKey("SyllabusID")]
        public Syllabus Syllabus { get;set;}
        public ICollection<Student> Students { get; set; }
    }
}
