using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
   public  interface IStudentCollection
    {
        ICollection<Student> Students { get; set; }
    }
}
