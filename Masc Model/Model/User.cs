using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Masc_Model.Model
{
    public class User : BaseModel, IUser
    {
        [Required]
        [StringLength(20)]
        public string UserName {get;set;}
        public byte[] Password {get;set;}
        public byte[] Salt {get;set;}
        public bool ChangePasswordOnLogon {get;set;}

        [Required]
        [StringLength(100)]
        public string EmailAddress {get;set;}
        public int LogOnAttempts {get;set;}
        public DateTime? LastLoggedOn {get;set;}
        public bool AccountLocked {get;set;}
    }
}
