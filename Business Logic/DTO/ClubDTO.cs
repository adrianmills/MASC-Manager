using Business_Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DTO
{
    public class ClubDTO : BaseDTO, IClubDTO
    {
        public long ClubID
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }
        public string ClubName { get; set; }
    }
}
