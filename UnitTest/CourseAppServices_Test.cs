using BL.AppServices;
using BL.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class CourseAppServices_Test
    {
        CourseAppServices course;
        CourseVM course2;
        [SetUp]
        public void Setup()
        {
            course = new CourseAppServices();
            course2 = new CourseVM();
        }
        [Test]
        public void Test_Get_By_ID_Course()
        {
            //Act
            var result = course.GetCourse(1);

            //Assert
            Assert.AreEqual(result.ID, 1);
        }
        [Test]
        public void Test_Delete_Course_Return_False()
        {
            //Act
            var result = course.DeleteCourse(50);

            //Assert
            Assert.AreEqual(result, false);
        }
        [Test]
        public void Test_Delete_Course_Return_True()
        {
            //Act
            var result = course.DeleteCourse(1);

            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Save_New_Course()
        {
            //Act
            var result = course.SaveNewCourse(course2);

            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Get_All_Course()
        {
            List<CourseVM> course2 = new List<CourseVM>();

            //Act
            course2 = course.GetAllCourse();

            //Assert
            Assert.AreEqual(course2.Count, 1);
        }
        [Test]
        public void Test_Get_Course_By_Name()
        {
            List<CourseVM> course2 = new List<CourseVM>();
            string name;
            //Act
            name = "aaa";
            course2 = course.GetCourseByName(name);

            //Assert
            Assert.AreEqual(course2.Count,0);
        }
        [Test]
        public void Test_Update_Course_Return_True()
        {
            //Act
            course2.ID = 2;
            var result = course.UpdateCourse(course2);
            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Update_Course_Return_False()
        {

            //Act
            course2.title = "aaaa";
            var result = course.UpdateCourse(course2);
            //Assert
            Assert.AreEqual(result, false);


        }
        [Test]
        public void Test_Check_Course_Exists_True()
        {
            //Act
            course2.ID = 1;
            var result = course.CheckCourseExists(course2);
            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Check_Coures_Exists_False()
        {
            //Act
            course2.ID = 50;
            var result = course.CheckCourseExists(course2);
            //Assert
            Assert.AreEqual(result, false);
        }
    }
}
