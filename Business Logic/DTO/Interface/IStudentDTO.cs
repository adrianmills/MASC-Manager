using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DTO.Interface
{
    public interface IStudentDTO:IBaseDTO
    {
        long StudentID { get; set; }

        string StudentName { get; set; }

        string Club { get; set; }
    }
}
