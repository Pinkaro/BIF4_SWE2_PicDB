using System.Collections.Generic;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    /// <summary>
    /// A viewmodel of IPTC information of a picture
    /// </summary>
    public class IPTCViewModel : IIPTCViewModel
    {
        public IPTCViewModel() { }

        public IPTCViewModel(IIPTCModel model)
        {
            Keywords = model.Keywords;
            ByLine = model.ByLine;
            CopyrightNotice = model.CopyrightNotice;
            Headline = model.Headline;
            Caption = model.Caption;
        }

        /// <summary>
        /// A list of keywords
        /// </summary>
        public string Keywords { get; set; }
        /// <summary>
        /// Name of the photographer
        /// </summary>
        public string ByLine { get; set; }
        /// <summary>
        /// copyright noties. 
        /// </summary>
        public string CopyrightNotice { get; set; }

        private static readonly IEnumerable<string> _copyrightNotices = new List<string>()
        {
            "All rights reserved",
            "CC - BY",
            "CC - BY - SA",
            "CC - BY - ND",
            "CC - BY - NC",
            "CC - BY - NC - SA",
            "CC - BY - NC - ND",
        };

        /// <summary>
        /// A list of common copyright noties. e.g. All rights reserved, CC-BY, CC-BY-SA, CC-BY-ND, CC-BY-NC, CC-BY-NC-SA, CC-BY-NC-ND
        /// </summary>
        public IEnumerable<string> CopyrightNotices => _copyrightNotices;

        /// <summary>
        /// Summary/Headline of the picture
        /// </summary>
        public string Headline { get; set; }
        /// <summary>
        /// Caption/Abstract, a description of the picture
        /// </summary>
        public string Caption { get; set; }
    }
}
