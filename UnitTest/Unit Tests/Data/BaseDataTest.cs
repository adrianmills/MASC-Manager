using AutoMapper;
using Business_Logic.AutoMapProfiles;
using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.AspNetCore.SignalR.Protocol;
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
        protected IUser userNoManager;
        protected IUser userManager;
        protected IMapper mapper;

        protected MockData data = new MockData();
        public BaseDataTest()
        {
            


        }

        [SetUp]
        public void Configure()
        {
            userManager = new User { ID = 1, UserName = "Unit Test Manager", Deleted = false, CreatedBy = "am", CreatedOn = DateTime.Now, Manager = true };
            userNoManager = new User { ID = 2, UserName = "Unit test Not a Manager", Deleted = false, CreatedBy = "am", CreatedOn = DateTime.Now, Manager = false };

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MASCProfiles());
            });

            mapper = config.CreateMapper();
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
