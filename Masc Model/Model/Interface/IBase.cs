using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
  public  interface IBase
    {

         long ID { get; set; }

         DateTime DateCreated { get; set; }

         string CreatedBy { get; set; }


         string ModifiedBy { get; set; }

         DateTime? ModifiedOn { get; set; }

         bool Deleted { get; set; }

       bool Updated { get; set; }
        bool New { get; set; }
    }
}
