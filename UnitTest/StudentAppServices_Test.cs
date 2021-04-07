using BL.AppServices;
using BL.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class StudentAppServices_Test
    {
        StudentAppServices student;
        StudentVM student2;
        [SetUp]
        public void Setup()
        {
            student = new StudentAppServices();
            student2 = new StudentVM();
        }
        [Test]
        public void Test_Get_By_ID_Student()
        {
            //Act
            var result = student.GetStudent("1");

            //Assert
            Assert.AreEqual(result.ID, 1);
        }
        [Test]
        public void Test_Delete_Student_Return_False()
        {
            //Act
            var result = student.DeleteStudent("50");

            //Assert
            Assert.AreEqual(result, false);
        }
        [Test]
        public void Test_Delete_Student_Return_True()
        {
            //Act
            var result = student.DeleteStudent("1");

            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Save_New_Student()
        {
            //Act
            var result = student.SaveNewStudent(student2);

            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Get_All_Student()
        {
            List<StudentVM> student2 = new List<StudentVM>();

            //Act
            student2 = student.GetAllStudent();

            //Assert
            Assert.AreEqual(student2.Count, 1);
        }
       
        [Test]
        public void Test_Update_Student_Return_True()
        {
            //Act
            student2.ID = "2";
            var result = student.UpdateStudent(student2);
            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Update_Student_Return_False()
        {

            //Act
            student2.lastName = "aaaa";
            var result = student.UpdateStudent(student2);
            //Assert
            Assert.AreEqual(result, false);


        }
        [Test]
        public void Test_Check_Student_Exists_True()
        {
            //Act
            student2.ID = "1";
            var result = student.CheckStudentExists(student2);
            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Check_Student_Exists_False()
        {
            //Act
            student2.ID = "50";
            var result = student.CheckStudentExists(student2);
            //Assert
            Assert.AreEqual(result, false);
        }
        [Test]
        public void Test_Get_Student_By_ID()
        {

            //Act
            string id = "1";
            
            var result = student.GetById(id);
            //Assert
            Assert.AreEqual(result.ID,"1");
        }
        [Test]
        public void Test_Get_StudentVM_By_ID()
        {

            //Act
            string id = "1";

            var result = student.GetVMById(id);
            //Assert
            Assert.AreEqual(result.ID, "1");
        }
    }
}

