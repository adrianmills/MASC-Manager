﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.View_Model.Interface
{
   public  interface IStudentCollection
    {
        List<IStudentViewModel> Students { get; set; }
    }
}
