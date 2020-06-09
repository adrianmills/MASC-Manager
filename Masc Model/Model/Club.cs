﻿using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model
{
    public class Club : BaseModel, IClub
    {
        public string Name { get;set;}
        public ICollection<Student> Students { get;set;}
    }
}
