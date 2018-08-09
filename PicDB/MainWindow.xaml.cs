using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Layers;
using PicDB.Models;
using PicDB.utils;
using PicDB.ViewModels;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _controller;

        public MainWindow()
        {
            GlobalInformation.ReadConfigFile();
            InitializeComponent();

            _controller = new MainWindowViewModel();
            this.DataContext = _controller;
            Searchbar.Foreground = Brushes.DimGray;
            Searchbar.Text = "Search picture";
        }

        private void BtnSaveIPTC_Click(object sender, RoutedEventArgs e)
        {
            IPictureViewModel currentPicture = _controller.CurrentPicture;

            currentPicture.IPTC.Keywords = UI_IPTC_Keywords.Text;
            currentPicture.IPTC.ByLine = UI_IPTC_ByLine.Text;
            currentPicture.IPTC.CopyrightNotice = UI_IPTC_CopyrightNotice.Text;
            currentPicture.IPTC.Headline = UI_IPTC_Headline.Text;
            currentPicture.IPTC.Caption = UI_IPTC_Caption.Text;

            _controller.SaveCurrentPicture();
        }

        private void BtnSaveGeneralInfo_Click(object sender, RoutedEventArgs e)
        {
            var CameraViewmodel = (CameraViewModel)CameraBox.SelectedItem;
            var PhotographerViewModel = (PhotographerViewModel)PhotogrBox.SelectedItem;
            _controller.SaveGeneralInformation(CameraViewmodel, PhotographerViewModel);
        }

        private void PictureSelection_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (PictureSelection.SelectedItem is PictureViewModel)
            {
                _controller.CurrentPicture = (PictureViewModel)PictureSelection.SelectedItem;
            }
            
        }

        private void Searchbar_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ((PictureListViewModel)_controller.List).ResetList();
            if (Searchbar.IsFocused)
            {
                ObservableCollection<IPictureViewModel> filteredList = new ObservableCollection<IPictureViewModel>();
                foreach (IPictureViewModel viewModel in _controller.List.List)
                {
                    if (viewModel.FileName.ToLower().Contains(Searchbar.Text.ToLower()))
                    {
                        filteredList.Add(viewModel);
                    }
                }

                ((PictureListViewModel)_controller.List).List = filteredList;
            }
        }

        private void Searchbar_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Searchbar.Text) && Searchbar.Foreground == Brushes.DimGray)
            {
                Searchbar.Text = string.Empty;
                Searchbar.Foreground = Brushes.Black;
            }
        }

        private void Searchbar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Searchbar.Text))
            {
                Searchbar.Foreground = Brushes.DimGray;
                Searchbar.Text = "Search picture";
            }
        }

        /// <summary>
        /// TO MAYBO DO
        /// </summary>
        private void ValidateIPTC()
        {
            string Keywords = UI_IPTC_Keywords.Text;
            string ByLine = UI_IPTC_ByLine.Text;
            string CopyrightNotice = UI_IPTC_CopyrightNotice.Text;
            string Headline = UI_IPTC_Headline.Text;
            string Caption = UI_IPTC_Caption.Text;
        }
    }
}
