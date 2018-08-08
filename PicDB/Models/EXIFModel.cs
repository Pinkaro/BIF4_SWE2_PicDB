using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    class EXIFModel : IEXIFModel
    {
        public EXIFModel()
        {
            FNumber = 14.0m;
            ExposureTime = 0.5m;
            ISOValue = 400;
            Make = "Canon";
            Flash = true;
        }

        public EXIFModel(IEXIFViewModel viewModel)
        {
            Make = viewModel.Make;
            FNumber = viewModel.FNumber;
            ExposureTime = viewModel.ExposureTime;
            ISOValue = viewModel.ISOValue;
            Flash = viewModel.Flash;
            ExposureProgram = ConvertExposureProgram(viewModel.ExposureProgram);
        }

        public string Make { get; set; }
        public decimal FNumber { get; set; }
        public decimal ExposureTime { get; set; }
        public decimal ISOValue { get; set; }
        public bool Flash { get; set; }
        public ExposurePrograms ExposureProgram { get; set; }

        private ExposurePrograms ConvertExposureProgram(string ExposureProgramAsString)
        {
            switch (ExposureProgramAsString)
            {
                case "Manual":
                    return ExposurePrograms.Manual;
                case "Normal":
                    return ExposurePrograms.Normal;
                case "AperturePriority":
                    return ExposurePrograms.AperturePriority;
                case "ShutterPriority":
                    return ExposurePrograms.ShutterPriority;
                case "CreativeProgram":
                    return ExposurePrograms.CreativeProgram;
                case "ActionProgram":
                    return ExposurePrograms.ActionProgram;
                case "PortraitMode":
                    return ExposurePrograms.PortraitMode;
                case "LandscapeMode":
                    return ExposurePrograms.LandscapeMode;
                default:
                    return ExposurePrograms.NotDefined;
            }
        }
    }
}
