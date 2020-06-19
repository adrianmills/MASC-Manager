using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DTO.Interface
{
    public interface IClubDTO:IBaseDTO
    {
        string ClubName { get; set; }
    }
}
