using Masc_Model.DAL;
using Masc_Model.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Unit_Tests.Data
{
  public class GradeDataTests:BaseDataTest
    {
        protected override void seed(MASCContext context)
        {

            base.seed(context);

            foreach (var g in data.Grades)
            {
                context.Grades.Add((Grade)g);
            }

            foreach (var s in data.Students)
            {
                context.Students.Add((Student)s);
            }
            var saveitems = context.SaveChanges();
        }


        [Test]
        public void AddGrade()
        {

        }
    }
}
