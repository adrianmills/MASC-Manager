﻿using Business_Logic.DTO;
using Business_Logic.DTO.Interface;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IClubData:IDataOperationFindAndDelete<IClub>
    {
        IEnumerable<IClubDTO> Clubs { get;  }
        bool ProccessClubs(IClubDataItems dataItems);

    }

    public interface IClubDataItems
    {
        List<ClubDTO> Clubs { get; set; }

        List<ClubDTO> DeletedClubs { get; set; }
    }
}
