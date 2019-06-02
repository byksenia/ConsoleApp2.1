using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int actual = 8;
            
            Assert.AreEqual(actual, Program.createMessage()); 
        }
    }
}
