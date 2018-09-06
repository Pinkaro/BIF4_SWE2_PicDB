using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicDB.utils;

namespace PicDB.Models
{
    public class PictureViewModel : ViewModelNotifier, IPictureViewModel
    {
        public PictureViewModel() { }

        public PictureViewModel(IPictureModel model)
        {

            if (model is PictureModel)
            {
                IPTC = new IPTCViewModel(model.IPTC);
                EXIF = new EXIFViewModel(model.EXIF);
                Photographer = new PhotographerViewModel(((PictureModel)model).Photographer);
                Camera = new CameraViewModel(model.Camera);
            }

            if (model != null)
            {
                ID = model.ID;
                FileName = model.FileName;
                FilePath = GlobalInformation.Path + "\\" + FileName;
                DisplayName = FileName.Split('.')[0];
                string name = model.FileName;
                string by = model.IPTC.ByLine;
                DisplayName = name + " (by " + Photographer.FirstName + " " + Photographer.LastName + ")";
            }
        }

        public int ID { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string DisplayName { get; set; }

        public IIPTCViewModel IPTC { get; set; }

        public IEXIFViewModel EXIF { get; set; }

        public IPhotographerViewModel Photographer { get; set; }

        public ICameraViewModel Camera { get; set; }
    }
}
