using BL.AppServices;
using BL.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ClassAppServices_Test
    {
        ClassAppServices clas;
        ClassVM class2;
        [SetUp]
        public void Setup()
        {
            clas = new ClassAppServices();
            class2 = new ClassVM();
        }
        [Test]
        public void Test_Get_By_ID_Class()
        {
            //Act
            var result = clas.GetClass(1);

            //Assert
            Assert.AreEqual(result.ID, 1);
        }
        [Test]
        public void Test_Delete_Class_Return_False()
        {
            //Act
            var result = clas.DeleteClass(50);

            //Assert
            Assert.AreEqual(result, false);
        }
        [Test]
        public void Test_Delete_Class_Return_True()
        {
            //Act
            var result = clas.DeleteClass(5);

            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Save_New_Class()
        {
            //Act
            var result = clas.SaveNewClass(class2);

            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Get_All_Class()
        {
            List<ClassVM> class2 = new List<ClassVM>();

            //Act
            class2 = clas.GetAllClass();

            //Assert
            Assert.AreEqual(class2.Count, 4);
        }
        [Test]
        public void Test_Update_Class_Return_True()
        {
            //Act
            class2.ID = 2;
            var result = clas.UpdateClass(class2);
            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Update_ClassReturn_False()
        {

            //Act
            class2.number = 'A';
            var result = clas.UpdateClass(class2);
            //Assert
            Assert.AreEqual(result, false);


        }
        [Test]
        public void Test_Check_Class_Exists_True()
        {
            //Act
            class2.ID = 2;
            var result = clas.CheckClassExists(class2);
            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Check_Class_Exists_False()
        {
            //Act
            class2.ID = 50;
            var result = clas.CheckClassExists(class2);
            //Assert
            Assert.AreEqual(result, false);
        }
    }
}
