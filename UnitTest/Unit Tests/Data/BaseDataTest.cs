using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Mock_Components;

namespace UnitTest.Unit_Tests.Data
{
    public abstract class BaseDataTest
    {
        internal IUser user;

        internal MockData data = new MockData();
        public BaseDataTest()
        {
            user = new User { ID = 1, UserName = "Unit Test", Deleted = false, CreatedBy = "am", CreatedOn = DateTime.Now };
        }

        internal DbContextOptions<MASCContext> ContextOptions
        {
            get
            {
                return new DbContextOptionsBuilder<MASCContext>()
                    .UseInMemoryDatabase(databaseName: "MASCManager", new InMemoryDatabaseRoot())
                    .Options;



               




            }
        }
    }
}
