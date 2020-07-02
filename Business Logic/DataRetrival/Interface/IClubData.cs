using Business_Logic.DataRetrival.Data_Items.Interface;
using Business_Logic.DTO;
using Business_Logic.DTO.Interface;
using Business_Logic.View_Model.Interface;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IClubData: IDataOperationAddAndUpdate<IClubViewModel>,
                                IDatabaseOperationDetail<IClubViewModel>
                                
    {
        IEnumerable<IClubViewModel> Clubs { get;  }

    }

   
}
