using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    /// <summary>
    /// ViewModel of a picture
    /// </summary>
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
                EXIF.Camera = Camera;
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
        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Full file path, used to load the image
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// The line below the Picture. Format: {IPTC.Headline|FileName} (by {Photographer|IPTC.ByLine}).
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// The IPTC ViewModel
        /// </summary>
        public IIPTCViewModel IPTC { get; set; }
        /// <summary>
        /// The EXIF ViewModel
        /// </summary>
        public IEXIFViewModel EXIF { get; set; }
        /// <summary>
        /// The Photographer ViewModel
        /// </summary>
        public IPhotographerViewModel Photographer { get; set; }
        /// <summary>
        /// The Camera ViewModel
        /// </summary>
        public ICameraViewModel Camera { get; set; }
    }
}
