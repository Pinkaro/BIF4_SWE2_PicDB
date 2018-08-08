using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    class IPTCModel : IIPTCModel
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

        public string Keywords { get; set; }
        public string ByLine { get; set; }
        public string CopyrightNotice { get; set; }
        public string Headline { get; set; }
        public string Caption { get; set; }
    }
}
