using Business_Logic.View_Model.Interface;
using System.Collections.Generic;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IClubData: IDataOperationAddAndUpdate<IClubViewModel>,
                                IDatabaseOperationDetail<IClubViewModel>
                                
    {
        IEnumerable<IClubViewModel> Clubs { get;  }

    }

   
}
