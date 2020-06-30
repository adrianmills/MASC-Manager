using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DTO.Interface
{
   public interface ISyllabusDTO:IBaseDTO
    {
        long SyallbusID { get; set; }

        string SyllabusName { get; set; }
    }
}
