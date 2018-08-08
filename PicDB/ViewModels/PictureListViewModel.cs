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
        public PictureListViewModel()
        {
            var pictures = BusinessLayer.Instance.GetPictures();

            foreach (IPictureModel model in pictures)
            {
                _list.Add(new PictureViewModel((PictureModel)model));
            }

            CurrentPicture = _list.First();
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
    }
}
