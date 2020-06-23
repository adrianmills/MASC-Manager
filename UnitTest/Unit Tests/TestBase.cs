using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Unit_Tests
{
  public abstract  class TestBase
    {
       internal IUser user;

        [SetUp]
        public void Intilise()
        {
            user = new User { ID = 1, UserName = "Unit Test", Deleted = false, CreatedBy = "am", CreatedOn = DateTime.Now };
        }

        internal MASCContext Context
        {
            get
            {
                var options = new DbContextOptionsBuilder<MASCContext>()
                    .UseInMemoryDatabase(databaseName: "MASCManager", new InMemoryDatabaseRoot())
                    .Options;



                var context = new MASCContext(options);


                return context;



            }
        }
    }
}
