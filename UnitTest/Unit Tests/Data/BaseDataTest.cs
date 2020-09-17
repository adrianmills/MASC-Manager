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
        protected IUser usernotMangerwithNoClubs; 
        protected IMapper mapper;

        protected MockData data;
        public BaseDataTest()
        {
            


        }
        protected virtual void seed(MASCContext context)
        {
            foreach (var u in data.Users)
            {
                context.Users.Add((User)u);
            }
        }
        [SetUp]
        public void Configure()
        {
            userManager = new User { ID = 1, UserName = "Unit Test Manager", Deleted = false, CreatedBy = "am", CreatedOn = DateTime.Now, Manager = true };
            userNoManager = new User { ID = 2, UserName = "Unit test Not a Manager", Deleted = false, CreatedBy = "am", CreatedOn = DateTime.Now, Manager = false };
            usernotMangerwithNoClubs = new User { ID = 3, UserName = "Unit test Not a Manager", Deleted = false, CreatedBy = "am", CreatedOn = DateTime.Now, Manager = false };

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MASCProfiles());
            });

            mapper = config.CreateMapper();
            data = new MockData(mapper);
        }

        internal DbContextOptions<MASCContext> ContextOptions
        {
            get
            {
                return new DbContextOptionsBuilder<MASCContext>()
                    .UseInMemoryDatabase(databaseName: "MASCManager", new InMemoryDatabaseRoot())
                    .EnableServiceProviderCaching(false)
                    .Options;



               




            }
        }
    }
}
