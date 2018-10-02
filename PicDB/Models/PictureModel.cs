using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    /// <summary>
    /// Model of a picture
    /// </summary>
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
            if(viewModel.Camera != null) Camera = new CameraModel(viewModel.Camera);
            if(viewModel.Photographer != null) Photographer = new PhotographerModel(viewModel.Photographer);
        }

        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// File name, without path
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// IPTC information
        /// </summary>
        public IIPTCModel IPTC { get; set; }
        /// <summary>
        /// EXIF information
        /// </summary>
        public IEXIFModel EXIF { get; set; }
        /// <summary>
        /// Camera
        /// </summary>
        public ICameraModel Camera { get; set; }
        /// <summary>
        /// Photographer
        /// </summary>
        public IPhotographerModel Photographer { get; set; }
    }
}
