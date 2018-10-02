using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    /// <summary>
    /// ViewModel of EXIF information of a picture
    /// </summary>
    public class EXIFViewModel : IEXIFViewModel
    {
        public EXIFViewModel() { }

        public EXIFViewModel(IEXIFModel model)
        {
            Make = model.Make;
            FNumber = model.FNumber;
            ExposureTime = model.ExposureTime;
            ISOValue = model.ISOValue;
            Flash = model.Flash;
            ExposureProgram = model.ExposureProgram.ToString();
            ExposureProgramResource = "I have no idea what this is";
            // ?????
        }

        /// <summary>
        /// Name of camera
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Aperture number
        /// </summary>
        public decimal FNumber { get; set; }

        /// <summary>
        /// Exposure time
        /// </summary>
        public decimal ExposureTime { get; set; }

        /// <summary>
        /// ISO value
        /// </summary>
        public decimal ISOValue { get; set; }

        /// <summary>
        /// Flash yes/no
        /// </summary>
        public bool Flash { get; set; }

        /// <summary>
        /// Exposure program
        /// </summary>
        public string ExposureProgram { get; set; }

        /// <summary>
        /// Exposure program resource
        /// </summary>
        public string ExposureProgramResource { get; set; }

        /// <summary>
        /// Gets or sets a optional camera view model
        /// </summary>
        public ICameraViewModel Camera { get; set; }

        /// <summary>
        /// Returns a ISO rating if a camera is set.
        /// </summary>
        public ISORatings ISORating
        {
            get
            {
                if (Camera == null)
                {
                    return ISORatings.NotDefined;
                }

                if(ISOValue > 0 && ISOValue <= Camera.ISOLimitGood)
                {
                    return ISORatings.Good;
                }
                else if(ISOValue > Camera.ISOLimitGood && ISOValue <= Camera.ISOLimitAcceptable)
                {
                    return ISORatings.Acceptable;
                }
                else if(ISOValue > Camera.ISOLimitAcceptable && ISOValue <= 1600)
                {
                    return ISORatings.Noisey;
                }
                else
                {
                    return ISORatings.NotDefined;
                }
            }
        }

        /// <summary>
        /// Returns a image resource of a ISO rating if a camera is set.
        /// </summary>
        public string ISORatingResource { get; set; }
    }
}
