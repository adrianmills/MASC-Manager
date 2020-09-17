using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
   public interface IGrade : IBase
    {
 string Name { get; set; }

 long SyllabusID { get; set; }

        Syllabus Syllabus { get; set; }
ICollection<GradingHistory> GradingHistories { get; set; }

        ICollection<Student> Students { get; set; }
    }
}
