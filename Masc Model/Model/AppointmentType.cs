using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.Model
{
    class AppointmentType : BaseModel, IAppointmentType
    {
        public string Name { get; set; }
    }
}
