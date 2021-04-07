using BL.AppServices;
using BL.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class CategoryAppServices_Test
    {
        CategoryAppServices cat;
        CategoryVM cat2;
        [SetUp]
        public void Setup()
        {
            cat = new CategoryAppServices();
            cat2 = new CategoryVM();
        }
        [Test]
        public void Test_Get_By_ID_Category()
        { 
            //Act
            var result = cat.GetCategory(1);
           
            //Assert
            Assert.AreEqual(result.ID , 1);
        }
        [Test]
        public void Test_Delete_Category_Return_False()
        {
            //Act
            var result = cat.DeleteCategory(50);

            //Assert
            Assert.AreEqual(result, false);
        }
        [Test]
        public void Test_Delete_Category_Return_True()
        {
            //Act
            var result = cat.DeleteCategory(5);

            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Save_New_Category()
        { 
            //Act
            var result = cat.SaveNewCategory(cat2);

            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Get_All_Category()
        {
            List< CategoryVM> cat2 = new List<CategoryVM>();

            //Act
            cat2 = cat.GetAllCategory();

            //Assert
            Assert.AreEqual(cat2.Count, 4);
        }
        [Test]
        public void Test_Update_Category_Return_True()
        {
            //Act
            cat2.ID = 2;
            var result = cat.UpdateCategory(cat2);
            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Update_CategoryReturn_False()
        {

            //Act
            cat2.title="aaaa";
            var result = cat.UpdateCategory(cat2);
            //Assert
            Assert.AreEqual(result, false);


        }
        [Test]
        public void Test_Check_Category_Exists_True()
        {
            //Act
            cat2.ID = 2;
            var result = cat.CheckCategoryExists(cat2);
            //Assert
            Assert.AreEqual(result, true);
        }
        [Test]
        public void Test_Check_Category_Exists_False()
        {
            //Act
            cat2.ID = 50;
            var result = cat.CheckCategoryExists(cat2);
            //Assert
            Assert.AreEqual(result, false);
        }
    }
}
