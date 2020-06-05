using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
   public interface IAddress
    {
         string AddressLine1 { get; set; }
         string AddressLine2 { get; set; }
         string AddressLine3 { get; set; }
         string PostCode { get; set; }

         string HomePhoneNumber { get; set; }
         string OtherPhoneNumber { get; set; }
         string EmailAddress { get; set; }

         virtual ICollection<Student> Students { get; set; }
    }
}
}
