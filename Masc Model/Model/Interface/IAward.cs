using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model.Interface
{
    public interface IAward
    {
   string Name { get; set; }

 string ImagePath { get; set; }

long? ClubID { get; set; }

 DateTime? StartDate { get; set; }

 DateTime? EndDate { get; set; }
 int? NumberofSessions { get; set; }


         Club Club { get; set; }

         ICollection<StudentAward> Students { get; set; }
        List<Club> Clubs { get; set; }
    }
}
