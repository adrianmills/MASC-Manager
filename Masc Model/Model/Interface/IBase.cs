using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
  public  interface IBase
    {

         long ID { get; set; }

         DateTime CreatedOn { get; set; }

         string CreatedBy { get; set; }


         string ModifiedBy { get; set; }

         DateTime? ModifiedOn { get; set; }

         bool Deleted { get; set; }

    }
}
