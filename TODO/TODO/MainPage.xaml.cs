using System.Globalization;
using System.Windows.Input;
namespace TODO
{
    public partial class MainPage : ContentPage
    {
      

        public MainPage()
        {
            InitializeComponent();
            MainModel mainModel = new MainModel();
            mainModel.NavigationManager = Navigation;
            //mainModel.OnAppearing();
            BindingContext = mainModel;
            //(BindingContext as MainModel)?.LoadDataFromJson();

        }

        private MainModel? Model => BindingContext as MainModel;

    }
}
