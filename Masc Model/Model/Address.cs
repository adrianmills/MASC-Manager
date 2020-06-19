using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Masc_Model.Model
{
    public class Address : BaseModel, IAddress
    {
        [Required]
        [StringLength(50)]
        public string AddressLine1 { get;set; }
        [StringLength(50)]
        public string AddressLine2 { get;set; }
        [StringLength(50)]
        public string AddressLine3 { get;set; }
        [Required]
        [StringLength(15)]
        public string PostCode { get;set; }

        [Required]
        [StringLength(20)]
        public string HomePhoneNumber { get;set; }

        [StringLength(20)]
        public string OtherPhoneNumber { get;set; }

        [Required]
        [StringLength(20)]
        public string EmailAddress { get;set; }
        public ICollection<Student> Students { get; set; }
    }
}
