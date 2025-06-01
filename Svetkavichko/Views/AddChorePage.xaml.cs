using Svetkavichko.Models;
using Svetkavichko.ViewModels;

namespace Svetkavichko.Views;

public partial class AddChorePage : ContentPage
{
    private readonly AddChoreViewModel _viewModel;
    public AddChorePage(AddChoreViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
		ShowChores();
	}

	private async void OnAddClicked(object sender, EventArgs e)
	{
		string choreText = ChoreEntry.Text.ToLower();
		await _viewModel.AddChoreAsync(choreText);
		ChoreEntry.Text = null;
	}
    public async void OnDeleteClicked(object sender, EventArgs e)
    {
            if (sender is Button button && button.BindingContext is Chore chore)
            {
                int choreId = chore.Id;
                await _viewModel.DeleteChore(choreId);
            }
        
    }
    private async void ShowChores()
	{
		await _viewModel.LoadChoresAsync();
	}
}