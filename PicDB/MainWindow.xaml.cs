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

namespace PicDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _controller;

        public MainWindow()
        {
            InitializeComponent();

            _controller = new MainWindowViewModel();
            this.DataContext = _controller;
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

        private void PictureSelection_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (PictureSelection.SelectedItem is PictureViewModel)
            {
                _controller.CurrentPicture = (PictureViewModel)PictureSelection.SelectedItem;
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
