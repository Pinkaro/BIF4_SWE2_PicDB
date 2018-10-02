using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Layers;
using PicDB.Models;

namespace PicDB.ViewModels
{
    /// <summary>
    /// ViewModel of a picture
    /// </summary>
    public class PictureListViewModel : ViewModelNotifier, IPictureListViewModel
    {
        private BusinessLayer bl;
        public PictureListViewModel()
        {
            bl = new BusinessLayer();
            SyncAndUpdatePictureList();
        }
        /// <summary>
        /// OBSOLETE: All prev. pictures to the current selected picture.
        /// </summary>
        public IEnumerable<IPictureViewModel> PrevPictures => throw new NotImplementedException();
        /// <summary>
        /// OBSOLETE: All next pictures to the current selected picture.
        /// </summary>
        public IEnumerable<IPictureViewModel> NextPictures => throw new NotImplementedException();
        /// <summary>
        /// OBSOLETE: Number of all images
        /// </summary>
        public int Count => throw new NotImplementedException();
        /// <summary>
        /// OBSOLETE: The current Index, 1 based
        /// </summary>
        public int CurrentIndex => throw new NotImplementedException();
        /// <summary>
        /// OBSOLETE: {CurrentIndex} of {Cout}
        /// </summary>
        public string CurrentPictureAsString => throw new NotImplementedException();

        private IPictureViewModel _currentPicture;
        /// <summary>
        /// ViewModel of the current picture
        /// </summary>
        public IPictureViewModel CurrentPicture
        {
            get => _currentPicture;
            set
            {
                if (_currentPicture != value)
                {
                    _currentPicture = value;
                    NotifyPropertyChanged(nameof(CurrentPicture));
                }
            }
        }

        private ObservableCollection<IPictureViewModel> _backupList;
        private ObservableCollection<IPictureViewModel> _list = new ObservableCollection<IPictureViewModel>();

        /// <summary>
        /// List of all PictureViewModels
        /// </summary>
        public IEnumerable<IPictureViewModel> List
        {
            get => _list;
            set
            {
                _list = (ObservableCollection<IPictureViewModel>) value;
                NotifyPropertyChanged("List");
            }
        }

        /// <summary>
        /// Resets a modified list to its original state.
        /// </summary>
        public void ResetList()
        {
            _list = new ObservableCollection<IPictureViewModel>(_backupList);
        }

        /// <summary>
        /// Syncs the list with the database
        /// </summary>
        public void SyncAndUpdatePictureList()
        {
            bl.Sync();
            var pictures = bl.GetPictures();
            CurrentPicture = null;
            _list.Clear();
            foreach (IPictureModel model in pictures)
            {
                _list.Add(new PictureViewModel((PictureModel)model));
            }
            _backupList = new ObservableCollection<IPictureViewModel>(_list);

            int firstModelID = _list.First().ID;
            CurrentPicture = new PictureViewModel(bl.GetPicture(firstModelID));
        }
    }
}
