using Business_Logic.View_Model.Interface;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
   
   public interface IStudentData : IDataOperationFindAndDelete<IStudent>, IDataOperationAddAndUpdate<IStudent>
    {

        IEnumerable<IStudent> Students { get;}

        void PopulateLists(IStudentViewModel viewModel);
    }
}
