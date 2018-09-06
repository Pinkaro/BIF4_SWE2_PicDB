using PicDB.Models;
using PicDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for CameraWindow.xaml
    /// </summary>
    public partial class CameraWindow : Window
    {
        private CameraViewModel lastSelectedViewModel;
        private MainWindowViewModel _controller;
        public CameraWindow(MainWindowViewModel controller)
        {
            _controller = controller;
            InitializeComponent();
            this.DataContext = _controller;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var CameraAddWindow = new CameraAddWindow(_controller);
            CameraAddWindow.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lastSelectedViewModel != null)
            {
                var cameraViewModel = lastSelectedViewModel;
                int ID = cameraViewModel.ID;
                try
                {
                    _controller.DeleteCamera(ID);
                    Producer.Text = string.Empty;
                    Make.Text = string.Empty;
                    BoughtOn.Text = string.Empty;
                    Notes.Text = string.Empty;
                    ISOLimitGood.Text = string.Empty;
                    ISOLimitAcceptable.Text = string.Empty;
                }
                catch
                {
                    MessageBox.Show("Can't delete this camera because it its assigned to a picture.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (lastSelectedViewModel != null)
            {
                CameraViewModel cameraViewModel = lastSelectedViewModel;

                cameraViewModel.Producer = Producer.Text;
                cameraViewModel.Make = Make.Text;
                cameraViewModel.BoughtOn = DateTime.Parse(BoughtOn.Text);
                cameraViewModel.Notes = Notes.Text;
                Decimal.TryParse(ISOLimitGood.Text, out decimal isoLimitGood);
                cameraViewModel.ISOLimitGood = isoLimitGood;                
                Decimal.TryParse(ISOLimitAcceptable.Text, out decimal isoLimitAcceptable);
                cameraViewModel.ISOLimitAcceptable = isoLimitAcceptable;

                _controller.UpdateCamera(cameraViewModel);
            }
        }

        private void Camerabox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CameraBox.SelectedItem != null)
            {
                var CameraModel = (CameraViewModel)CameraBox.SelectedItem;
                lastSelectedViewModel = CameraModel;

                Producer.Text = CameraModel.Producer;
                Make.Text = CameraModel.Make;
                BoughtOn.Text = CameraModel.BoughtOn.ToString();
                Notes.Text = CameraModel.Notes;
                ISOLimitGood.Text = CameraModel.ISOLimitGood.ToString();
                ISOLimitAcceptable.Text = CameraModel.ISOLimitAcceptable.ToString();
            }
        }
    }
}

