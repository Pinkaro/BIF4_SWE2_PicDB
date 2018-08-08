using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    class CameraModel : ICameraModel
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
            ID = viewModel.ID;
            Producer = viewModel.Producer;
            Make = viewModel.Make;
            BoughtOn = viewModel.BoughtOn;
            Notes = viewModel.Notes;
            ISOLimitGood = viewModel.ISOLimitGood;
            ISOLimitAcceptable = viewModel.ISOLimitAcceptable;
        }

        public int ID { get; set; }

        private string _producer;

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
        public DateTime? BoughtOn { get; set; }
        public string Notes { get; set; }
        public decimal ISOLimitGood { get; set; }
        public decimal ISOLimitAcceptable { get; set; }
    }
}
