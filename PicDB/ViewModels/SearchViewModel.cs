using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    /// <summary>
    /// ViewModel of searchbar
    /// </summary>
    public class SearchViewModel : ISearchViewModel
    {
        /// <summary>
        /// The search text
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// True, if a search is active
        /// </summary>
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
        /// <summary>
        /// Number of photos found.
        /// </summary>
        public int ResultCount { get; set; }
    }
}
