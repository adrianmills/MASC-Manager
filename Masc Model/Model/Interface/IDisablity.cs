using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
   public interface IDisablity
    {
        string Name { get; set; }

        virtual ICollection<StudentDisability> Students { get; set; }
    }
}
