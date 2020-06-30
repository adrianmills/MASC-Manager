using Business_Logic.DataRetrival.Data_Items.Interface;
using Business_Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Data_Items
{
    public class ClubDataItems : IClubDataItems
    {

        public ClubDataItems()
        {
            Clubs = new List<ClubDTO>();
            DeletedClubs = new List<ClubDTO>();
        }

        public List<ClubDTO> Clubs { get; set; }
        public List<ClubDTO> DeletedClubs { get; set; }
      
    }
}
