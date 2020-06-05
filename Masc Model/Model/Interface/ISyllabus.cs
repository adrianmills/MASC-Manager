using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
   public interface ISyllabus
    {

        string Name { get; set; }

        ICollection<Student> Students { get; set; }
    }
}
