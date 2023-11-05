using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Media;
using System.Globalization;
using System;

namespace CriticalPopup
{
	public partial class Destination : ContentPage
    {
        internal static CriticalPopup.MasterLayout pageLayout;

		internal string textToDisplay = "";
        internal string narrative = "";

        internal double p0;
        internal double p1;
        internal double p2;
        internal double p3;
        internal double p4;
        internal double p5;
        internal double p6;
        internal double p7;
        internal double p8;

		internal long RID;

		internal string UsageTitle;
		internal string Opening;
		internal string Reason;
		internal string Requester;

		internal double rowsNeeded = 0;

		internal bool timePeriodExceeded;

        internal string tempText = "abcdefg hijklmn opq rstuv wxyz abcdefg hijklmn opq rstuv wxyz";
        internal string tempText2 = "abcdefg hijklmn opq rstuv wxyz abcdefg hijklmn opq rstuv wxyz abcdefg hijklmn opq rstuv wxyz";

        internal Destination()
        {
            try
            {
                DevAppWin.MicroFont = 12;
                DevAppWin.SmallFont = 14;
                DevAppWin.MediumFont = 18;
                DevAppWin.LargeFont = 22;

                DevAppWin.LargeFontLineHeight = 17;
                DevAppWin.LargeFontRowCharacters = 30;

                DevAppWin.SetAppSize();

                pageLayout = new MasterLayout();

                pageLayout.SetRowSizes();

                InitializeComponent();

                NavigationPage.SetHasNavigationBar(this, false);

                // Default Row Sizes
                p0 = DevAppWin.LargeFontLineHeight;
                p1 = DevAppWin.LargeFontLineHeight;
                p2 = DevAppWin.LargeFontLineHeight;
                p3 = DevAppWin.LargeFontLineHeight;
                p4 = 2 * DevAppWin.LargeFontLineHeight;
                p5 = DevAppWin.LargeFontLineHeight;
                p6 = DevAppWin.LargeFontLineHeight;
                p7 = 8 * DevAppWin.LargeFontLineHeight;
                p8 = 2 * DevAppWin.LargeFontLineHeight;

                pageLayout.Layout(2, true, true, this,
                    p0,
                    p1,
                    p2,
                    p3,
                    p4,
                    p5,
                    p6,
                    p7,
                    p8);

                p1 = pageLayout.GetTextRowsHeight("ABC", DevAppWin.LargeFontRowCharacters, DevAppWin.LargeFontLineHeight);

                if (DevAppWin.platform == 3)
				{
					Appearing += RefreshPage;
				}

                CreateHeader();
			}
			catch (Exception ex)
            {
            }
        }

		internal void CreateHeader()
		{
			try
			{
				CreateReason();
			}
			catch (Exception ex)
			{
			}
		}

		internal void CreateReason()
		{
			try
			{
                ReasonSpan.FontFamily = "Calibri Light";
				ReasonSpan.TextColor = Microsoft.Maui.Graphics.Colors.Black; ReasonSpan.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent;
				ReasonSpan.FontSize = DevAppWin.LargeFont;
				ReasonSpan.FontAttributes = FontAttributes.Bold;
				ReasonSpan.FontAutoScalingEnabled = false;

                ReasonSpan.Text = tempText;

                p3 = pageLayout.GetTextRowsHeight(ReasonSpan.Text, DevAppWin.LargeFontRowCharacters, DevAppWin.LargeFontLineHeight) + (1 * DevAppWin.LargeFontLineHeight);

				ReasonLabel.HeightRequest = p3;
				ReasonLabel.WidthRequest = DevAppWin.CenterColumnWidth - 60;
				ReasonLabelBorder.WidthRequest = DevAppWin.CenterColumnWidth - 20;
				ReasonGrid.HeightRequest = p3;
				LayoutSubRoot1.HeightRequest = p3;
				Content2.HeightRequest = p3;

				CreateRequester();
			}
			catch (Exception ex)
			{
			}
		}

		internal void CreateRequester()
		{
			try
			{
                RequesterSpan.FontFamily = "Calibri Light";
				RequesterSpan.TextColor = Microsoft.Maui.Graphics.Colors.Black; RequesterSpan.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent;
				RequesterSpan.FontSize = DevAppWin.LargeFont;
				RequesterSpan.FontAttributes = FontAttributes.Bold | FontAttributes.Italic;
				RequesterSpan.FontAutoScalingEnabled = false;

                RequesterSpan.Text = tempText2;

                p5 = pageLayout.GetTextRowsHeight(RequesterSpan.Text, DevAppWin.LargeFontRowCharacters, DevAppWin.LargeFontLineHeight) + (1 * DevAppWin.LargeFontLineHeight);

				RequesterLabel.HeightRequest = p5;
				RequesterLabel.WidthRequest = DevAppWin.CenterColumnWidth - 60;
				RequesterLabelBorder.WidthRequest = DevAppWin.CenterColumnWidth - 20;
				RequesterGrid.HeightRequest = p5;
				LayoutSubRoot2.HeightRequest = p5;
				Content3.HeightRequest = p5;

                CreateDestination();
			}
			catch (Exception ex)
			{
			}
		}

