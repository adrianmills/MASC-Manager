using Business_Logic.DataRetrival;
using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO;
using Business_Logic.DTO.Interface;
using EntityFrameworkCore.Testing.NSubstitute;
using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Linq;

namespace UnitTest.Unit_Tests
{
    public class ClubUnitTests : TestBase
    {



        void seed(MASCContext context)
        {
            context.Clubs.Add(new Club { ID = 1, Name = "Club Test 1", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = false });
            context.Clubs.Add(new Club { ID = 2, Name = "Club Test 2", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = false });
            context.Clubs.Add(new Club { ID = 3, Name = "Club Test 3", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = true });
            context.SaveChanges();
        }

        [Test]
        public void ClubData_Add1Club()
        {
            MASCContext context = Context;
            seed(context);
                var clubData = new ClubData(context, user);

                var dataitems = new ClubDataItems();

                dataitems.Clubs.Add(new ClubDTO { ClubName = "Test 1" });

                clubData.ProccessClubs(dataitems);

                Assert.AreEqual(3, clubData.Clubs.Count());

            CleanUp(context);


        }

        [Test]
        public void ClubData_Add2Clubs()
        {

            MASCContext context = Context;
            seed(context);
                var clubData = new ClubData(context, user);

                var dataitems = new ClubDataItems();

                dataitems.Clubs.Add(new ClubDTO { ClubName = "Test 1" });
                dataitems.Clubs.Add(new ClubDTO { ClubName = "Test 2" });

                clubData.ProccessClubs(dataitems);

                Assert.AreEqual(4, clubData.Clubs.Count());
            CleanUp(context);

        }

        [Test]
        public void ClubData_GetList()
        {
            MASCContext context = Context;

                seed(context);
                var clubData = new ClubData(context, user);
                Assert.AreEqual(2, clubData.Clubs.Count());
            
           CleanUp(context);
            

        }

        [Test]
        public void ClubData_DeleteClub()
        {
            MASCContext context = Context;

            seed(context);
                var clubData = new ClubData(context, user);
                var clubDataItems = new ClubDataItems();
                clubDataItems.DeletedClubs.Add(new ClubDTO { ID = 1, ClubName = "Club Test 1" });

                clubData.ProccessClubs(clubDataItems);

                var deletedClubs = from c in context.Clubs
                                   where c.Deleted
                                   select c;

                Assert.AreEqual(2, deletedClubs.Count());

           CleanUp(context);

       
        }

        [Test]
        public void ClubData_ChangeClubName()
        {
            MASCContext context = Context;

            seed(context);
            var clubData = new ClubData(context, user);
            var clubDataItems = new ClubDataItems();

            clubDataItems.Clubs.Add(new ClubDTO { ID = 2, ClubName = "Name Change 2" });

            clubData.ProccessClubs(clubDataItems);

            var club = (from c in context.Clubs
                       where c.ID == 2
                       select c).FirstOrDefault();

            Assert.AreEqual("Name Change 2", club.Name);
        }

        [Test]
        public void ClubData_MultipleOperations()
        {
            MASCContext context = Context;

            seed(context);
            var clubData = new ClubData(context, user);
            var clubDataItems = new ClubDataItems();

            clubDataItems.Clubs.Add(new ClubDTO { ID = 2, ClubName = "Name Change 2" });
            clubDataItems.Clubs.Add(new ClubDTO { ClubName = "Club Test Multiple Operations 1" });
            clubDataItems.Clubs.Add(new ClubDTO { ClubName = "Club Test Multiple Operations 2" });
            clubDataItems.Clubs.Add(new ClubDTO { ClubName = "Club Test Multiple Operations 3" });
            clubDataItems.DeletedClubs.Add(new ClubDTO { ID = 1, ClubName = "Club Test 1" });

            clubData.ProccessClubs(clubDataItems);

            var club = (from c in context.Clubs
                        where c.ID == 2
                        select c).FirstOrDefault();
            var clubs = from c in context.Clubs
                        where !c.Deleted
                        select c;
            var deletedclubs = from c in context.Clubs
                        where c.Deleted
                        select c;

            Assert.AreEqual("Name Change 2", club.Name);
            Assert.AreEqual(2, deletedclubs.Count());
            Assert.AreEqual(4, clubs.Count());

            CleanUp(context);
        }

        void CleanUp(MASCContext context)
        {
            context.Dispose();
           CleanUp(context);
        }
    }
}
