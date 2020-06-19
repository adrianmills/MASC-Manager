using Business_Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DTO
{
    public class BaseDTO :IBaseDTO
    {
        public long ID { get; set; }
    }
}
