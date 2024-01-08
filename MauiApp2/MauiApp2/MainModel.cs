using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2
{
    internal class MainModel : INotifyPropertyChanged
    {
        public int X { get => _X; set
            {
                if (_X == value) return;
                _X = value;
                OnPropertyChanged(nameof(X));

            }
        } 
            private int _X = 100;
        private void OnPropertyChanged(string aPropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
