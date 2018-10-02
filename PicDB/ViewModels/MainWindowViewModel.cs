using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Layers;
using PicDB.Models;

namespace PicDB.ViewModels
{
    /// <summary>
    /// Controller. Use this if changes come FROM the UI.
    /// </summary>
    public class MainWindowViewModel : ViewModelNotifier, IMainWindowViewModel
    {
        private readonly BusinessLayer _businessLayer = new BusinessLayer();

        private IPictureViewModel _currentPicture;
        /// <summary>
        /// Currently selected picture in the UI
        /// </summary>
        public IPictureViewModel CurrentPicture
        {
            get => _currentPicture;
            set
            {
                if (_currentPicture != value)
                {
                    if (value != null)
                    {
                        _currentPicture = new PictureViewModel(_businessLayer.GetPicture(value.ID));
                        ((PictureListViewModel)List).CurrentPicture = _currentPicture;
                        Title = "PicDB - " + _currentPicture.DisplayName;
                        NotifyPropertyChanged(nameof(CurrentPicture));
                    }
                }
            }
        }

        private string _title;
        /// <summary>
        /// Title to be displayed in MainWindow
        /// </summary>
        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(_title))
                {
                    return "PicDB";
                }
                    return "PicDB - " + _currentPicture.DisplayName; 
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
        /// <summary>
        /// ViewModel with a list of all Pictures
        /// </summary>
        public IPictureListViewModel List { get; set; } = new PictureListViewModel();
        /// <summary>
        /// Search ViewModel
        /// </summary>
        public ISearchViewModel Search { get; set; } = new SearchViewModel();
        /// <summary>
        /// ViewModel with a list of all cameras
        /// </summary>
        public ICameraListViewModel CameraList { get; set; } = new CameraListViewModel();
        /// <summary>
        /// ViewModel witha list of all photographers
        /// </summary>
        public IPhotographerListViewModel PhotographerList { get; set; } = new PhotographerListViewModel();

        public MainWindowViewModel()
        {
            if (List != null)
            {
                CurrentPicture = List.CurrentPicture;
                Title = "PicDB - " + CurrentPicture.DisplayName;
            }
        }

        /// <summary>
        /// Saves currently selected picture to DB
        /// </summary>
        public void SaveCurrentPicture()
        {
            _businessLayer.Save(new PictureModel(CurrentPicture));
        }

        /// <summary>
        /// Saves camera and photographer with currently selected picture to DB
        /// </summary>
        /// <param name="cameraViewmodel"></param>
        /// <param name="photographerViewModel"></param>
        internal void SaveGeneralInformation(CameraViewModel cameraViewmodel, PhotographerViewModel photographerViewModel)
        {
            ((PictureViewModel)CurrentPicture).Camera = cameraViewmodel;
            ((PictureViewModel)CurrentPicture).Photographer = photographerViewModel;
            SaveCurrentPicture();
        }

        /// <summary>
        /// Updates a camera with changes from UI
        /// </summary>
        /// <param name="cameraViewModel"></param>
        internal void UpdateCamera(ICameraViewModel cameraViewModel)
        {
            _businessLayer.UpdateCamera(new CameraModel(cameraViewModel));
            ((CameraListViewModel)CameraList).SynchronizeCameras();
        }

        /// <summary>
        /// Deletes camera with given ID from DB
        /// </summary>
        /// <param name="ID"></param>
        internal void DeleteCamera(int ID)
        {
            _businessLayer.DeleteCamera(ID);
            ((CameraListViewModel)CameraList).SynchronizeCameras();
        }

        /// <summary>
        /// Saves new camera to DB
        /// </summary>
        /// <param name="camera"></param>
        public void SaveCamera(CameraViewModel camera)
        {
            _businessLayer.SaveCamera(new CameraModel(camera));
            var cameraList = (CameraListViewModel)CameraList;
            cameraList.SynchronizeCameras();
        }

        /// <summary>
        /// Updates photographer
        /// </summary>
        /// <param name="photographerViewModel"></param>
        public void UpdatePhotographer(PhotographerViewModel photographerViewModel)
        {
            _businessLayer.UpdatePhotographer(new PhotographerModel(photographerViewModel));
            ((PhotographerListViewModel)PhotographerList).SynchronizePhotographers();
        }

        /// <summary>
        /// Deletes photographer with given ID
        /// </summary>
        /// <param name="id"></param>
        public void DeletePhotographer(int id)
        {
            _businessLayer.DeletePhotographer(id);
            ((PhotographerListViewModel)PhotographerList).SynchronizePhotographers();
        }

        /// <summary>
        /// Saves photographer to DB
        /// </summary>
        /// <param name="photographer"></param>
        internal void SavePhotographer(PhotographerViewModel photographer)
        {
            _businessLayer.SavePhotographer(new PhotographerModel(photographer));
            var photographerlist = (PhotographerListViewModel)PhotographerList;
            photographerlist.SynchronizePhotographers();
        }
    }
}
