using Business_Logic.DTO.Interface;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{
    public interface ISyllabusData : IDataOperationFindAndDelete<ISyllabus>
    {
        IEnumerable<ISyllabusDTO> Syllabi { get; }
        bool ProccessSyllabi(ISyllabusDataItems dataItems);
    }


    public interface ISyllabusDataItems
        {

         List<ISyllabusDTO> Syllabi { get; set; }

        List<ISyllabusDTO> DeletedSyllabi { get; set; }
    }

}
