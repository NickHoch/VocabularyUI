using System;
using System.ServiceModel;
using DAL;
using DAL.ServiceVocabulary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestClient
{
    [TestClass]
    public class TestDal
    {
        ServerDAL serverDAL;
        Mock<IVocabulary> mock;

        [TestInitialize]
        public void Init()
        {
            mock = new Mock<IVocabulary>();
            serverDAL = new ServerDAL(mock.Object);
        }

        [TestCleanup]
        public void Clean()
        {
            serverDAL = null;
            mock = null;
        }

        [TestMethod]
        public void IsEmailAddressExists1()
        {
            mock.Setup(m => m.IsEmailAddressExists(It.IsAny<string>())).Returns(true);
            Assert.IsTrue(serverDAL.IsEmailAddressExists("myemail.com"));
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void IsEmailAddressExists2()
        {
            mock.Setup(m => m.IsEmailAddressExists(null)).Throws(new FaultException());
            serverDAL.IsEmailAddressExists(null);
        }


    }
}
