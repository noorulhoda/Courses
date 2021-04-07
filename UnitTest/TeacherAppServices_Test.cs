using BL.AppServices;
using BL.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class TeacherAppServices_Test
    {
        TeacherAppServices teacher;
        TeacherVM teacher2;
        [SetUp]
        public void Setup()
        {
            teacher = new TeacherAppServices();
            teacher2 = new TeacherVM();
        }
        [Test]
        public void Test_Get_By_ID_Teacher()
        {
            //Act
            var result = teacher.GetTeacher("1");

            //Assert
            Assert.AreEqual(result.ID, 1);
        }
        [Test]
        public void Test_Delete_Teacher_Return_False()
        {
            //Act
            var result = teacher.DeleteTeacher("50");

            //Assert
            Assert.AreEqual(result, false);
        }
        [Test]
        public void Test_Delete_Teacher_Return_True()
        {
            //Act
            var result = teacher.DeleteTeacher("1");

            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Save_New_Teacher()
        {
            //Act
            var result = teacher.SaveNewTeacher(teacher2);

            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Get_All_Teacher()
        {
            List<TeacherVM> teacher2 = new List<TeacherVM>();

            //Act
            teacher2 = teacher.GetAllTeacher();

            //Assert
            Assert.AreEqual(teacher2.Count, 1);
        }

        [Test]
        public void Test_Update_Teacher_Return_True()
        {
            //Act
            teacher2.ID = "2";
            var result = teacher.UpdateTeacher(teacher2);
            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Update_Teacher_Return_False()
        {

            //Act
            teacher2.lastName = "aaaa";
            var result = teacher.UpdateTeacher(teacher2);
            //Assert
            Assert.AreEqual(result, false);


        }
        [Test]
        public void Test_Check_Teacher_Exists_True()
        {
            //Act
            teacher2.ID = "1";
            var result = teacher.CheckTeacherExists(teacher2);
            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Check_Teacher_Exists_False()
        {
            //Act
            teacher2.ID = "50";
            var result = teacher.CheckTeacherExists(teacher2);
            //Assert
            Assert.AreEqual(result, false);
        }
        [Test]
        public void Test_Get_Teacher_By_ID()
        {

            //Act
            string id = "1";

            var result = teacher.GetById(id);
            //Assert
            Assert.AreEqual(result.ID, "1");
        }
        [Test]
        public void Test_Get_TeacherVM_By_ID()
        {

            //Act
            string id = "1";

            var result = teacher.GetVMById(id);
            //Assert
            Assert.AreEqual(result.ID, "1");
        }
    }
}


