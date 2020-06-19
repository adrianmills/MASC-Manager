using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using System;

namespace UnitTest
{
    public abstract class TestBase
    {
        MASCContext _context;
        IUser _user;

        internal MASCContext Context
        {
            get
            {

                if(_context == null)
                {
                    GenerateContext generateContext = new GenerateContext();
                    _context = generateContext.GetContext();
                }


                return _context;
            }
        }

       internal IUser User
        {
            get
            {
                if (_user == null)
                {
                    _user = new User { UserName = "Unit Test", EmailAddress = "test" };
                }

                return _user;
            }
        }

        void PopulateDetails(IBase record, bool newRecord = false )
        {
           if(newRecord)
            {
                record.CreatedBy = "Unit Test";
                record.CreatedOn = DateTime.Now;
                
            }
           else
            {
                record.ModifiedBy = "Unit Test";
                record.ModifiedOn = DateTime.Now;
            }

            record.Deleted = false;
        }
    }
}
