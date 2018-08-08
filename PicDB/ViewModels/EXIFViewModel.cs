using BIF.SWE2.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;

namespace PicDB.Models
{
    class EXIFViewModel : IEXIFViewModel
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

        public string Make { get; set; }

        public decimal FNumber { get; set; }

        public decimal ExposureTime { get; set; }

        public decimal ISOValue { get; set; }

        public bool Flash { get; set; }

        public string ExposureProgram { get; set; }

        public string ExposureProgramResource { get; set; }

        public ICameraViewModel Camera { get; set; }

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

        public string ISORatingResource { get; set; }
    }
}
