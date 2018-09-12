using BIF.SWE2.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using PicDB.Models;
using BIF.SWE2.Interfaces.Models;

namespace PicDB.ViewModels
{
    public class CameraViewModel : ICameraViewModel
    {
        public CameraViewModel() { }

        public CameraViewModel(ICameraModel model)
        {
            if (model == null) return;
            ID = model.ID;
            Producer = model.Producer;
            BoughtOn = model.BoughtOn;
            Make = model.Make;
            ISOLimitGood = model.ISOLimitGood;
            ISOLimitAcceptable = model.ISOLimitAcceptable;
            Notes = model.Notes;
        }

        public int ID { get; set; }
        public string Producer { get; set; }
        public string Make { get; set; }
        public DateTime? BoughtOn { get; set; }
        public string Notes { get; set; }

        public int NumberOfPictures => throw new NotImplementedException();

        public bool IsValid
        {
            get
            {
                if (IsValidBoughtOn && IsValidMake && IsValidProducer)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string ValidationSummary
        {
            get
            {
                if (IsValid)
                {
                    return string.Empty;
                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    if (!IsValidBoughtOn)
                    {
                        sb.AppendLine("BoughtOn date is not valid.");
                    }

                    if (!IsValidMake)
                    {
                        sb.AppendLine("Make is not valid.");
                    }

                    if (!IsValidProducer)
                    {
                        sb.AppendLine("Producer is not valid.");
                    }

                    return sb.ToString();
                }
            }
        }

        public bool IsValidProducer
        {
            get
            {
                if(Producer == null || Producer == string.Empty)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool IsValidMake
        {
            get
            {
                if(Make == null || Make == string.Empty)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool IsValidBoughtOn
        {
            get
            {
                if(BoughtOn > DateTime.Now)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public decimal ISOLimitGood { get; set; }
        public decimal ISOLimitAcceptable { get; set; }

        public ISORatings TranslateISORating(decimal iso)
        {
            throw new NotImplementedException();
        }
    }
}
