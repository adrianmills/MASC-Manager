﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DTO.Interface
{
    public interface IClubDTO:IBaseDTO
    {
        long ClubID { get; set; }
        string ClubName { get; set; }
    }
}
