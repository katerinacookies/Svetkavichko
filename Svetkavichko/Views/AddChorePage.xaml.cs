using Svetkavichko.ViewModels;

namespace Svetkavichko.Views;

public partial class AddChorePage : ContentPage
{
    private readonly AddChoreViewModel _viewModel;
    public AddChorePage(AddChoreViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
	}

	private async void OnAddClicked(object sender, EventArgs e)
	{
		string choreText = ChoreEntry.Text.ToLower();
		await _viewModel.AddChoreAsync(choreText);
	}
}