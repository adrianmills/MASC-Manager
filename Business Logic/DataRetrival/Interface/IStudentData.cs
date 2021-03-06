﻿using Business_Logic.View_Model.Interface;
using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic.DataRetrival.Interface
{

    public interface IStudentData : IDataOperationAddAndUpdate<IStudentViewModel>,
                                    IDatabaseOperationDetail<IStudentViewModel>,
                                    IPopulateLists<IStudentViewModel>
    {

        IEnumerable<IStudentViewModel> Students { get; }

    }
}
