using Business_Logic.DataRetrival.Interface;
using Business_Logic.View_Model;
using Business_Logic.View_Model.Interface;
using MASC_Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UnitTest.Unit_Tests.Controllers
{
    public class ClubControllerTests : ControllerBaseTest
    {


        IClubData clubData;

        [SetUp]
        public void Intilise()
        {


            clubData = Substitute.For<IClubData>();

            clubData.Clubs.Returns(data.ClubsViewData);

            var clubDetail = data.ClubsViewData.Where(c => c.ClubID == 1).FirstOrDefault();
            clubDetail.Students = data.StudentsViewData.Where(s => s.ClubID == 1);
            clubDetail.Manager = data.Users.Where(u => u.ID == clubDetail.ManagerID).First().UserName;

            clubData.Detail(1).Returns(clubDetail);


        }

        [Test]
        public void Index()
        {
            //var httpContext = Substitute.For<HttpContext>();
            //var mockSession = new MockHttpSession();
            //httpContext.Session = mockSession;
            //httpContext.Request.Returns(Substitute.For<HttpRequest>());
            //httpContext.Response.Returns(Substitute.For<HttpResponse>());



            //var services = new ServiceCollection();
            //services.AddMvc();

            var clubController = new ClubController(clubData);
            //{
            //    ControllerContext = new ControllerContext
            //    {
            //        HttpContext = httpContext
            //    }
            //};

            //clubController.TempData = Substitute.For<ITempDataDictionary>();

            var result = clubController.Index() as PartialViewResult;


            var resultdata = result.ViewData.Model as List<IClubViewModel>;
            Assert.AreEqual("_list", result.ViewName);
            Assert.AreEqual(2, resultdata.Count);
        }


        [Test]
        public void DetailView()
        {
            var clubController = new ClubController(clubData);
            var result = clubController.Details(1) as PartialViewResult;

            var resultData = result.ViewData.Model as IClubViewModel;

            Assert.AreEqual("_detail", result.ViewName);
            Assert.IsNotNull(resultData);
            Assert.AreEqual(3, resultData.Students.Count());
        }

        [Test]
        public void Create_Get()
        {

            var clubController = new ClubController(clubData);
            var result = clubController.Create() as PartialViewResult;

            Assert.AreEqual("_create", result.ViewName);

        }

        [Test]
        public void Create_Post_Success_RedirectToIndex()
        {
            IClubViewModel clubReturned = null;
            clubData.When(x => x.Add(Arg.Any<IClubViewModel>())).Do(x => clubReturned = x.Arg<IClubViewModel>());
            var clubController = new ClubController(clubData);

            var club = new ClubViewModel();
            club.ManagerID = 1;
            club.ClubName = "Add Test Club";

            var result = clubController.Create(club) as RedirectToActionResult;


            Assert.IsNotNull(clubReturned);
            Assert.AreEqual(0, clubReturned.ClubID);
            Assert.AreEqual("Add Test Club", clubReturned.ClubName);
            Assert.AreEqual(1, club.ManagerID);
            Assert.AreEqual("Index", result.ActionName);


        }

        [Test]
        public void ModeValidation_MissingClubName()
        {
           
            var club = new ClubViewModel();
            club.ClubName = string.Empty;
            club.ManagerID = 1;
            bool isValid;
            
          var result=  ValidateViewModel(club, out isValid);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, result.Count);

            Assert.AreEqual("ClubName", result[0].MemberNames.ElementAt(0));
            Assert.AreEqual("The Club Name field is required.", result[0].ErrorMessage);
        }

        [Test]
        public void ModeValidation_MissingManager()
        {
           
            var club = new ClubViewModel();
            club.ClubName = "Test ";



            bool isValid;
                var result = ValidateViewModel(club,out isValid);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, result.Count);

            Assert.AreEqual("ManagerID", result[0].MemberNames.ElementAt(0));
            Assert.AreEqual("The Manager field is required.", result[0].ErrorMessage);
        }

        [Test]
        public void Edit_Get()
        {

            var clubController = new ClubController(clubData);
            var result = clubController.Edit(1) as PartialViewResult;

            Assert.AreEqual("_edit", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

        }

        [Test]
        public void Edit_Post_Success_RedirectToAction()
        {
            IClubViewModel clubReturned = null;
            clubData.When(x => x.Update(Arg.Any<IClubViewModel>())).Do(x => clubReturned = x.Arg<IClubViewModel>());
            var clubController = new ClubController(clubData);

            var club = new ClubViewModel();
            club.ClubID = 1;
            club.ManagerID = 1;
            club.ClubName = "Update Test Club";

            var result = clubController.Edit(1,club) as RedirectToActionResult;


            Assert.IsNotNull(clubReturned);
            Assert.AreEqual(1, clubReturned.ClubID);
            Assert.AreEqual("Update Test Club", clubReturned.ClubName);
            Assert.AreEqual(1, club.ManagerID);
            Assert.AreEqual("Index", result.ActionName);


        }

        [Test]
        public void Edit_Post_ModelValidation()
        {
            IClubViewModel clubReturned = null;
            clubData.When(x => x.Update(Arg.Any<IClubViewModel>())).Do(x => clubReturned = x.Arg<IClubViewModel>());
            var clubController = new ClubController(clubData);

            var club = new ClubViewModel();
            club.ManagerID = 1;
            clubController.ModelState.AddModelError("ClubName", "Club Name is required field");

            var result = clubController.Edit(1,club) as PartialViewResult;


            Assert.IsNull(clubReturned);
            Assert.AreEqual(1, result.ViewData.ModelState.ErrorCount);
            Assert.AreEqual("_edit", result.ViewName);
            Assert.IsNotNull(result.Model);
        }


        [Test]
        public void DeleteClub()
        {
            long idReturned =0;
            clubData.When(x => x.Delete(Arg.Any<long>())).Do(x => idReturned = x.Arg<long>());
            var clubController = new ClubController(clubData);

           var result= clubController.Delete(1) as RedirectToActionResult;

            Assert.AreEqual(1, idReturned);
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}
