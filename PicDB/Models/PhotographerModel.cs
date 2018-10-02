using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    /// <summary>
    /// A model of a photographer
    /// </summary>
    public class PhotographerModel : IPhotographerModel
    {
        public PhotographerModel()
        {

        }

        public PhotographerModel(int ID)
        {
            this.ID = ID;
        }

        public PhotographerModel(IPhotographerViewModel viewModel)
        {
            ID = viewModel.ID;
            FirstName = viewModel.FirstName;
            LastName = viewModel.LastName;
            BirthDay = viewModel.BirthDay;
            Notes = viewModel.Notes;
        }

        /// <summary>
        /// ID of a photographer (must match with database)
        /// </summary>
        public int ID { get; set; }

        private string _firstName;
        /// <summary>
        /// First name of a photographer
        /// </summary>
        public string FirstName {
            get
            {
                if (!string.IsNullOrEmpty(_firstName))
                {
                    return _firstName;
                }

                return "not set";
            }
            set
            {
                if (string.IsNullOrEmpty(_firstName))
                {
                    _firstName = value;
                }
            }
        }

        private string _lastName;
        /// <summary>
        /// Last name of a photographer
        /// </summary>
        public string LastName
        {
            get
            {
                if (!string.IsNullOrEmpty(_lastName))
                {
                    return _lastName;
                }

                return "not set";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _lastName = value;
                }
            }
        }

        /// <summary>
        /// Datetime of birth
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }
    }
}
