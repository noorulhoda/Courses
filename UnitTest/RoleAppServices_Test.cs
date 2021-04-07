using BL.AppServices;
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
    class RoleAppServices_Test
    {
        [Test]
        public void Test_Create_Role()
        {
            //Arrange
            RoleAppServices role = new RoleAppServices();
            //Act
            string roleName = "Admin";
            var result = role.Create(roleName);
            IdentityResult result1=result;
            //Assert
            Assert.AreEqual(result, result1);
        }
    }
}
