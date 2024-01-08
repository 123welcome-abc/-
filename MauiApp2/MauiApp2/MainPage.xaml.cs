namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            //TestCommand = new Command(OnTest_Execute, OnTest_CanExecute);
            InitializeComponent();
        }
        private MainModel Model => BindingContext as MainModel;

        //public ICommand CalcConnand
        //{
        //    get;
        //}
        //public object OnTest_CanExecute { get; }
        //public object OnTest_Execute { get; }

        //private bool OnCalc_CanExecute()
        //{
        //    return true;
        //}

        //private void OnCalc_Execute()
        //{
        //    DisplayAlert("Calc", "Calc called.", "OK");
        //}

        private void OnTest_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Test", $"X={Model.X}", "OK");
        }
        private void OnClear_Clicked(object sender, EventArgs e)
        {
            Model.X = 0;
        }


        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private void OnPopip_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PopPage());
        }
    }

}
