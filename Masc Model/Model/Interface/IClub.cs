using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
    public interface IClub : IBase
    {
        string Name { get; set; }
        

        long ManagerID { get; set; }


        User Manager { get; set; }

    }
}
