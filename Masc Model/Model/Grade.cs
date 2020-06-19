using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Masc_Model.Model
{
 public   class Grade : BaseModel, IGrade
    {
        [Required]
        [StringLength(20)]
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Required]
        public long SyllabusID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<GradingHistory> GradingHistories { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
