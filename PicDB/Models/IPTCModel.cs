using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    /// <summary>
    /// A model for IPTC information of a picture
    /// </summary>
    public class IPTCModel : IIPTCModel
    {
        public IPTCModel()
        {
            ByLine = "not set";
            Keywords = "not set";
            CopyrightNotice = "not set";
            Headline = "not set";
            Caption = "not set";
        }

        public IPTCModel(IIPTCViewModel viewModel)
        {
            Keywords = viewModel.Keywords;
            ByLine = viewModel.ByLine;
            CopyrightNotice = viewModel.CopyrightNotice;
            Headline = viewModel.Headline;
            Caption = viewModel.Caption;
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
        /// copyright notices
        /// </summary>
        public string CopyrightNotice { get; set; }
        /// <summary>
        /// Headline of picture
        /// </summary>
        public string Headline { get; set; }
        /// <summary>
        /// description of picture
        /// </summary>
        public string Caption { get; set; }
    }
}
