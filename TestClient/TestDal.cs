using System;
using System.ServiceModel;
using DAL;
using DAL.DTOs;
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

        [TestMethod]
        public void IsDictionaryNameExists1()
        {
            mock.Setup(m => m.IsDictionaryNameExists(It.IsAny<string>(), It.Is<int>(x => x > 0))).Returns(true);
            Assert.IsTrue(serverDAL.IsDictionaryNameExists("", 1));
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void IsDictionaryNameExists2()
        {
            mock.Setup(m => m.IsDictionaryNameExists(It.IsAny<string>(), It.Is<int>(x => x <= 0))).Throws(new FaultException());
            serverDAL.IsDictionaryNameExists("", -5);
        }

        [TestMethod]
        public void GetUserIdByCredential1()
        {
            mock.Setup(m => m.GetUserIdByCredential(It.IsAny<CredentialDC>())).Returns(1);
            Assert.AreEqual(1, serverDAL.GetUserIdByCredential(new CredentialDTO()));
        }

        [TestMethod]
        public void GetUserIdByCredential2()
        {
            mock.Setup(m => m.GetUserIdByCredential(It.Is<CredentialDC>(x=>x.Email == ""))).Returns<int?>(null);

            Assert.IsNull(serverDAL.GetUserIdByCredential(new CredentialDTO() {Email="ghdgd" }));
        }
    }
}
