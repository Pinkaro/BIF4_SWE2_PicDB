using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Layers;
using PicDB.Mocks;
using PicDB.Models;
using PicDB.ViewModels;

namespace PicDB.Uebungen
{
    public class UEB2 : IUEB2
    {
        BusinessLayer businessLayer = new BusinessLayer();

        public UEB2()
        {

        }

        public void HelloWorld()
        {
            
        }

        public IBusinessLayer GetBusinessLayer()
        {
            if(businessLayer == null)
            {
                return new MockBusinessLayer();
            }
            return businessLayer;
        }

        public BIF.SWE2.Interfaces.ViewModels.IMainWindowViewModel GetMainWindowViewModel()
        {
            return new MainWindowViewModel();
        }

        public BIF.SWE2.Interfaces.Models.IPictureModel GetPictureModel(string filename)
        {
            return new PictureModel() { FileName = filename, IPTC = new IPTCModel() };
        }

        public BIF.SWE2.Interfaces.ViewModels.IPictureViewModel GetPictureViewModel(BIF.SWE2.Interfaces.Models.IPictureModel mdl)
        {
            return new PictureViewModel(mdl);
        }

        public void TestSetup(string picturePath)
        {
            //businessLayer.PathFolder = picturePath;
        }

        public ICameraModel GetCameraModel(string producer, string make)
        {
            return new CameraModel() { Make = make, Producer = producer };
        }

        public ICameraViewModel GetCameraViewModel(ICameraModel mdl)
        {
            return new CameraViewModel() { Producer = mdl.Producer, Make = mdl.Make };
        }
    }
}
