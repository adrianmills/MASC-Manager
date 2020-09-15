using Business_Logic.DataRetrival.Interface;
using Business_Logic.View_Model;
using Business_Logic.View_Model.Interface;
using MASC_Web.Controllers;
using MASC_Web.Controllers.Interface;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest.Unit_Tests.Controllers
{
    public class SyllabusControllerTest:ControllerBaseTest
    {
        ISyllabusData syllabusData;
        IMascController<SyllabusViewModel> syllabusController = null;
        ISyllabusViewModel returnViewData;

        long idReturned = 0;
        
        [SetUp]
        public void MockSyllabusData()
        {
            syllabusData = Substitute.For<ISyllabusData>();
            syllabusData.Syllabi.Returns(data.SyllabiViewData);

            var syllabusDetail = data.SyllabiViewData.Where(s => s.SyllabusID == 1).First();
            syllabusDetail.Students = data.StudentsViewData.Where(s => s.SyllabusID == 1).ToList();
            syllabusDetail.Grades = data.GradesViewData.Where(g => g.SyallbusID == 1).ToList();

            syllabusData.Detail(1).Returns(syllabusDetail);

            //Trying a different method of updates compared to club tests not sure to keep this or put the following in the relevant methods to increase readability

            //When the Add Method is called on the repository set the return view data to the returned syllabus
            //do the same for the update method
            syllabusData.When(x => x.Add(Arg.Any<ISyllabusViewModel>())).Do(x => returnViewData = x.Arg<ISyllabusViewModel>());
            syllabusData.When(x => x.Update(Arg.Any<ISyllabusViewModel>())).Do(x => returnViewData = x.Arg<ISyllabusViewModel>());

            //for the delete method set the returned id
            syllabusData.When(x => x.Delete(Arg.Any<long>())).Do(x => idReturned = x.Arg<long>());

            syllabusController = new SyallabusController(syllabusData);
        }


        [Test]
        public void ListView()
        {
            

            var result = syllabusController.Index() as PartialViewResult;

            var resultdata = result.ViewData.Model as List<ISyllabusViewModel>;
            Assert.AreEqual("_list", result.ViewName);
            Assert.AreEqual(2, resultdata.Count);
        }

        [Test]
        public void DetailView()
        {
            var result = syllabusController.Details(1) as PartialViewResult;

            var resultData = result.Model as ISyllabusViewModel;

            Assert.AreEqual("_detail", result.ViewName);
            Assert.IsNotNull(resultData);
            Assert.AreEqual(4, resultData.Students.Count());
            Assert.AreEqual(2, resultData.Grades.Count());
        }

        [Test]
        public void Create_Get()
        {
           
            var result = syllabusController.Create() as PartialViewResult;

            Assert.AreEqual("_create", result.ViewName);
        }

        [Test]
        public void Create_Post_Success_RedirectToIndex()
        { 
            

            var syllabus = new SyllabusViewModel();

            syllabus.SyllabusName = "Add syllabus";

            var result = syllabusController.Create(syllabus) as RedirectToActionResult;


            Assert.IsNotNull(returnViewData);
            Assert.AreEqual(0, returnViewData.SyllabusID    );
            Assert.AreEqual("Add syllabus", returnViewData.SyllabusName);
            Assert.AreEqual("Index", result.ActionName);


        }

        [Test]
        public void ModeValidation_MissingName()
        {

            var syllabus = new SyllabusViewModel();
            syllabus.SyllabusName = string.Empty;
            
            bool isValid;

            var result = ValidateViewModel(syllabus, out isValid);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, result.Count);

            Assert.AreEqual("SyllabusName", result[0].MemberNames.ElementAt(0));
            Assert.AreEqual("The Syllabus Name field is required.", result[0].ErrorMessage);
        }

        [Test]
        public void ModeValidation_Name_TooLong()
        {

            var syllabus = new SyllabusViewModel();
            syllabus.SyllabusName = "123456789012345678901234567890tik,jhkjfgjh,";

            bool isValid;

            var result = ValidateViewModel(syllabus, out isValid);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, result.Count);

            Assert.AreEqual("SyllabusName", result[0].MemberNames.ElementAt(0));
            Assert.AreEqual("Syllbus Name Cannot be more than 20 characters.", result[0].ErrorMessage);
        }

        [Test]
        public void Edit_Get()
        {
            var result = syllabusController.Edit(1) as PartialViewResult;

            Assert.AreEqual("_edit", result.ViewName);
            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void Edit_Post_Success()
        {
            var syllabus = new SyllabusViewModel();
            syllabus.SyllabusID = 1;
            syllabus.SyllabusName = "Updated";

            var result = syllabusController.Edit(1, syllabus) as RedirectToActionResult;
            Assert.IsNotNull(returnViewData);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Updated", returnViewData.SyllabusName);
        }

        [Test]
        public void Delete()
        {
            var result = syllabusController.Delete(1) as RedirectToActionResult;

            Assert.AreEqual(1, idReturned);
            Assert.AreEqual("Index", result.ActionName);

        }
    }
}
