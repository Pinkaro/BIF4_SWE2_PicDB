using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicDB.ViewModels;

namespace PicDB.Models
{
    class PhotographerViewModel : IPhotographerViewModel
    {
        public PhotographerViewModel(IPhotographerModel mdl)
        {
            if (mdl == null) return;
            ID = mdl.ID;
            FirstName = mdl.FirstName;
            LastName = mdl.LastName;
            BirthDay = mdl.BirthDay;
            Notes = mdl.Notes;
        }

        public PhotographerViewModel() { }

        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Notes { get; set; }

        public int NumberOfPictures { get; set; }

        public bool IsValid
        {
            get
            {
                if(IsValidLastName && IsValidBirthDay)
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

                    if (!IsValidBirthDay)
                    {
                        sb.Append("BirthDay is not valid.");
                    }

                    if (!IsValidLastName)
                    {
                        sb.Append("LastName is not valid.");
                    }

                    return sb.ToString();
                }
            }
        }

        public bool IsValidLastName
        {
            get
            {
                if(LastName == null || LastName == string.Empty)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool IsValidBirthDay
        {
            get
            {
                if(BirthDay > DateTime.Now)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
