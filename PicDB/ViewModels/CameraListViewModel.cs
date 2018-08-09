using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Layers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PicDB.ViewModels
{
    class CameraListViewModel : ViewModelNotifier, ICameraListViewModel
    {
        public IEnumerable<ICameraViewModel> List { get; }

        public ICameraViewModel CurrentCamera
        {
            get => CurrentCamera;
            set
            {
                CurrentCamera = value;
                NotifyPropertyChanged("CurrentCamera");
            }
        }

        public CameraListViewModel()
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
