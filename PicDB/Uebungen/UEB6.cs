using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB;
using PicDB.Layers;
using PicDB.Models;

namespace Uebungen
{
    public class UEB6 : IUEB6
    {
        public void HelloWorld()
        {
        }

        public IBusinessLayer GetBusinessLayer()
        {
            PictureModel mockPicture = new PictureModel() { FileName = "Blume.jpg" };

            IBusinessLayer bl = BusinessLayer.Instance;
            bl.Sync();
            bl.Save(mockPicture);
            return bl;
        }

        public void TestSetup(string picturePath)
        {

        }

        public IPictureModel GetEmptyPictureModel()
        {
            return new PictureModel();
        }

        public IPhotographerModel GetEmptyPhotographerModel()
        {
            return new PhotographerModel();
        }
    }
}
