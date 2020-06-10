using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
   public interface IDirty
    {

        bool New { get; set; }

        bool Changed { get; set; }
    }
}
