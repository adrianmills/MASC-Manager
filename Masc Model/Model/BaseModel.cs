using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Masc_Model.Model
{
    public abstract class BaseModel : IBase
    {
        [Key]
        public long ID {get;set;}
        [Required]
        public DateTime DateCreated {get;set;}
        public string CreatedBy {get;set;}
        public string ModifiedBy {get;set;}
        public DateTime? ModifiedOn {get;set;}
        public bool Deleted {get;set;}
    }
}
