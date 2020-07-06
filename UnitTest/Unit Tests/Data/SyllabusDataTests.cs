using Business_Logic.DataRetrival;
using Business_Logic.View_Model;
using Business_Logic.View_Model.Interface;
using Masc_Model.DAL;
using Masc_Model.Model;
using NUnit.Framework;
using System.Linq;

namespace UnitTest.Unit_Tests.Data
{
    public class SyllabusDataTests : BaseDataTest
    {
        void seed(MASCContext context)
        {
            foreach (var s in data.Syllabi)
            {
                context.Syllabi.Add((Syllabus) s);
            }

            foreach(var g in data.Grades)
            {
                context.Grades.Add((Grade) g);
            }

            foreach(var s in data.Students)
            {
                context.Students.Add((Student)s); 
            }
            context.SaveChanges();
        }

        [Test]
        public void AddSyallabus()
        {
            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var syllabusData = new SyllabusData(context, mapper, userManager);

                var syllabus = new SyllabusViewModel { SyllabusName = "Test 1" };

                syllabusData.Add(syllabus);

                var syallabi = from s in context.Syllabi
                            select s;

                Assert.AreEqual(4, syallabi.Count());


            }
        }

        [Test]
        public void GetList()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var syllabusData = new SyllabusData(context, mapper, userManager);
                Assert.AreEqual(2, syllabusData.Syllabi.Count());
            }

        }

        [Test]

        public void DeleteSyallabus()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var syllabusData = new SyllabusData(context, mapper, userManager);

                syllabusData.Delete(1);

                var deletedSyallabi = from s in context.Syllabi
                                   where s.Deleted
                                   select s;

                Assert.AreEqual(2, deletedSyallabi.Count());

            }


        }

        [Test]

        public void ChangeSyallabusName()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var syllabusData = new SyllabusData(context, mapper, userManager);

                var syllabusViewModel = data.SyllabiViewData.Where(s => s.SyllabusID == 2).FirstOrDefault();
                syllabusViewModel.SyllabusName="changed";

                syllabusData.Update(syllabusViewModel);

                var syllabus = (from c in context.Syllabi
                            where c.ID == 2
                            select c).FirstOrDefault();

                Assert.AreEqual("changed", syllabus.Name);
                Assert.IsNotNull(syllabus.ModifiedBy);
                Assert.IsNotNull(syllabus.ModifiedOn);
            }
        }

        [Test]
        public void UpdateNoChange()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var syllabusData = new SyllabusData(context, mapper, userManager);

                var syllabusViewModel = data.SyllabiViewData.Where(s=>s.SyllabusID==2).FirstOrDefault();

                syllabusData.Update(syllabusViewModel);

                var syllabus = (from c in context.Syllabi
                                where c.ID == 2
                                select c).FirstOrDefault();

                Assert.AreEqual("Syllabus Test 2", syllabus.Name);
                Assert.IsNull(syllabus.ModifiedBy);
                Assert.IsNull(syllabus.ModifiedOn);
            }
        }

        [Test]
        public void SyllabusDetail()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var syllabusData = new SyllabusData(context, mapper, userManager);

                var syllabus = syllabusData.Detail(1);

                Assert.AreEqual("Syllabus Test 1", syllabus.SyllabusName);
                Assert.AreEqual(2, syllabus.Grades.Count);
                Assert.AreEqual(4, syllabus.Students.Count);
            }
        }
    }
}
