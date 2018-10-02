using System.Collections.Generic;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using NUnit.Framework;
using PicDB.Layers;
using PicDB.Mocks;
using PicDB.Models;
using PicDB.ViewModels;

namespace PicDB.utils
{
    [TestFixture]
    public class MyTestCases
    {
        private static DataAccessLayer _dal;
        static MyTestCases()
        {
            GlobalInformation.ReadConfigFile();
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
            List<IPictureModel> list = new List<IPictureModel>(_dal.GetPictures(null, null, null, null));
            Assert.That(list.Count > 0);
        }

        [Test]
        public void DataAccessLayer_Gets_TestPictures()
        {
            List<IPictureModel> list = new List<IPictureModel>(_dal.GetPictures(null, null, null, null));
            Assert.That(list.Count == 5);
        }

        [Test]
        public void DataAccessLayer_Gets_Photographers()
        {
            List<IPhotographerModel> list = new List<IPhotographerModel>(_dal.GetPhotographers());
            Assert.That(list.Count > 0);
        }

        [Test]
        public void DataAccessLayer_Gets_Cameras()
        {
            List<ICameraModel> list = new List<ICameraModel>(_dal.GetCameras());
            Assert.That(list.Count > 0);
        }

        [Test]
        public void DataAccessLayer_Gets_TagCount()
        {
            Dictionary<string, int> tags = _dal.GetTagCount();
            Assert.That(tags.Keys.Count > 0);
        }

        [Test]
        public void MainWindowViewModel_Initiates_CurrentPicture()
        {
            MainWindowViewModel controller = new MainWindowViewModel();
            Assert.That(controller.CurrentPicture != null);
        }

        [Test]
        public void MainWindowViewModel_Sets_WindowTitle()
        {
            MainWindowViewModel controller = new MainWindowViewModel();
            Assert.That(!string.IsNullOrWhiteSpace(controller.Title));
        }

        [Test]
        public void MainWindowViewModel_Sets_WindowTitleAfterChange()
        {
            string testTitle = "Test title";
            MainWindowViewModel controller = new MainWindowViewModel();
            ((PictureViewModel)controller.CurrentPicture).DisplayName = testTitle;
            Assert.That(controller.Title.Contains(testTitle), "Does not containt test title, title was: " + controller.Title);
        }

        [Test]
        public void PictureListViewModel_Sets_CurrentPicture()
        {
            MainWindowViewModel controller = new MainWindowViewModel();
            Assert.That(controller.List.CurrentPicture != null);
        }

        [Test]
        public void PictureListViewModel_Sets_Pictures()
        {
            MainWindowViewModel controller = new MainWindowViewModel();
            Assert.That(controller.List.Count > 0);
        }

        [Test]
        public void PictureViewModel_Sets_CameraForExif()
        {
            MainWindowViewModel controller = new MainWindowViewModel();
            IPictureViewModel pictureViewModel = controller.CurrentPicture;
            Assert.That(pictureViewModel.EXIF.Camera != null);
        }

        [Test]
        public void DataAccessLayerFactory_Returns_MockDal()
        {
            DataAccessLayerFactory dalFactory = DataAccessLayerFactory.Instance;
            Assert.AreEqual(typeof(MockDataAccessLayer), dalFactory.CreateDataAccessLayer(true));
        }

        [Test]
        public void DataAccessLayerFactory_Returns_ActualDal()
        {
            DataAccessLayerFactory dalFactory = DataAccessLayerFactory.Instance;
            Assert.AreEqual(typeof(DataAccessLayer), dalFactory.CreateDataAccessLayer(false));
        }


    }
}
