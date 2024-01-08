namespace MauiApp2;

public partial class PopPage : ContentPage
{
	public PopPage()
	{
		InitializeComponent();
	}
    private void close_page(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}