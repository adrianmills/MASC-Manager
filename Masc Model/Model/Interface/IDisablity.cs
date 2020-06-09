using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
   public interface IDisablity : IBase
    {
        string Name { get; set; }

         ICollection<StudentDisability> Students { get; set; }
    }
}
