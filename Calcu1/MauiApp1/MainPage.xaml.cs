using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private MainModel Model => BindingContext as MainModel;
        public MainPage()
        {
            InitializeComponent();

        }


        private void OnCalu_Clicked(object sender, EventArgs e)
        {
            Model.Calc();
        }
    }

}
