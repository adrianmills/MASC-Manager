﻿using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IClubData:IDataOperationFindAndDelete<IClub>
    {

        IEnumerable<IClub> Clubs { get; set; }
        void ProccessClubs(IEnumerable<IClub> clubs);

    }
}
