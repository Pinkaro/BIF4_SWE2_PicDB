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
    /// Interaction logic for CameraAddWindow.xaml
    /// </summary>
    public partial class CameraAddWindow : Window
    {
        private MainWindowViewModel _controller;
        public CameraAddWindow(MainWindowViewModel controller)
        {
            _controller = controller;
            InitializeComponent();
            this.DataContext = _controller;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var camera = new CameraModel();
            var boughtOn = DateTime.Now;
            decimal isoLimits;

            if (DateTime.TryParse(BoughtOn.Text, out boughtOn)) camera.BoughtOn = boughtOn;
            if (!string.IsNullOrWhiteSpace(Producer.Text)) camera.Producer = Producer.Text;
            if (!string.IsNullOrWhiteSpace(Make.Text)) camera.Make = Make.Text;
            if (!string.IsNullOrWhiteSpace(Notes.Text)) camera.Notes = Notes.Text;

            if (!string.IsNullOrWhiteSpace(ISOLimitAcceptable.Text))
                if (decimal.TryParse(ISOLimitAcceptable.Text, out isoLimits))
                    camera.ISOLimitAcceptable = isoLimits;

            if (!string.IsNullOrWhiteSpace(ISOLimitGood.Text))
                if (decimal.TryParse(ISOLimitGood.Text, out isoLimits))
                    camera.ISOLimitGood = isoLimits;


            _controller.SaveCamera(camera);
            this.Close();
        }
    }
}
