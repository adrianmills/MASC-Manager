using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Masc_Model.Model.Interface
{
    public class GradingHistory : BaseModel, IGradingHistory
    {
        public long StudentID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? GradeID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime GradingDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [ForeignKey("StudentID")]
        public Student Student { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [ForeignKey("GradeID")]
        public Grade Grade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
