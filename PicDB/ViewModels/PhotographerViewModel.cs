using System;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    /// <summary>
    /// ViewModel of a photographer
    /// </summary>
    public class PhotographerViewModel : IPhotographerViewModel
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
        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Firstname, including middle name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Lastname
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Returns the number of Pictures
        /// </summary>
        public int NumberOfPictures { get; set; }
        /// <summary>
        /// Returns true, if the model is valid
        /// </summary>
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
        /// <summary>
        /// Returns a summary of validation errors
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
        /// <summary>
        /// returns true if the last name is valid
        /// </summary>
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
        /// <summary>
        /// returns true if the birthday is valid
        /// </summary>
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
