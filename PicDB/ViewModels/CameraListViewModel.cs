using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Layers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace PicDB.ViewModels
{
    class CameraListViewModel : ViewModelNotifier, ICameraListViewModel
    {
        private IEnumerable<ICameraViewModel> _list;
        public IEnumerable<ICameraViewModel> List
        {
            get => _list;
            private set
            {
                _list = value;
                NotifyPropertyChanged("List");
            }
        }

        private ICameraViewModel _currentCamera;
        public ICameraViewModel CurrentCamera
        {
            get => _currentCamera;
            set
            {
                _currentCamera = value;
                NotifyPropertyChanged("CurrentCamera");
            }
        }

        public CameraListViewModel()
        {
            SynchronizeCameras();
        }

        public void SynchronizeCameras()
        {
            var bl = new BusinessLayer();
            var cameraModels = bl.GetCameras();
            var cameraViewModels = new ObservableCollection<ICameraViewModel>();
            foreach (var cameraModel in cameraModels)
            {
                cameraViewModels.Add(new CameraViewModel(cameraModel));
            }

            List = cameraViewModels;
        }
    }
}
