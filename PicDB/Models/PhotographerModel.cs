using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    class PhotographerModel : IPhotographerModel
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
        public int ID { get; set; }

        private string _firstName;
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
        public DateTime? BirthDay { get; set; }
        public string Notes { get; set; }
    }
}
