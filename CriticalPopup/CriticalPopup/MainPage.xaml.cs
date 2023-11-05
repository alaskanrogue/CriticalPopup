namespace CriticalPopup
{
	using Microsoft.Maui;
	using Microsoft.Maui.Controls;
	using CommunityToolkit.Maui.Alerts;
	using CommunityToolkit.Maui.Core;
	using CommunityToolkit.Maui.Media;
	using System.Globalization;
	using System.Threading;
    using System.ComponentModel;
    using CommunityToolkit.Maui.Views;

    public partial class MainPage : ContentPage
    {
        internal static string activeLanguage = "en-US";
        internal CancellationToken cancellationToken;
        internal bool yesno;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnStartCriticalAlertClicked(object sender, EventArgs e)
        {
            StartAlert();
        }

        private async void StartAlert()
        {
            await Task.Delay(30000);

            Microsoft.Maui.ApplicationModel.MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    AuthorizationPopup popup = new AuthorizationPopup();

                    popup.CanBeDismissedByTappingOutsideOfPopup = false;

                    await this.ShowPopupAsync(popup);
                }
                catch (Exception ex)
                {
                }
            });
        }
    }
}
