﻿using Business_Logic.DataRetrival;
using Business_Logic.DTO;
using Masc_Model.DAL;
using Masc_Model.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest.Unit_Tests.Data
{
   public class ClubDataTests:BaseDataTest
    {
        void seed(MASCContext context)
        {
            foreach (var c in data.MockClubs)
            {
                context.Clubs.Add((Club) c);
            }
            context.SaveChanges();
        }

        [Test]
        public void Add1Club()
        {


            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var clubData = new ClubData(context, user);

                var dataitems = new ClubDataItems();

                dataitems.Clubs.Add(new ClubDTO { ClubName = "Test 1" });

                clubData.ProccessClubs(dataitems);

                Assert.AreEqual(3, clubData.Clubs.Count());


            }


        }

        [Test]
        public void Add2Clubs()
        {


            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var clubData = new ClubData(context, user);

                var dataitems = new ClubDataItems();

                dataitems.Clubs.Add(new ClubDTO { ClubName = "Test 1" });
                dataitems.Clubs.Add(new ClubDTO { ClubName = "Test 2" });

                clubData.ProccessClubs(dataitems);

                Assert.AreEqual(4, clubData.Clubs.Count()); 
            }


        }

  
        [Test]
        public void GetList()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context, user);
                Assert.AreEqual(2, clubData.Clubs.Count());
            }

        }


        [Test]
      
        public void DeleteClub()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context, user);
                var clubDataItems = new ClubDataItems();
                clubDataItems.DeletedClubs.Add(new ClubDTO { ID = 1, ClubName = "Club Test 1" });

                clubData.ProccessClubs(clubDataItems);

                var deletedClubs = from c in context.Clubs
                                   where c.Deleted
                                   select c;

                Assert.AreEqual(2, deletedClubs.Count());

            }


        }

        [Test]
      
        public void ChangeClubName()
        {
            using (var context = new MASCContext(ContextOptions))
            {

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
        }

        [Test]
      
        public void MultipleOperations()
        {
            using (var context = new MASCContext(ContextOptions))
            {

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

                Assert.AreEqual(4, clubs.Count());

                Assert.AreEqual(2, deletedclubs.Count());

            }
        }

    }
}