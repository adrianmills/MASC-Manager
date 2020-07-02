using AutoMapper;
using Business_Logic.AutoMapProfiles;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using UnitTest.Mock_Components;

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

    }
}
