using BIF.SWE2.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using PicDB.Layers;
using PicDB.ViewModels;

namespace PicDB.Models
{
    class MainWindowViewModel : ViewModelNotifier, IMainWindowViewModel
    {
        private readonly BusinessLayer _businessLayer = BusinessLayer.Instance;

        private IPictureViewModel _currentPicture;
        public IPictureViewModel CurrentPicture
        {
            get => _currentPicture;
            set
            {
                if (_currentPicture != value)
                {
                    _currentPicture = value;
                    Title = "PicDB - " + _currentPicture.DisplayName;
                    NotifyPropertyChanged(nameof(CurrentPicture));
                }
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(_title))
                {
                    return "PicDB";
                }
                    return _title; 
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _title = value;
                    NotifyPropertyChanged(nameof(Title));
                }
            }
        }

        public IPictureListViewModel List { get; set; } = new PictureListViewModel();

        public ISearchViewModel Search { get; } = new SearchViewModel();

        public MainWindowViewModel()
        {
            CurrentPicture = List.CurrentPicture;
            Title = "PicDB - " + CurrentPicture.DisplayName;
        }

        public void SaveCurrentPicture()
        {
            _businessLayer.Save(new PictureModel(CurrentPicture));
        }

        //public ObservableCollection<> CreatePictureViewModelCollection()
    }
}
