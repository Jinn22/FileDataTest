using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System;
using ThirdPartyTools;

namespace FileData.Tests
{
    [TestClass()]
    public class Tests
    {
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestNoArgs()
        {
            String actual = Program.chooseFunctionality(null);
        }

        [TestMethod()]
        public void TestCorrectArgsVersion()
        {
            FileDetails fd = new FileDetails();
            String[] args = {"-v", "c:test.txt" };
            String actual = Program.chooseFunctionality(args);
            Regex regex = new Regex(@"\d*\.\d*\.\d*");
            Match match = regex.Match(actual);
            if (!match.Success)
                Assert.Fail();
        }

        [TestMethod()]
        public void TestCorrectArgsSize()
        {
            FileDetails fd = new FileDetails();
            String[] args = { "-s", "c:test.txt" };
            int actual = Int32.Parse(Program.chooseFunctionality(args));
            if (actual < 0 && actual > 200000)
                Assert.Fail();
        }

        [TestMethod()]
        public void TestOneArgs()
        {   FileDetails fd = new FileDetails();
            String[] args = { "-v" };
            String actual = Program.chooseFunctionality(args);
            Assert.AreEqual(actual, "Wrong input");
        }

        [TestMethod()]
        public void TestWrongInput()
        {
            FileDetails fd = new FileDetails();
            String[] args = { "wrong functionality", "wrong file path" };
            String actual = Program.chooseFunctionality(args);
            Assert.AreEqual(actual, "Wrong input");
        }
    }
}