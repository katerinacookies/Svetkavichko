using Svetkavichko.ViewModels;

namespace Svetkavichko.Views;

public partial class ChorePage : ContentPage
{
    private readonly ChoreViewModel _viewModel;
    public ChorePage(ChoreViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
    }

    private async void OnRandomClicked(object sender, EventArgs e)
    {
        string randChore = await _viewModel.GenerateAsync();
        ChoreDisplay.Text = randChore;
    }
}