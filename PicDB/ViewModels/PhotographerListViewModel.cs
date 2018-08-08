using BIF.SWE2.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB.Models
{
    class PhotographerListViewModel : IPhotographerListViewModel
    {
        public IPhotographerViewModel CurrentPhotographer => throw new NotImplementedException();

        IEnumerable<IPhotographerViewModel> IPhotographerListViewModel.List => throw new NotImplementedException();
    }
}
