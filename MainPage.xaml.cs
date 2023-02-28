using MauiSelector.ViewModel;

namespace MauiSelector;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewmodel)
	{
		InitializeComponent();
		this.BindingContext = viewmodel;
	}
}