		internal void CreateDestination()
		{
			try
			{
				Content4.HeightRequest = pageLayout.R7;
				LayoutSubRoot3.HeightRequest = pageLayout.R7;

                Button_Yes.IsEnabled = true;
                Button_Yes.IsVisible = true;
                Button_No.IsEnabled = true;
                Button_No.IsVisible = true;

                Button_YesLabel.Text = "Yes";
				Button_YesLabel.FontFamily = "Calibri Light";
				Button_YesLabel.TextColor = Microsoft.Maui.Graphics.Colors.Black; Button_YesLabel.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent;
				Button_YesLabel.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent;
				Button_YesLabel.FontSize = DevAppWin.MediumFont;
				Button_YesLabel.FontAttributes = FontAttributes.Bold;
				Button_YesLabel.FontAutoScalingEnabled = false;

				Button_NoLabel.Text = "No";
				Button_NoLabel.FontFamily = "Calibri Light";
				Button_NoLabel.TextColor = Microsoft.Maui.Graphics.Colors.Black;
				Button_NoLabel.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent;
				Button_NoLabel.FontSize = DevAppWin.MediumFont;
				Button_NoLabel.FontAttributes = FontAttributes.Bold;
				Button_NoLabel.FontAutoScalingEnabled = false;

				if (DevAppWin.platform == 3)
				{
					Appearing += RefreshPage;
				}

				Content4.HeightRequest = pageLayout.R7;
				LayoutSubRoot3.HeightRequest = pageLayout.R7;

                LayoutPage();
                ForceLayout();

                App.inBackground = false;
			}
			catch (Exception ex)
			{
			}
		}


		private void RefreshPage(object sender, EventArgs e)
        {
            try
            {
                NavigationPage.SetHasNavigationBar(this, false);

                IsVisible = true;
			}
			catch (Exception ex)
            {
            }
        }

		internal void Clicked_Yes(object sender, EventArgs args)
		{
            App.SAPP.MainPage = new NavigationPage(new MainPage());
        }

        internal void Clicked_No(object sender, EventArgs args)
		{
            App.SAPP.MainPage = new NavigationPage(new MainPage());
        }

        internal void LayoutPage()
		{
			try
			{
                double totalHeight = DevAppWin.AppContentHeight;

                p0 = (p0 / totalHeight) * 100;
                p1 = (p1 / totalHeight) * 100;
                p2 = (p2 / totalHeight) * 100;
                p3 = (p3 / totalHeight) * 100;
                p4 = (p4 / totalHeight) * 100;
                p5 = (p5 / totalHeight) * 100;
                p7 = (p7 / totalHeight) * 100;
                p8 = (p8 / totalHeight) * 100;

                p6 = (100 - p0 - p1 - p2 - p3 - p4 - p5 - p7 - p8);

                pageLayout.Layout(2, true, true, this,
                    p0,
                    p1,
                    p2,
                    p3,
                    p4,
                    p5,
                    p6,
                    p7,
                    p8);

				// Decision Buttons
				double MBW0 = pageLayout.R7 * .55;
				double MBH0 = pageLayout.R7 * .55;

				double column7a;
				double column7b;
				double column7c;
				double column7d;
				double column7e;
				double column7f;

				column7a = Math.Floor(pageLayout.LR0 * .03);
				column7b = Math.Floor(pageLayout.LR0 * .45);
				column7c = Math.Floor(pageLayout.LR0 * .03);
				column7d = Math.Floor(pageLayout.LR0 * .0);
				column7e = Math.Floor(pageLayout.LR0 * .0);
				column7f = Math.Floor(pageLayout.LR0 * .45);

				Column7a.Width = column7a;
				Column7b.Width = column7b;
				Column7c.Width = column7c;
				Column7d.Width = column7d;
				Column7e.Width = column7e;
				Column7f.Width = column7f;
				Column7g.Width = Math.Floor(pageLayout.LR0 - column7a - column7b - column7c - column7d - column7e - column7f);

				Row7a.Height = Math.Ceiling(Row7.Height.Value * .55);
				Row7b.Height = Math.Ceiling(Row7.Height.Value * .05);
				Row7c.Height = Math.Ceiling(Row7.Height.Value * .40);

				Button_Yes.Source = DevAppWin.ImageFolder + "icon_yes.png";
				Button_Yes.WidthRequest = MBW0;
				Button_Yes.HeightRequest = MBH0;
				Button_Yes.BorderWidth = 0;

				Button_No.Source = DevAppWin.ImageFolder + "icon_cancel.png";
				Button_No.WidthRequest = MBW0;
				Button_No.HeightRequest = MBH0;
				Button_No.BorderWidth = 0;
			}
			catch (Exception ex)
			{
			}
		}
	}
}
