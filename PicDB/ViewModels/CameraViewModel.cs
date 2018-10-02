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
    /// <summary>
    /// A viewmodel of a camera
    /// </summary>
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

        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name of the producer
        /// </summary>
        public string Producer { get; set; }
        /// <summary>
        /// Name of the camera
        /// </summary>
        public string Make { get; set; }
        /// <summary>
        /// Datetime of buydate
        /// </summary>
        public DateTime? BoughtOn { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// OBSOLETE
        /// </summary>
        public int NumberOfPictures => throw new NotImplementedException();

        /// <summary>
        /// Checks if a camera viewmodel is valid
        /// </summary>
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

        /// <summary>
        /// Summary if validation check
        /// </summary>
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

        /// <summary>
        /// Checks if producer is valid
        /// </summary>
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

        /// <summary>
        /// Checks if make is valid
        /// </summary>
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

        /// <summary>
        /// Checks if buydate is valid
        /// </summary>
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

        /// <summary>
        /// Max ISO Value for good results. 0 means "not defined"
        /// </summary>
        public decimal ISOLimitGood { get; set; }
        /// <summary>
        /// Max ISO Value for acceptable results. 0 means "not defined"
        /// </summary>
        public decimal ISOLimitAcceptable { get; set; }

        /// <summary>
        /// OBSOLETE
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public ISORatings TranslateISORating(decimal iso)
        {
            throw new NotImplementedException();
        }
    }
}
