using Masc_Model.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DataRetrival.Interface
{
    public interface ILogin
    {
        IUser Login(string username, string password);

        IUser Register(string username, string password);
    }
}
