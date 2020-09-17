using Business_Logic.DataRetrival;
using Business_Logic.View_Model;
using Masc_Model.DAL;
using Masc_Model.Model;
using NUnit.Framework;
using System.Linq;

namespace UnitTest.Unit_Tests.Data
{
  public class GradeDataTests:BaseDataTest
    {
        protected override void seed(MASCContext context)
        {

            base.seed(context);

            foreach (var grade in data.Grades)
            {
                context.Grades.Add((Grade)grade);
            }
            foreach (var syllabus in data.Syllabi)
            {
                context.Syllabi.Add((Syllabus)syllabus);
            }

            foreach (var student in data.Students)
            {
                context.Students.Add((Student)student);
            }
            var saveitems = context.SaveChanges();
        }


        [Test]
        public void AddGrade()
        {
            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);

                var gradeData = new GradeData(context, mapper, userManager);

                var grade = new GradeViewModel { GradeName = "Grade 1", SyallbusID = 1 };

                gradeData.Add(grade);

                var grades = from g in context.Grades
                             select g;


                Assert.AreEqual(7, grades.Count());
            }
        }

        [Test]
        public void GetGrades()
        { 

            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var gradeData = new GradeData(context, mapper, userManager);

                Assert.AreEqual(6, gradeData.Grades.Count());
            }
        
        }

        [Test]
        public void DeleteGrade()
        {
            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var gradeData = new GradeData(context, mapper, userManager);

                gradeData.Delete(1);

                var deletedGrades = from grade in context.Grades
                                    where grade.Deleted
                                    select grade;

                Assert.AreEqual(1, deletedGrades.Count());
            }                     
        }

        [Test]
        public void ChangeGradeName()
        {
            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var gradeData = new GradeData(context, mapper, userManager);

                var gradeViewModel = new GradeViewModel { GradeID = 3, GradeName = "white stripe", SyallbusID = 2 };

                gradeData.Update(gradeViewModel);

                    var updatedGrade = (from grade in context.Grades
                                        where grade.ID==3   
                                        select grade).FirstOrDefault();

                Assert.AreEqual("white stripe", updatedGrade.Name);
                Assert.AreEqual(2, updatedGrade.SyllabusID);
            }
        }

        [Test]
        public void ChangeGradeSyllabus()
        {
            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var gradeData = new GradeData(context, mapper, userManager);

                var gradeViewModel = new GradeViewModel { GradeID = 3, GradeName = "Purple", SyallbusID =3 };

                gradeData.Update(gradeViewModel);

                var updatedGrade = (from grade in context.Grades
                                    where grade.ID == 3
                                    select grade).FirstOrDefault();

                Assert.AreEqual("Purple", updatedGrade.Name);
                Assert.AreEqual(3, updatedGrade.SyllabusID);
            }
        }


        [Test]
        public void GradeDetail_NoStudents()
        {
            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var gradeData = new GradeData(context, mapper, userManager);
                var grade = gradeData.Detail(4);

                Assert.AreEqual("Orange", grade.GradeName);
                Assert.AreEqual(2, grade.SyallbusID);
                Assert.AreEqual(0, grade.Students.Count);
            }

            }


        [Test]
        public void GradeDetail_Students()
        {
            using (var context = new MASCContext(ContextOptions))
            {
                seed(context);
                var gradeData = new GradeData(context, mapper, userManager);
                var grade = gradeData.Detail(1);

                Assert.AreEqual("White", grade.GradeName);
                Assert.AreEqual(1, grade.SyallbusID);
                Assert.AreEqual(4, grade.Students.Count);
            }

        }
    }
}
