namespace Svetkavichko
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnStartClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///ChorePage");
        }
    }

}
