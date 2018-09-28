using System;
using log4net;
using NUnit.Framework;
using PicDB;
using PicDB.utils;

namespace MyUnitTests
{
    [TestFixture]
    public class MyTestCases
    {
        [Test]
        public void Config_Sets_ConnectiongString()
        {
            GlobalInformation.ReadConfigFile();
            Assert.IsNotNull(GlobalInformation.ConnectionString);
        }

        [Test]
        public void Config_Sets_PicturePath()
        {
            GlobalInformation.ReadConfigFile();
            Assert.IsNotNull(GlobalInformation.Path);
        }

        [Test]
        public void Config_Sets_ReportPath()
        {
            GlobalInformation.ReadConfigFile();
            Assert.IsNotNull(GlobalInformation.ReportPath);
        }

        [Test]
        public void DataAccessLayer()
        {
            GlobalInformation.ReadConfigFile();
            Assert.IsNotNull(GlobalInformation.ReportPath);
        }



    }
}
