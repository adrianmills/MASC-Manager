using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
    public interface IStudentDisability : IBase
    {

        long StudentID { get; set; }

        long DisabilityID { get; set; }

        Student Student { get; set; }

        Disablity Disablity { get; set; }




    }
}
