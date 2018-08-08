using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB.Models
{
    class IPTCViewModel : IIPTCViewModel
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

        public string Keywords { get; set; }
        public string ByLine { get; set; }
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

        public IEnumerable<string> CopyrightNotices => _copyrightNotices;

        public string Headline { get; set; }
        public string Caption { get; set; }
    }
}
