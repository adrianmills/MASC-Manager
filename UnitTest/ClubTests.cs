using Business_Logic.DataRetrival;
using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO;
using Business_Logic.DTO.Interface;
using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    public class ClubTests:TestBase
    {

        IClubData clubData;
        IClubDataItems dataItems;
             [SetUp]
        public void Setup()
        {
            MASCContext c = Context;
            clubData = new ClubData(Context, User);
        }

        void AddClubs()
        {
            ClearClubs();
            

         dataItems
            = new ClubDataItems();

            dataItems.Clubs.Add(new ClubDTO { ClubName = "Test 1" });
            dataItems.Clubs.Add(new ClubDTO { ClubName = "Test 2" });

            clubData.ProccessClubs(dataItems);
        }

        void ClearClubs()
        {
            List<Club> clubs = (from c in Context.Clubs
                                select c).ToList();

            foreach(Club c in clubs)
            {
                Context.Clubs.Remove(c);
            }

            Context.SaveChanges();
        }



        [Test]
        public void AddClub()
        {
            ClearClubs();
            IClubData clubData = new ClubData(Context, User);

            IClubDataItems dataItems = new ClubDataItems();

            dataItems.Clubs.Add(new ClubDTO { ClubName = "Test Club1" });

            

            clubData.ProccessClubs(dataItems);

            List<Club> retrievedClubs =  (from c in Context.Clubs
                                                         select c).ToList();
            Assert.AreEqual(1, retrievedClubs.Count);

        }
        
        [Test]
        public void AddMultipleClubs()
        {
            AddClubs();

            List<Club> retrievedClubs = (from c in Context.Clubs
                                         select c).ToList();
            Assert.AreEqual(2, retrievedClubs.Count);

        }

        [Test]
        public void RetriveList()
        {
            AddClubs();

            IEnumerable<IClubDTO> clubs = clubData.Clubs;

            Assert.AreEqual(2, clubs.Count());

        } 

        [Test]
        public void FindClubName()
        {
            AddClubs();

            IClub club = clubData.Find(c => c.Name == "Test 1",true);

            Assert.IsTrue(club != null);


        }

        [Test]
        public void ChangeClubName()
        {
            AddClubs();
            IClub club = clubData.Find(c => c.Name == "Test 1", true);

            IClubDTO clubDTO = new ClubDTO { ID = club.ID, ClubName = club.Name };
            clubDTO.ClubName = "Test 88";
            dataItems = new ClubDataItems();
            dataItems.Clubs.Add(clubDTO);

            clubData.ProccessClubs(dataItems);

            club = clubData.Find(clubDTO.ID, true);


            Assert.IsTrue(club.Name == "Test 88");


        }

        [Test]
        public void DeleteClub()
        {
            AddClubs();

            List<IClubDTO> clubs = clubData.Clubs.ToList();

            IClubDTO clubtodelete = clubs.First();

            clubs.Remove(clubtodelete);

            dataItems = new ClubDataItems();

            dataItems.DeletedClubs.Add(clubtodelete);
            dataItems.Clubs = clubs;

            clubData.ProccessClubs(dataItems);

            Assert.IsTrue(clubData.Clubs.Count() == 1);

            var deletedcubs = (from c in Context.Clubs
                               where c.Deleted
                               select c);

            Assert.IsTrue(deletedcubs.Count() == 1);
        }
    }
}