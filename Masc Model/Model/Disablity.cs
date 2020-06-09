using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model
{
   public class Disablity : BaseModel, IDisablity
    {
        public string Name { get; set; }

        public ICollection<StudentDisability> Students { get; set; }
    }
}
