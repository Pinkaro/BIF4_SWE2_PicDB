using BIF.SWE2.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB.Models
{
    class SearchViewModel : ISearchViewModel
    {
        public string SearchText { get; set; }

        public bool IsActive
        {
            get
            {
                if (SearchText == null || SearchText.Equals(string.Empty))
                {
                    return false;
                }
                return true;
            }
        }

        public int ResultCount { get; set; }
    }
}
