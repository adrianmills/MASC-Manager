using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
  public   interface IUser
    {
 string UserName { get; set; }

 byte[] Password { get; set; }

byte[] Salt { get; set; }
bool ChangePasswordOnLogon { get; set; }
 string EmailAddress { get; set; }

         int LogOnAttempts { get; set; }

         DateTime? LastLoggedOn { get; set; }
        bool AccountLocked { get; set; }
    }
}
