using AutoMapper;
using Business_Logic.DataRetrival;
using Business_Logic.DataRetrival.Data_Items;
using Business_Logic.DTO;
using Masc_Model.DAL;
using Masc_Model.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTest.Mock_Components;

namespace UnitTest.Unit_Tests.Data
{
   public class ClubDataTests:BaseDataTest
    {
        

        
        void seed(MASCContext context)
        {
            foreach(var u in data.Users)
            {
                context.Users.Add((User) u);
            }
         

            foreach (var c in data.MockClubs)
            {
                context.Clubs.Add((Club) c);
            }

         var   saveitems=context.SaveChanges();
        }

        [Test]
        public void Add1Club()
        {


            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var clubData = new ClubData(context, mapper,userManager );

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
                var clubData = new ClubData(context, mapper,userManager);

                var dataitems = new ClubDataItems();

                dataitems.Clubs.Add(new ClubDTO { ClubName = "Test 1" });
                dataitems.Clubs.Add(new ClubDTO { ClubName = "Test 2" });

                clubData.ProccessClubs(dataitems);

                Assert.AreEqual(4, clubData.Clubs.Count()); 
            }


        }

  
        [Test]
        public void GetList_MascManager()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context, mapper,userManager);
                Assert.AreEqual(2, clubData.Clubs.Count());
            }

        }

        [Test]
        public void GetList_NotMascManager()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context, mapper, userNoManager);
                Assert.AreEqual(1, clubData.Clubs.Count());
            }

        }
        [Test]
      
        public void DeleteClub()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context,mapper, userManager);
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
                var clubData = new ClubData(context,mapper, userManager);
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
                var clubData = new ClubData(context, mapper,userNoManager);
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

        [Test]
        public void FindClub_ByID_NotEditable()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context,mapper, userNoManager);
                var club = clubData.Find(1, false);

                Assert.IsTrue(club != null);
                Assert.IsTrue(context.Entry(club).State == EntityState.Detached);
                Assert.IsTrue(club.ClubName == "Club Test 1");
            }
        }

        [Test]
        public void FindClub_ByID_Editable()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context,mapper, userNoManager);
                var club = clubData.Find(2, true);

                Assert.IsTrue(club != null);
                Assert.IsTrue(context.Entry(club).State != EntityState.Detached);
                Assert.IsTrue(club.ClubName == "Club Test 2");
            }
        }

        [Test]
        public void Findclub_ByFilter_NotEditable()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context,mapper, userManager);
                var club = clubData.Find(s => s.ClubName == "Club Test 2", false);

                Assert.IsTrue(club != null);
                Assert.IsTrue(context.Entry(club).State == EntityState.Detached);
                Assert.IsTrue(club.ClubID == 2);
            }
        }

        [Test]
        public void FindClub_ByFilter_Editable()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context,mapper, userNoManager);
                var club = clubData.Find(s => s.ClubName == "Club Test 3", true);

                Assert.IsTrue(club != null);
                Assert.IsTrue(context.Entry(club).State != EntityState.Detached);
                Assert.IsTrue(club.ClubID == 3);
            }
        }

        [Test]
        public void FindClub_ByID_NoCLubFound()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context,mapper, userManager);
                var club = clubData.Find(20, true);

                Assert.IsTrue(club == null);
            }
            }

        [Test]
        public void FindClub_ByFilter_NoCLubFound()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context,mapper, userNoManager);
                var club = clubData.Find(s=>s.ClubName=="Not Present", true);
                
                Assert.IsTrue(club == null);
            }
        }
    }
}
