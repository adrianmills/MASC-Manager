using Business_Logic.DataRetrival;
using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO;
using Business_Logic.DTO.Interface;
using Business_Logic.Session;
using Masc_Model.Model.Interface;
using MASC_Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnitTest.Mock_Components;

namespace UnitTest.Unit_Tests.Controllers
{
    public class ClubControllerTests : ControllerBaseTest
    {
        int counter = 0;
        int callCounter = 0;

        IClubData clubData;
        IClubDTO club = new ClubDTO { ID = 2, ClubName = "Test 2" };
        IClubDTO dclub = new ClubDTO { ID = 1, ClubName = "Test 1" };

        IClubDataItems testItems;

        [SetUp]
        public void Intilise()
        {
            clubData = Substitute.For<IClubData>();

            clubData.Clubs.Returns(data.MockClubsDTO);

            var dataitems = new ClubDataItems();

            dataitems.Clubs.Add((ClubDTO)club);
            dataitems.DeletedClubs.Add((ClubDTO)dclub);

            clubData.When(x => x.ProccessClubs(dataitems)).Do(x => counter++);
            clubData.When(x => x.ProccessClubs(Arg.Any<IClubDataItems>())).Do(x => testItems=x.Arg<IClubDataItems>());


        }

        [Test]
        public void ClubController_Index()
        {
            var httpContext = Substitute.For<HttpContext>();
            var mockSession = new MockHttpSession();
            httpContext.Session = mockSession;
            httpContext.Request.Returns(Substitute.For<HttpRequest>());
            httpContext.Response.Returns(Substitute.For<HttpResponse>());



            var services = new ServiceCollection();
            services.AddMvc();

            var clubController = new ClubController(clubData)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };

            clubController.TempData = Substitute.For<ITempDataDictionary>();

            var result = clubController.Index() as PartialViewResult;


            var resultdata = result.ViewData.Model as List<IClubDTO>;
            var clubs = httpContext.Session.Get<List<ClubDTO>>("clubs");
            var deletedclubs = httpContext.Session.Get<List<ClubDTO>>("deletedclubs");
            Assert.AreEqual("_list", result.ViewName);
            Assert.AreEqual(2, resultdata.Count);
            Assert.AreEqual(2, clubs.Count);
            Assert.AreEqual(0, deletedclubs.Count);



        }

        [Test]
        public void ClubController_AddClub()
        {

            var httpContext = Substitute.For<HttpContext>();
            var mockSession = new MockHttpSession();

            mockSession.Set("clubs", clubData.Clubs);

            httpContext.Session = mockSession;

            var clubController = new ClubController(clubData)
            {
                ControllerContext = new ControllerContext { HttpContext = httpContext }
            };

            clubController.AddClub("Club Test 4");

            var clubs = httpContext.Session.Get<List<ClubDTO>>("clubs");

            Assert.AreEqual(3, clubs.Count);
        }

        [Test]
        public void ClubController_ChangeName()
        {
            var httpContext = Substitute.For<HttpContext>();
            var mockSession = new MockHttpSession();

            mockSession.Set("clubs", clubData.Clubs);

            httpContext.Session = mockSession;

            var clubController = new ClubController(clubData)
            {
                ControllerContext = new ControllerContext { HttpContext = httpContext }
            };

            clubController.UpdateClub(1, "unit 1");
            var clubs = httpContext.Session.Get<List<ClubDTO>>("clubs");

            var club = clubs.Where(c => c.ID == 1).FirstOrDefault();

            Assert.AreEqual("unit 1", club.ClubName);
        }

        [Test]
        public void ClubController_DeleteClub()
        {
            var httpContext = Substitute.For<HttpContext>();
            var mockSession = new MockHttpSession();

            mockSession.Set("clubs", clubData.Clubs);
            mockSession.Set("deletedclubs", new List<ClubDTO>());

            httpContext.Session = mockSession;

            var clubController = new ClubController(clubData)
            {
                ControllerContext = new ControllerContext { HttpContext = httpContext }
            };

            clubController.DeleteClub(2);

            var clubs = mockSession.Get<List<ClubDTO>>("clubs");
            var deletedclubs = mockSession.Get<List<ClubDTO>>("deletedclubs");

            Assert.AreEqual(1, clubs.Count);
            Assert.AreEqual(1, deletedclubs.Count);
        }

        [Test]
        public void SaveChanges_CorrectParameters()
        {
           List<ClubDTO> clubs = new List<ClubDTO>();
            clubs.Add((ClubDTO)club);

            List<ClubDTO> dclubs = new List<ClubDTO>();
            dclubs.Add((ClubDTO)dclub);

            var httpContext = Substitute.For<HttpContext>();
            var mockSession = new MockHttpSession();

            mockSession.Set("clubs", clubs);
            mockSession.Set("deletedclubs", dclubs);

            httpContext.Session = mockSession;

            var clubController = new ClubController(clubData)
            {
                ControllerContext = new ControllerContext { HttpContext = httpContext }
            };
            

            clubController.SaveChanges();
            IClubDTO clubTest;

            Assert.AreEqual(1, testItems.Clubs.Count);
            clubTest = testItems.Clubs[0];
            Assert.IsTrue(CompareObject.Compare<IClubDTO>(clubTest, club));

            Assert.AreEqual(1, testItems.DeletedClubs.Count);
             clubTest = testItems.DeletedClubs[0];
            Assert.IsTrue(CompareObject.Compare<IClubDTO>(clubTest, dclub));
        }

    }
}
