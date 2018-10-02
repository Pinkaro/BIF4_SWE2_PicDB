using System.Collections.Generic;
using System.Collections.ObjectModel;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Layers;
using PicDB.Models;

namespace PicDB.ViewModels
{
    /// <summary>
    /// ViewModel with a list of all photographers
    /// </summary>
    public class PhotographerListViewModel : ViewModelNotifier, IPhotographerListViewModel
    {
        private IEnumerable<IPhotographerViewModel> _list;
        /// <summary>
        /// List of all PhotographerViewModels
        /// </summary>
        public IEnumerable<IPhotographerViewModel> List {
            get => _list;
            private set
            {
                _list = value;
                NotifyPropertyChanged("List");
            }
        }
        /// <summary>
        /// The currently selected PhotographerViewModel
        /// </summary>
        public IPhotographerViewModel CurrentPhotographer
        {
            get => CurrentPhotographer;
            set
            {
                CurrentPhotographer = value;
                NotifyPropertyChanged("CurrentPhotographer");
            }
        }

        public PhotographerListViewModel()
        {
            SynchronizePhotographers();
        }

        /// <summary>
        /// Synchronizes photographerlist 
        /// </summary>
        public void SynchronizePhotographers()
        {
            var bl = new BusinessLayer();
            var photographerModels = bl.GetPhotographers();
            var photogrViewModels = new ObservableCollection<IPhotographerViewModel>();
            foreach (var photographerModel in photographerModels)
            {
                photogrViewModels.Add(new PhotographerViewModel(photographerModel));
            }

            List = photogrViewModels;
        }
    }
}
