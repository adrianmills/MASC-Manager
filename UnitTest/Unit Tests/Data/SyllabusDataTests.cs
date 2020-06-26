using Business_Logic.DataRetrival;
using Business_Logic.DTO;
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
            foreach (var c in data.MockSyllabi)
            {
                context.Syllabi.Add((Syllabus) c);
            }
            context.SaveChanges();
        }

        [Test]
        [Ignore("Still in development")]
        public void Add1Syllaus()
        {
            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var syllabusData = new SyllabusData(context, user);

                var dataitems = new SyllabusDataItems();

                dataitems.Syllabi.Add(new SyllabusDTO { SyllabusName = "Test 1" });

                syllabusData.ProccessSyllabi(dataitems);

                Assert.AreEqual(3, syllabusData.Syllabi.Count());


            }
        }

        [Test]
        [Ignore("Still in development")]
        public void Add2Syllaus()
        {
            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var syllabusData = new SyllabusData(context, user);

                var dataitems = new SyllabusDataItems();

                dataitems.Syllabi.Add(new SyllabusDTO { SyllabusName = "Test 1" });
                dataitems.Syllabi.Add(new SyllabusDTO { SyllabusName = "Test 4" });

                syllabusData.ProccessSyllabi(dataitems);

                Assert.AreEqual(4, syllabusData.Syllabi.Count());


            }
        }

        [Test]
        public void GetList()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var syllabusData = new SyllabusData(context, user);
                Assert.AreEqual(2, syllabusData.Syllabi.Count());
            }

        }

        [Test]
        [Ignore("Still in development")]
        public void DeleteSyllabus()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var syllabusData = new SyllabusData(context, user);
                var SyllabusDataItems = new SyllabusDataItems();
                SyllabusDataItems.DeletedSyllabi.Add(new SyllabusDTO { ID = 1, SyllabusName = "Syllabus Test 1" });

                syllabusData.ProccessSyllabi(SyllabusDataItems);

                var deletedSyllabuss = from c in context.Syllabi
                                       where c.Deleted
                                   select c;

                Assert.AreEqual(2, deletedSyllabuss.Count());

            }


        }

        [Test]
        [Ignore("Still in development")]
        public void ChangeSyllabusName()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var syllabusData = new SyllabusData(context, user);
                var SyllabusDataItems = new SyllabusDataItems();

                SyllabusDataItems.Syllabi.Add(new SyllabusDTO { ID = 2, SyllabusName = "Name Change 2" });

                syllabusData.ProccessSyllabi(SyllabusDataItems);

                var Syllabus = (from c in context.Syllabi
                                where c.ID == 2
                            select c).FirstOrDefault();

                Assert.AreEqual("Name Change 2", Syllabus.Name);
            }
        }

        [Test]
        [Ignore("Still in development")]
        public void MultipleOperations()
        {
            using (var context = new MASCContext(ContextOptions))
            {

                seed(context);
                var syllabusData = new SyllabusData(context, user);
                var SyllabusDataItems = new SyllabusDataItems();

                SyllabusDataItems.Syllabi.Add(new SyllabusDTO { ID = 2, SyllabusName = "Name Change 2" });
                SyllabusDataItems.Syllabi.Add(new SyllabusDTO { SyllabusName = "Syllabus Test Multiple Operations 1" });
                SyllabusDataItems.Syllabi.Add(new SyllabusDTO { SyllabusName = "Syllabus Test Multiple Operations 2" });
                SyllabusDataItems.Syllabi.Add(new SyllabusDTO { SyllabusName = "Syllabus Test Multiple Operations 3" });
                SyllabusDataItems.DeletedSyllabi.Add(new SyllabusDTO { ID = 1, SyllabusName = "Syllabus Test 1" });

                syllabusData.ProccessSyllabi(SyllabusDataItems);

                var Syllabus = (from c in context.Syllabi
                                where c.ID == 2
                            select c).FirstOrDefault();
                var Syllabuss = from c in context.Syllabi
                                where !c.Deleted
                            select c;
                var deletedSyllabuss = from c in context.Syllabi
                                       where c.Deleted
                                   select c;

                Assert.AreEqual("Name Change 2", Syllabus.Name);

                Assert.AreEqual(4, Syllabuss.Count());

                Assert.AreEqual(2, deletedSyllabuss.Count());

            }
        }

    }
}
