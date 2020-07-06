using Business_Logic.View_Model.Interface;
using System.Collections.Generic;

namespace Business_Logic.DataRetrival.Interface
{
    public interface ISyllabusData : IDataOperationAddAndUpdate<ISyllabusViewModel>,
                                     IDatabaseOperationDetail<ISyllabusViewModel>
    {
        IEnumerable<ISyllabusViewModel> Syllabi { get; }
        
    }


   

}
