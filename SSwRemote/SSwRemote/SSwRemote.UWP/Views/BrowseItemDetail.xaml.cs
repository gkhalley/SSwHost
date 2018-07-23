using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using SSwRemote.Models;
using SSwRemote.ViewModels;

namespace SSwRemote.UWP.Views
{
	public sealed partial class BrowseItemDetail : Page
	{
		public ItemDetailViewModel ViewModel { get; set; }

		public BrowseItemDetail()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			ViewModel = new ItemDetailViewModel((Item)e.Parameter);
			DataContext = ViewModel;
		}
	}
}