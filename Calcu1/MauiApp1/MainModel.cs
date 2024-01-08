//using Android.Graphics;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1
{
    internal class MainModel: INotifyPropertyChanged
    {
        public MainModel()
        {
            TestCommand = new Command(
                execute: () =>
                {
                    Calc();
                },
                canExecute: () =>
                {
                    return X >= 0 && Y >= 0 && Z >= 0;
                }
                );
                
        }

        public ICommand TestCommand { get;}
    public int X 
        { get => _X; set { if (_X == value) return; _X = value; OnPropertyChanged(nameof(X)); (TestCommand as Command)?.ChangeCanExecute(); } }
        private int _X;

        public int Y 
        { get => _Y; set { if (_Y == value) return; _Y = value; OnPropertyChanged(nameof(Y)); (TestCommand as Command)?.ChangeCanExecute(); } }
        private int _Y;

        public int Z 
        { get => _Z; set { if (_Z == value) return; _Z = value; OnPropertyChanged(nameof(Z)); (TestCommand as Command)?.ChangeCanExecute(); } }
        private int _Z;

        public int Result 
        { 
            get => _Result; 
            set { if (_Result == value) return ; _Result = value; OnPropertyChanged(nameof(Result)); } }
        private int _Result;

        public void Calc()
        {
            Result = X + Y + Z;
        }


        private void OnPropertyChanged(string aPropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
