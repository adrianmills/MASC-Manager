using Business_Logic.DataRetrival;
using Business_Logic.View_Model;
using Masc_Model.DAL;
using Masc_Model.Model;
using NUnit.Framework;
using System.Linq;

namespace UnitTest.Unit_Tests.Data
{
    public class ClubDataTests : BaseDataTest
    {



       protected override void seed(MASCContext context)
        {

            base.seed(context);

            foreach (var c in data.Clubs)
            {
                context.Clubs.Add((Club)c);
            }

            foreach(var s in data.  Students)
            {
                context.Students.Add((Student)s);
            }
            var saveitems = context.SaveChanges();
        }

        [Test]
        public void AddClub()
        {


            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var clubData = new ClubData(context, mapper, userManager);

                var club = new ClubViewModel { ClubName = "Test 1", ManagerID = 1 };

                clubData.Add(club);
                
                var clubs = from c in context.Clubs
                            select c;

                Assert.AreEqual(4, clubs.Count());


            }


        }

        [Test]
        public void GetList_MascManager()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context, mapper, userManager);
                Assert.AreEqual(2, clubData.Clubs.Count());
            }

        }

        [Test]
        public void GetList_MascNoManager()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context, mapper, userNoManager);
                Assert.AreEqual(1, clubData.Clubs.Count());
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
        public void GetList_NotMascManager_noclubs()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context, mapper, usernotMangerwithNoClubs);
                Assert.AreEqual(0, clubData.Clubs.Count());
            }

        }

        [Test]

        public void DeleteClub()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context, mapper, userManager);

                clubData.Delete(1);

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
                var clubData = new ClubData(context, mapper, userManager);

               var clubViewModel =new ClubViewModel { ClubID = 2, ClubName = "Name Change 2",ManagerID=1, Manager= "Test User 2" };

                clubData.Update(clubViewModel);

                var club = (from c in context.Clubs
                            where c.ID == 2
                            select c).FirstOrDefault();

                Assert.AreEqual("Name Change 2", club.Name);
                Assert.AreEqual(1, club.ManagerID);
            }
        }

        [Test]
        public void ClubDetail()

        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var clubData = new ClubData(context, mapper, userManager);

                var club = clubData.Detail(1);

                Assert.AreEqual("Club Test 1", club.ClubName);
                Assert.AreEqual("Test User 1", club.Manager);
                Assert.AreEqual(3, club.Students.Count());
            }
        }
    }
}

