using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Media;
using System.Globalization;

namespace CriticalPopup
{
	public partial class AuthorizationPopup : Popup
	{
		internal CancellationToken cancellationToken;

		public AuthorizationPopup()
		{
			InitializeComponent();

			PopUp.Text = "     Critical Alert Testing     ";
            Button_Continue.Text = " Continue ";
		}

		void OnShowDestination(object? sender, EventArgs e) => OnShowDestinationPage();

		internal async void OnShowDestinationPage()
		{
            MainThread.BeginInvokeOnMainThread(() =>
            {
                App.SAPP.MainPage.ForceLayout();
            });

            await Task.Delay(2000);

			MainThread.BeginInvokeOnMainThread(() =>
			{
				App.SAPP.MainPage = new NavigationPage(new Destination());
			});

            Close();
        }
    }
}