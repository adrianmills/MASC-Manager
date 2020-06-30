using Business_Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Data_Items.Interface
{
    public interface IClubDataItems
    {
        List<ClubDTO> Clubs { get; set; }

        List<ClubDTO> DeletedClubs { get; set; }
    }
}
