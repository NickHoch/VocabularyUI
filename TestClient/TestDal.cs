using System;
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
        Mock<VocabularyClient> mock;
        [TestInitialize]
        public void Init()
        {
            serverDAL = new ServerDAL();
            mock = new Mock<VocabularyClient>();
        }

        [TestCleanup]
        public void Clean()
        {
            serverDAL = null;
            mock = null;
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
