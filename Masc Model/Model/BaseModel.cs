using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Masc_Model.Model
{
    public abstract class BaseModel 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID {get;set;}
        [Required]
        public DateTime CreatedOn {get;set;}

        [Required]
        [StringLength(50)]
        public string CreatedBy {get;set;}
        [StringLength(50)]
        public string ModifiedBy {get;set;}
        public DateTime? ModifiedOn {get;set;}
        public bool Deleted {get;set;}

    }
}
