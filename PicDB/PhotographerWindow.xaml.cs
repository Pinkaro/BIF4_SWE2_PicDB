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
using PicDB.Models;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for PhotographerWindow.xaml
    /// </summary>
    public partial class PhotographerWindow : Window
    {
        private PhotographerViewModel lastSelectedViewModel;
        private MainWindowViewModel _controller;
        public PhotographerWindow(MainWindowViewModel controller)
        {
            _controller = controller;
            InitializeComponent();
            this.DataContext = _controller;
        }

        private void PhotographerBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PhotographerBox.SelectedItem != null)
            {
                var PhotographerModel = (PhotographerViewModel) PhotographerBox.SelectedItem;
                lastSelectedViewModel = PhotographerModel;

                FirstName.Text = PhotographerModel.FirstName;
                LastName.Text = PhotographerModel.LastName;
                Birthday.Text = PhotographerModel.BirthDay.ToString();
                Notes.Text = PhotographerModel.Notes;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var PhotographerAddWindow = new PhotographerAddWindow(_controller);
            PhotographerAddWindow.Show();
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (lastSelectedViewModel != null)
            {
                PhotographerViewModel photographerViewModel = lastSelectedViewModel;

                photographerViewModel.FirstName = FirstName.Text;
                photographerViewModel.LastName = LastName.Text;
                photographerViewModel.BirthDay = DateTime.Parse(Birthday.Text);
                photographerViewModel.Notes = Notes.Text;

                _controller.UpdatePhotographer(photographerViewModel);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lastSelectedViewModel != null)
            {
                var photographerViewModel = lastSelectedViewModel;
                int ID = photographerViewModel.ID;
                try
                {
                    _controller.DeletePhotographer(ID);
                    FirstName.Text = string.Empty;
                    LastName.Text = string.Empty;
                    Birthday.Text = string.Empty;
                    Notes.Text = string.Empty;
            }
                catch
            {
                MessageBox.Show("Can't delete this photographer because it its assigned to a picture.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        }
    }
}
