using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival
{
    public class SyllabusDataItems : ISyllabusDataItems
    {
        public List<ISyllabusDTO> Syllabi { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ISyllabusDTO> DeletedSyllabi { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
