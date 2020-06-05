using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model
{
    public class Address : BaseModel, IAddress
    {
        public string AddressLine1 { get;set; }
        public string AddressLine2 { get;set; }
        public string AddressLine3 { get;set; }
        public string PostCode { get;set; }
        public string HomePhoneNumber { get;set; }
        public string OtherPhoneNumber { get;set; }
        public string EmailAddress { get;set; }
    }
}
