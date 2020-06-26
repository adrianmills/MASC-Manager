using Business_Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DTO
{
    public class SyllabusDTO : BaseDTO, ISyllabusDTO
    {
        public long SyallbusID { get; set; }
        public string SyllabusName { get; set; }
    }
}
