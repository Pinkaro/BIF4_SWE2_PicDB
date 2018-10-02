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
    /// <summary>
    /// A viewmodel of all cameras
    /// </summary>
    public class CameraListViewModel : ViewModelNotifier, ICameraListViewModel
    {
        private IEnumerable<ICameraViewModel> _list;
        /// <summary>
        /// A list of all CameraViewModels
        /// </summary>
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
        /// <summary>
        /// Reference to the currently selected camera in the UI
        /// </summary>
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

        /// <summary>
        /// Synchronizes all cameras to the UI
        /// </summary>
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
