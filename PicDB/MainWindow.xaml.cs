﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
            Searchbar.FontSize = 14;
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

        private void MenuOptionChangeHomeFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = GlobalInformation.Path;
            fbd.ShowDialog();

            //if the path changed, overwrite config file and load pictures of the new folder
            if (fbd.SelectedPath != GlobalInformation.Path)
            {
                var oldLines = System.IO.File.ReadAllLines("config.txt");
                List<string> newLines = new List<string>();
                foreach (var line in oldLines)
                {
                    if (line.Contains("path,"))
                    {
                        string addLine = "path," + fbd.SelectedPath + "\\";
                        newLines.Add(addLine);
                    }
                    else
                    {
                        newLines.Add(line);
                    }
                }
                System.IO.File.WriteAllLines("config.txt", newLines);
                GlobalInformation.ReadConfigFile();
                ((PictureListViewModel)_controller.List).SyncAndUpdatePictureList();
            }
        }

        private void MenuEditCameras_Click(object sender, RoutedEventArgs e)
        {
            var cameraWindow = new CameraWindow(_controller);

            cameraWindow.Show();
        }

        private void MenuEditPhotographers_Click(object sender, RoutedEventArgs e)
        {
            var photographerWindow = new PhotographerWindow(_controller);

            photographerWindow.Show();
        }

        private void MenuExportPdf_Click(object sender, RoutedEventArgs e)
        {
            var exportPdf = new ExportPdfWindow(_controller);

            exportPdf.Show();
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


        private void ExportPdfSingle_Click(object sender, RoutedEventArgs e)
        {
            var PdfReport = new PdfReport();
            PdfReport.CreateReport(_controller.CurrentPicture);
        }
    }
}
