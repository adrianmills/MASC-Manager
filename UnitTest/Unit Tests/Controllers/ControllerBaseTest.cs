using AutoMapper;
using Business_Logic.AutoMapProfiles;
using Business_Logic.View_Model.Interface;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UnitTest.Mock_Components;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace UnitTest.Unit_Tests.Controllers
{
    public class ControllerBaseTest
    {

        protected MockData data;

        protected ITempDataDictionary tempData;

        public ControllerBaseTest()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MASCProfiles());
            });

            var mapper = config.CreateMapper();
            data = new MockData(mapper);
        }


        protected List<ValidationResult> ValidateViewModel(IViewModelBase entity, out bool isValid)
        {
            var result = new List<ValidationResult>();

            isValid = Validator.TryValidateObject(entity, new ValidationContext(entity), result);

            return result;

        }
    }
}
