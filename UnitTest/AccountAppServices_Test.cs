using BL.AppServices;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class AccountAppServices_Test
    {

        [Test]
        public void Test_Find_User()
        {

            //Arrange
            AccountAppServices account = new AccountAppServices();
            //Act
            string name = "nawal";
            string password = "123";
            var result = account.Find(name, password);

            //Assert
            Assert.AreEqual(result, null);
        }
        [Test]
        public void Test_IsExisted()
        {
            //Arrange
            AccountAppServices account = new AccountAppServices();
            //Act
            string name = "nawal";
            string password = "123";
            var result = account.IsExisted(name, password);

            //Assert
            Assert.AreEqual(result, false);
        }
        [Test]
        public void Test_Assign_To_Role()
        {

           // Arrange
            AccountAppServices account = new AccountAppServices();
            //Act
            string userID = "1";
            string roleName = "Admin";
            //var result = account.AssignToRole();

            //Assert
           // Assert.AreEqual(result, false);
        }
        [Test]
        public void Test_Register()
        {

            //Arrange
            AccountAppServices account = new AccountAppServices();
            RegisterVM newUser = new RegisterVM();
            //Act
            var result = account.Register(newUser);
            IdentityResult result1 = result;
            //Assert
            Assert.AreEqual(result, result1);
        }

    }
}
