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
    class PictureListViewModel : ViewModelNotifier, IPictureListViewModel
    {
        private BusinessLayer bl;
        public PictureListViewModel()
        {
            bl = new BusinessLayer();
            SyncAndUpdatePictureList();
        }

        public IEnumerable<IPictureViewModel> PrevPictures => throw new NotImplementedException();

        public IEnumerable<IPictureViewModel> NextPictures => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public int CurrentIndex => throw new NotImplementedException();

        public string CurrentPictureAsString => throw new NotImplementedException();

        private IPictureViewModel _currentPicture;
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

        public IEnumerable<IPictureViewModel> List
        {
            get => _list;
            set
            {
                _list = (ObservableCollection<IPictureViewModel>) value;
                NotifyPropertyChanged("List");
            }
        }

        public void ResetList()
        {
            _list = new ObservableCollection<IPictureViewModel>(_backupList);
        }

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
