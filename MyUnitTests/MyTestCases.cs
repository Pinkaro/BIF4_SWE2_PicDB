using System;
using System.Collections.Generic;
using BIF.SWE2.Interfaces.Models;
using log4net;
using NUnit.Framework;
using PicDB;
using PicDB.Layers;
using PicDB.Models;
using PicDB.utils;
using PicDB.ViewModels;

namespace MyUnitTests
{
    [TestFixture]
    public class MyTestCases
    {
        private static DataAccessLayerFactory _dalFactory;
        private static DataAccessLayer _dal;
        static MyTestCases()
        {
            _dal = (DataAccessLayer) DataAccessLayerFactory.Instance.CreateDataAccessLayer(false);
        }

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
        public void DataAccessLayer_Gets_Pictures()
        {
            GlobalInformation.ReadConfigFile();
            List<IPictureModel> list = new List<IPictureModel>(_dal.GetPictures(null, null, null, null));

            Assert.That(list.Count > 0);
        }
    }
}
