using Business_Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DTO
{
    public class ClubDTO : BaseDTO, IClubDTO
    {
        public string ClubName { get; set; }
    }
}
