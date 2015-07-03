using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDSHelper.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDSHelper.Model;

// ReSharper disable once CheckNamespace
namespace MSDSHelper.DAL.Tests
{
    [TestClass()]
    public class UserDaoTests
    {
        [TestMethod()]
        public void SelectLastTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectByLoginTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AdicionarTest()
        {
            User user = new User();
            user.Login = "luis.fernando@mail.com";
            user.Nome = "Luís F.";
            user.Password = "123";
            UserDao userDao = new UserDao();
            userDao.Adicionar(user);
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectByIDTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ValidePassTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectByNameTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectByLoginTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectLastTest1()
        {

        }

    }
}
