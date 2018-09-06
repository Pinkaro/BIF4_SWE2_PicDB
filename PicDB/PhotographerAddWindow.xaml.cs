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
    /// Interaction logic for PhotographerAddWindow.xaml
    /// </summary>
    public partial class PhotographerAddWindow : Window
    {
        private MainWindowViewModel _controller;
        public PhotographerAddWindow(MainWindowViewModel controller)
        {
            _controller = controller;
            InitializeComponent();
            this.DataContext = _controller;
        }

        private void SaveBtn_Clicked(object sender, RoutedEventArgs e)
        {
            var photographer = new PhotographerModel();
            var birthday = DateTime.Now;

            if (DateTime.TryParse(Birthday.Text, out birthday)) photographer.BirthDay = birthday;
            if (!string.IsNullOrWhiteSpace(FirstName.Text)) photographer.FirstName = FirstName.Text;
            if (!string.IsNullOrWhiteSpace(LastName.Text)) photographer.LastName = LastName.Text;
            if (!string.IsNullOrWhiteSpace(Notes.Text)) photographer.Notes = Notes.Text;

            _controller.SavePhotographer(photographer);
            this.Close();
        }
    }
}
