using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    /// <summary>
    /// The model of a camera
    /// </summary>
    public class CameraModel : ICameraModel
    {
        public CameraModel() { }

        public CameraModel(int ID)
        {
            this.ID = ID;
        }

        public CameraModel(string producer, string make)
        {
            Producer = producer;
            Make = make;
        }

        public CameraModel(ICameraViewModel viewModel)
        {
            if (viewModel != null)
            {
                ID = viewModel.ID;
                Producer = viewModel.Producer;
                Make = viewModel.Make;
                BoughtOn = viewModel.BoughtOn;
                Notes = viewModel.Notes;
                ISOLimitGood = viewModel.ISOLimitGood;
                ISOLimitAcceptable = viewModel.ISOLimitAcceptable;
            }
        }

        /// <summary>
        /// ID of a camera (has to match with database)
        /// </summary>
        public int ID { get; set; }

        private string _producer;

        /// <summary>
        /// Producer of a camera
        /// </summary>
        public string Producer
        {
            get
            {
                if (!string.IsNullOrEmpty(_producer))
                {
                    return _producer;
                }

                return "not set";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _producer = value;
                }
            }
        }

        private string _make;
        /// <summary>
        /// Make of a camera
        /// </summary>
        public string Make
        {
            get
            {
                if (!string.IsNullOrEmpty(_make))
                {
                    return _make;
                }

                return "not set";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _make = value;
                }
            }
        }

        /// <summary>
        /// Datetime this camera has been bought on.
        /// </summary>
        public DateTime? BoughtOn { get; set; }

        /// <summary>
        /// Notes about the camera, eg.: 'Makes very nice photographs in plain sunlight'
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Which ISO limit a camera has to surpass to be considered good
        /// </summary>
        public decimal ISOLimitGood { get; set; }
        /// <summary>
        /// Which ISO limit is deemed still acceptable
        /// </summary>
        public decimal ISOLimitAcceptable { get; set; }
    }
}
