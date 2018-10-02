using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicDB.ViewModels
{
    /// <summary>
    /// A helper class to notify the UI that a property has cahnged
    /// </summary>
    public class ViewModelNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// If a state of a property changes, call this method
        /// </summary>
        /// <param name="propName"></param>
        protected void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
