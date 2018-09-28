using System;
using System.Collections.Generic;
using System.IO;
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
using PicDB.utils;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for ExportPdfWindow.xaml
    /// </summary>
    public partial class ExportPdfWindow : Window
    {
        private MainWindowViewModel _controller;
        public ExportPdfWindow(MainWindowViewModel controller)
        {
            InitializeComponent();

            _controller = controller;
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var PdfReport = new PdfReport();
                PdfReport.CreateReport(Tags.Text);
                this.Close();
            }
            catch (FileNotFoundException exception)
            {
                // LOG EXCEPTION HERE
            }

            //MessageBox.Show("Can't delete this photographer because it its assigned to a picture.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
