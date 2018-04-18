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

        /*Correct version functionality parameter: "-v", "--v", "/v", "--version"*/
        [TestMethod()]
        public void TestCorrectArgsVersion1()
        {
            FileDetails fd = new FileDetails();
            String[] args = { "-v", "c:test.txt" };
            String actual = Program.chooseFunctionality(args);
            Regex regex = new Regex(@"\d*\.\d*\.\d*");
            Match match = regex.Match(actual);
            if (!match.Success)
                Assert.Fail();
        }

        [TestMethod()]
        public void TestCorrectArgsVersion2()
        {
            FileDetails fd = new FileDetails();
            String[] args = { "--v", "c:test.txt" };
            String actual = Program.chooseFunctionality(args);
            Regex regex = new Regex(@"\d*\.\d*\.\d*");
            Match match = regex.Match(actual);
            if (!match.Success)
                Assert.Fail();
        }

        [TestMethod()]
        public void TestCorrectArgsVersion3()
        {
            FileDetails fd = new FileDetails();
            String[] args = { "/v", "c:test.txt" };
            String actual = Program.chooseFunctionality(args);
            Regex regex = new Regex(@"\d*\.\d*\.\d*");
            Match match = regex.Match(actual);
            if (!match.Success)
                Assert.Fail();
        }

        [TestMethod()]
        public void TestCorrectArgsVersion4()
        {
            FileDetails fd = new FileDetails();
            String[] args = { "--version", "c:test.txt" };
            String actual = Program.chooseFunctionality(args);
            Regex regex = new Regex(@"\d*\.\d*\.\d*");
            Match match = regex.Match(actual);
            if (!match.Success)
                Assert.Fail();
        }

        /*Correct size functionality parameter: "-s", "--s", "/s", "--size"*/
        [TestMethod()]
        public void TestCorrectArgsSize1()
        {
            FileDetails fd = new FileDetails();
            String[] args = { "-s", "c:test.txt" };
            int actual = Int32.Parse(Program.chooseFunctionality(args));
            if (actual < 0 && actual > 200000)
                Assert.Fail();
        }

        [TestMethod()]
        public void TestCorrectArgsSize2()
        {
            FileDetails fd = new FileDetails();
            String[] args = { "--s", "c:test.txt" };
            int actual = Int32.Parse(Program.chooseFunctionality(args));
            if (actual < 0 && actual > 200000)
                Assert.Fail();
        }

        [TestMethod()]
        public void TestCorrectArgsSize3()
        {
            FileDetails fd = new FileDetails();
            String[] args = { "/s", "c:test.txt" };
            int actual = Int32.Parse(Program.chooseFunctionality(args));
            if (actual < 0 && actual > 200000)
                Assert.Fail();
        }

        [TestMethod()]
        public void TestCorrectArgsSize4()
        {
            FileDetails fd = new FileDetails();
            String[] args = { "--size", "c:test.txt" };
            int actual = Int32.Parse(Program.chooseFunctionality(args));
            if (actual < 0 && actual > 200000)
                Assert.Fail();
        }
    }
}