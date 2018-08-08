using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    class PictureModel : IPictureModel
    { 
        public PictureModel()
        {
            IPTC = new IPTCModel();
            IPTC = new IPTCModel();
            EXIF = new EXIFModel();
            Camera = new CameraModel();
            Photographer = new PhotographerModel();
        }

        public PictureModel(int ID)
        {
            this.ID = ID;
            EXIF = new EXIFModel();
            IPTC = new IPTCModel();
            Photographer = new PhotographerModel();
            Camera = new CameraModel();
        }

        public PictureModel(string FileName)
        {
            this.FileName = FileName;
        }

        public PictureModel(IPictureViewModel viewModel)
        {
            ID = viewModel.ID;
            FileName = viewModel.FileName;
            IPTC = new IPTCModel(viewModel.IPTC); 
            EXIF = new EXIFModel(viewModel.EXIF);
            Camera = new CameraModel(viewModel.Camera);
            Photographer = new PhotographerModel(viewModel.Photographer);
        }

        public int ID { get; set; }
        public string FileName { get; set; }
        public IIPTCModel IPTC { get; set; }
        public IEXIFModel EXIF { get; set; }
        public ICameraModel Camera { get; set; }
        public IPhotographerModel Photographer { get; set; }
    }
}
